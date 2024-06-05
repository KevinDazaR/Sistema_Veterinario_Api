
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace FiltroJobs.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string? Name {get;set;}

        [Required]
        public string? Specie { get; set; }
        [Required]
        public string? Race { get; set; }

        [Required]
        public DateTime? DateBirth { get; set; }

        [Required]
        public int? OwnerId { get; set; }
        
        [Required]
        public string? Photo { get; set; }

        [Required]
        public string? State { get; set; }

        // [JsonIgnore]
        // public List<Tratamiento> ? Tratamiento {get;set;} //Consultar - listar

        
    }
}

