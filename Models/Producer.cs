using EcommerceCenima.Data.Base;

namespace EcommerceCenima.Models
{
    public class Producer:IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PicUrl { get; set; }
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
	}
}
