using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered
using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey


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
        public string? Photo { get; set; }

        [Required]
        public string? State { get; set; }

        [ForeignKey("OwnerId") ]
        public int?  OwnerId {get; set ;}
        public Owner? Owners {get; set ;} // muchas mascotas tienen un solo dueño

        [JsonIgnore]
        public List<Quote> Quotes {get; set ;} //una mascota puede tener muchas citas 
        
    }
}

