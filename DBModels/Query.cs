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

        #endregion

        public Query(string filepath, QueryStateEnum state) : this()
        {
            FilePath = filepath;
            State = state;
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

    }

    public enum QueryStateEnum
    {
        Opened,
        Edited,
        NotEdited
    }
}
