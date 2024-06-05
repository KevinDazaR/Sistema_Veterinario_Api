using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace FiltroJobs.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string? Names {get;set;}

        [Required]
        public string? Lastnames { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? State { get; set; }

        // [JsonIgnore]
        // public List<Tratamiento> ? Tratamiento {get;set;} //Consultar - listar

        
    }
}

