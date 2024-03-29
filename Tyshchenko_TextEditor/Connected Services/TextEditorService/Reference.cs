﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tyshchenko_TextEditor.TextEditorService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TextEditorService.ITextEditorContract")]
    public interface ITextEditorContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/UserExists", ReplyAction="http://tempuri.org/ITextEditorContract/UserExistsResponse")]
        bool UserExists(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/UserExists", ReplyAction="http://tempuri.org/ITextEditorContract/UserExistsResponse")]
        System.Threading.Tasks.Task<bool> UserExistsAsync(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetUserByLogin", ReplyAction="http://tempuri.org/ITextEditorContract/GetUserByLoginResponse")]
        DBModels.User GetUserByLogin(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetUserByLogin", ReplyAction="http://tempuri.org/ITextEditorContract/GetUserByLoginResponse")]
        System.Threading.Tasks.Task<DBModels.User> GetUserByLoginAsync(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetUserByGuid", ReplyAction="http://tempuri.org/ITextEditorContract/GetUserByGuidResponse")]
        DBModels.User GetUserByGuid(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetUserByGuid", ReplyAction="http://tempuri.org/ITextEditorContract/GetUserByGuidResponse")]
        System.Threading.Tasks.Task<DBModels.User> GetUserByGuidAsync(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetAllUsers", ReplyAction="http://tempuri.org/ITextEditorContract/GetAllUsersResponse")]
        System.Collections.Generic.List<DBModels.User> GetAllUsers(System.Guid queryGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetAllUsers", ReplyAction="http://tempuri.org/ITextEditorContract/GetAllUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DBModels.User>> GetAllUsersAsync(System.Guid queryGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/AddUser", ReplyAction="http://tempuri.org/ITextEditorContract/AddUserResponse")]
        void AddUser(DBModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/AddUser", ReplyAction="http://tempuri.org/ITextEditorContract/AddUserResponse")]
        System.Threading.Tasks.Task AddUserAsync(DBModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/AddQuery", ReplyAction="http://tempuri.org/ITextEditorContract/AddQueryResponse")]
        void AddQuery(DBModels.Query query, System.Guid userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/AddQuery", ReplyAction="http://tempuri.org/ITextEditorContract/AddQueryResponse")]
        System.Threading.Tasks.Task AddQueryAsync(DBModels.Query query, System.Guid userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetQueryByGuid", ReplyAction="http://tempuri.org/ITextEditorContract/GetQueryByGuidResponse")]
        DBModels.Query GetQueryByGuid(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/GetQueryByGuid", ReplyAction="http://tempuri.org/ITextEditorContract/GetQueryByGuidResponse")]
        System.Threading.Tasks.Task<DBModels.Query> GetQueryByGuidAsync(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/SaveQuery", ReplyAction="http://tempuri.org/ITextEditorContract/SaveQueryResponse")]
        void SaveQuery(DBModels.Query query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/SaveQuery", ReplyAction="http://tempuri.org/ITextEditorContract/SaveQueryResponse")]
        System.Threading.Tasks.Task SaveQueryAsync(DBModels.Query query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/DeleteQuery", ReplyAction="http://tempuri.org/ITextEditorContract/DeleteQueryResponse")]
        void DeleteQuery(DBModels.Query selectedQuery);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITextEditorContract/DeleteQuery", ReplyAction="http://tempuri.org/ITextEditorContract/DeleteQueryResponse")]
        System.Threading.Tasks.Task DeleteQueryAsync(DBModels.Query selectedQuery);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITextEditorContractChannel : Tyshchenko_TextEditor.TextEditorService.ITextEditorContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TextEditorContractClient : System.ServiceModel.ClientBase<Tyshchenko_TextEditor.TextEditorService.ITextEditorContract>, Tyshchenko_TextEditor.TextEditorService.ITextEditorContract {
        
        public TextEditorContractClient() {
        }
        
        public TextEditorContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TextEditorContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TextEditorContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TextEditorContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool UserExists(string login) {
            return base.Channel.UserExists(login);
        }
        
        public System.Threading.Tasks.Task<bool> UserExistsAsync(string login) {
            return base.Channel.UserExistsAsync(login);
        }
        
        public DBModels.User GetUserByLogin(string login) {
            return base.Channel.GetUserByLogin(login);
        }
        
        public System.Threading.Tasks.Task<DBModels.User> GetUserByLoginAsync(string login) {
            return base.Channel.GetUserByLoginAsync(login);
        }
        
        public DBModels.User GetUserByGuid(System.Guid guid) {
            return base.Channel.GetUserByGuid(guid);
        }
        
        public System.Threading.Tasks.Task<DBModels.User> GetUserByGuidAsync(System.Guid guid) {
            return base.Channel.GetUserByGuidAsync(guid);
        }
        
        public System.Collections.Generic.List<DBModels.User> GetAllUsers(System.Guid queryGuid) {
            return base.Channel.GetAllUsers(queryGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DBModels.User>> GetAllUsersAsync(System.Guid queryGuid) {
            return base.Channel.GetAllUsersAsync(queryGuid);
        }
        
        public void AddUser(DBModels.User user) {
            base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task AddUserAsync(DBModels.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public void AddQuery(DBModels.Query query, System.Guid userGuid) {
            base.Channel.AddQuery(query, userGuid);
        }
        
        public System.Threading.Tasks.Task AddQueryAsync(DBModels.Query query, System.Guid userGuid) {
            return base.Channel.AddQueryAsync(query, userGuid);
        }
        
        public DBModels.Query GetQueryByGuid(System.Guid guid) {
            return base.Channel.GetQueryByGuid(guid);
        }
        
        public System.Threading.Tasks.Task<DBModels.Query> GetQueryByGuidAsync(System.Guid guid) {
            return base.Channel.GetQueryByGuidAsync(guid);
        }
        
        public void SaveQuery(DBModels.Query query) {
            base.Channel.SaveQuery(query);
        }
        
        public System.Threading.Tasks.Task SaveQueryAsync(DBModels.Query query) {
            return base.Channel.SaveQueryAsync(query);
        }
        
        public void DeleteQuery(DBModels.Query selectedQuery) {
            base.Channel.DeleteQuery(selectedQuery);
        }
        
        public System.Threading.Tasks.Task DeleteQueryAsync(DBModels.Query selectedQuery) {
            return base.Channel.DeleteQueryAsync(selectedQuery);
        }
    }
}
