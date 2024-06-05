using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
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
        [ForeignKey("PetId")]
        public int? PetId { get; set; }
        public Pet ? Pets {get; set ;} // una cita solo puede tener una mascota 
        
        [Required]
        [ForeignKey("VetId")]
        public int? VetId { get; set; }
        public Vet ? Vets {get; set ;} // una cita solo puede tener un veterinario

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? State { get; set; }

        // [JsonIgnore]
        // public List<Tratamiento> ? Tratamiento {get;set;} //Consultar - listar

        
    }
}

