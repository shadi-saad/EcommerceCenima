using EcommerceCenima.Data.Base;
using EcommerceCenima.Models;

namespace EcommerceCenima.Data.Services
{
    public class ProducerServices : EntityBaseRepository<Producer>,IproducerServices
    {
        public ProducerServices(AppDbContext context) : base(context)
        {
        }
    }
}
