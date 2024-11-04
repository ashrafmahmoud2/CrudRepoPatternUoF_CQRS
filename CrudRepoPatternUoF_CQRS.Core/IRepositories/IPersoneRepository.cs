using CrudRepoPatternUoF_CQRS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Core.IRepositories;
public interface IPersonaRepository : IBaseRepository<Persone>
{
    Task<Persone> GetByEmailAsync(string email);
    Task<IEnumerable<Persone>> GetByLastNameAsync(string lastName);

    Task<Persone> GetByAgeAsync(int Age);

}
