using System.Runtime.Serialization;

namespace Challenged.Domain.Entities
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "bmx")]
        public SeriesResponse seriesResponse { get; set; }
    }
}