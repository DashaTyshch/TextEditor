using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace WCFWindowsService
{
    public partial class TextEditorWCFService : ServiceBase
    {
        internal const string CurrentServiceName = "TextEditorService";
        internal const string CurrentServiceDisplayName = "Text Editor Service";
        internal const string CurrentServiceSource = "TextEditorServiceSource";
        internal const string CurrentServiceLogName = "TextEditorServiceLogName";
        internal const string CurrentServiceDescription = "Text Editor for learning purposes.";
        private ServiceHost _serviceHost = null;

        public TextEditorWCFService()
        {
            InitializeComponent();
            ServiceName = CurrentServiceName;
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        protected override void OnStart(string[] args)
        {
            //Logger.Log("OnStart");
#if DEBUG
            RequestAdditionalTime(120 * 1000);
#endif
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            try
            {
                _serviceHost = new ServiceHost(typeof(TextEditorService.Service1));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                //Logger.Log("OnStart", ex);
                throw;
            }
            //Logger.Log("Service Started");
        }

        protected override void OnStop()
        {
            //Logger.Log("OnStop");
            RequestAdditionalTime(120 * 1000);

            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                //Logger.Log("Trying To Stop The Host Listener", ex);
            }
            //Logger.Log("Service Stopped");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;

            //Logger.Log("UnhandledException", ex);
        }
    }
}
