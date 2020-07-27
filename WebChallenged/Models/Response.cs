using System.Runtime.Serialization;

namespace Challenged.Domain.Entities
{
    [DataContract]
    class Response
    {
        [DataMember(Name = "bmx")]
        public SeriesResponse seriesResponse { get; set; }
    }
}