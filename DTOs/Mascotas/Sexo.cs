using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTOs.Mascotas
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sexo
    {
        [Display(Name = "Macho")]
        Macho,

        [Display(Name = "Hembra")]
        Hembra
    }
}
