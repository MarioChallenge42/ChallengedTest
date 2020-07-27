using System.Runtime.Serialization;

namespace Challenged.Domain.Entities
{
    [DataContract]
    public class DataSerie
    {
        [DataMember(Name = "fecha")]
        public string Date { get; set; }

        [DataMember(Name = "dato")]
        public string Data { get; set; }
    }

}