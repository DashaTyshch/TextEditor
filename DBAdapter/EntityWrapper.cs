using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBAdapter
{
    public class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new TextEditorDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new TextEditorDBContext())
            {
                return context.Users.Include(u => u.Queries).FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new TextEditorDBContext())
            {
                return context.Users.Include(u => u.Queries).FirstOrDefault(u => u.Guid == guid);
            }
        }

        public static List<User> GetAllUsers(Guid walletGuid)
        {
            using (var context = new TextEditorDBContext())
            {
                return context.Users.Where(u => u.Queries.All(r => r.Guid != walletGuid)).ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new TextEditorDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddQuery(Query query, Guid userGuid)
        {
            using (var context = new TextEditorDBContext())
            {
                //query.DeleteDatabaseValues();
                context.Users.FirstOrDefault(u => u.Guid == userGuid).Queries.Add(query);
                //context.Queries.Add(query);
                context.SaveChanges();
            }
        }

        public static Query GetQueryByGuid(Guid guid)
        {
            using (var context = new TextEditorDBContext())
            {
                return context.Queries.FirstOrDefault(q => q.Guid == guid);
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var context = new TextEditorDBContext())
            {
                context.Entry(query).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            using (var context = new TextEditorDBContext())
            {
                //selectedQuery.DeleteDatabaseValues();
                context.Queries.Attach(selectedQuery);
                context.Queries.Remove(selectedQuery);
                context.SaveChanges();
            }
        }
    }
}
