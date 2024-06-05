using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace FiltroJobs.Models
{
    public class Vet
    {
        public int Id { get; set; }

        [Required]
        public string? Name {get;set;}

        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? State { get; set; }

        [JsonIgnore]
        public List<Quote> ? Quotes {get; set ;} //un veterinario puede tener muchas citas 
        
    }
}

