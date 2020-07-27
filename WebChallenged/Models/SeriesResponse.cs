using System.Runtime.Serialization;

namespace Challenged.Domain.Entities
{
    [DataContract]
    class SeriesResponse
    {
        [DataMember(Name = "series")]
        public Serie[] series { get; set; }
    }
}