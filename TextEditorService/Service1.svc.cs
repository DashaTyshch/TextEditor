﻿using DBAdapter;
using DBModels;
using System;
using System.Collections.Generic;
using TextEditorServiceInterface;

namespace TextEditorService
{
    public class Service1 : ITextEditorContract
    {
        public void AddQuery(Query query, Guid userGuid)
        {
            EntityWrapper.AddQuery(query, userGuid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void DeleteQuery(Query selectedQuery)
        {
            EntityWrapper.DeleteQuery(selectedQuery);
        }

        public IEnumerable<User> GetAllUsers(Guid queryGuid)
        {
            return EntityWrapper.GetAllUsers(queryGuid);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void SaveQuery(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }

        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }
    }
}
