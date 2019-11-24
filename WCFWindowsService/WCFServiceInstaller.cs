using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WCFWindowsService
{
    [RunInstaller(true)]
    public partial class WCFServiceInstaller : Installer
    {
        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;

        public WCFServiceInstaller()
        {
            InitializeComponent();

            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller = new ServiceInstaller();
            _serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            _serviceProcessInstaller.Password = null;
            _serviceProcessInstaller.Username = null;
            _serviceInstaller.ServiceName = TextEditorWCFService.CurrentServiceName;
            _serviceInstaller.DisplayName = TextEditorWCFService.CurrentServiceDisplayName;
            _serviceInstaller.Description = TextEditorWCFService.CurrentServiceDescription;
            _serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.AddRange(new Installer[]
            {
                _serviceProcessInstaller,
                _serviceInstaller
            });
        }
    }
}
