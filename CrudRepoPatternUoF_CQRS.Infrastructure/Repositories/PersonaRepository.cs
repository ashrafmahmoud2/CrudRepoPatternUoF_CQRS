using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Infrastructure.Repositories
{
    public class PersonaRepository : BaseRepository<Persone>, IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Persone> GetByEmailAsync(string email)
        {
            return await _context.Set<Persone>().SingleOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Persone>> GetByLastNameAsync(string lastName)
        {
            return await _context.Set<Persone>().Where(p => p.LastName == lastName).ToListAsync();
        }

        public async Task<Persone> GetByAgeAsync(int age)
        {
            return await _context.Set<Persone>().SingleOrDefaultAsync(p => p.Age == age);
        }
    }
}
