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
        public string? LastNames { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? State { get; set; }
        
        [JsonIgnore]
        public List<Pet> ? Pets {get; set ;} //un dueño puede tener muchas mascotas 


        
    }
}

