using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private ReinmarDbContext _context;
        public StatusRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(Status entity)
        {
            _context.Entry(entity.WaybillBodies).State = EntityState.Unchanged;

            _context.Statusses.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(Status entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}