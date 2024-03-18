using EcommerceCenima.Data.Base;
using EcommerceCenima.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCenima.Data.Services
{
    public class ActorService :EntityBaseRepository<Actor>, IActorService
    {

        public ActorService(AppDbContext context):base(context) { }
        
		
	}
}
