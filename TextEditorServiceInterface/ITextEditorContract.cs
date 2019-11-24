using DBModels;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace TextEditorServiceInterface
{
    [ServiceContract]
    public interface ITextEditorContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        IEnumerable<User> GetAllUsers(Guid queryGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddQuery(Query query, Guid userGuid);
        [OperationContract]
        void SaveQuery(Query query);
        [OperationContract]
        void DeleteQuery(Query selectedQuery);
    }
}

