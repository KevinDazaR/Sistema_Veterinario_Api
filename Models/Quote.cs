
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace FiltroJobs.Models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public int? PetId { get; set; }
        
        [Required]
        public int? VetId { get; set; }
        
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? State { get; set; }

        // [JsonIgnore]
        // public List<Tratamiento> ? Tratamiento {get;set;} //Consultar - listar

        
    }
}

