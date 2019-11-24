using System;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Query
    {
        #region Properties
        [DataMember]
        public Guid Guid { get; private set; }
        [DataMember]
        public DateTime QueryDate { get; private set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public QueryStateEnum State { get; set; }

        //[DataMember]
        //public Guid UserGuid { get; }
        //[DataMember]
        //public User User { get; private set; }

        #endregion

        public Query(string filepath, QueryStateEnum state/*, Guid userGuid*/) : this()
        {
            FilePath = filepath;
            State = state;
            //UserGuid = userGuid;
            //User = user;
        }

        private Query()
        {
            Guid = Guid.NewGuid();
            QueryDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"~ {FilePath} - {QueryDate:g} - {State}";
        }

        //public void DeleteDatabaseValues()
        //{
        //    User = null;
        //}
    }

    public enum QueryStateEnum
    {
        Opened,
        Edited,
        NotEdited
    }
}
