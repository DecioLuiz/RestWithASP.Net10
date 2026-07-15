using RestWithASPNet10.JsonSerializers;
using System.Text.Json.Serialization;

namespace RestWithASPNet10.Data.DTO.V2
{
    public class PersonDTO
    {
        //[JsonPropertyOrder(1)]
        //[JsonPropertyName("code")]
        public long Id { get; set; }
        //[JsonPropertyOrder(2)]
        //[JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        //[JsonPropertyOrder(3)]
        //[JsonPropertyName("last_name")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LastName { get; set; }
        //[JsonPropertyOrder(4)]
        //[JsonConverter(typeof(GenderSerializer))]
        public string Gender { get; set; }
        //[JsonPropertyOrder(6)]
        public string Address { get; set; }
        //[JsonPropertyOrder(5)]
        //[JsonConverter(typeof(DateSerializer))]
        //[JsonIgnore]
        public DateTime? BirthDate { get; set; }
    }
}
