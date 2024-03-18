using EcommerceCenima.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcommerceCenima.Models
{
    public class Actor:IEntityBase
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="The Name Must be between 3-50 charcter") ]
        public string FullName { get; set; }
        public string PicUrl { get; set; }
        [Required]
        public string Bio { get; set; }
        public List<MovieActors> MovieActors { get; set; } = new List<MovieActors>();

    }
}
