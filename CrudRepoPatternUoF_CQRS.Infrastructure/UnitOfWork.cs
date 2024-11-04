using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core;
using CrudRepoPatternUoF_CQRS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudRepoPatternUoF_CQRS.Core.Models;

namespace CrudRepoPatternUoF_CQRS.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IBaseRepository<Book> Books { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Books = new BaseRepository<Book>(_context);
    }
    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}