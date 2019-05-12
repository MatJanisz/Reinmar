using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class WaybillBodyRepository :  IWaybillBodyRepository
    {
        private ReinmarDbContext _context;
        public WaybillBodyRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(WaybillBody entity)
        {
            _context.WaybillBodies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(WaybillBody entity)
        {
            _context.WaybillBodies.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(WaybillBody entity)
        {
            _context.WaybillBodies.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<WaybillBody> GetAll()
        {
            return _context.WaybillBodies
                .Include(x=>x.WaybillHeaders)
                .Include(x=>x.Status).ToList();
        }

        public IEnumerable<WaybillBody> GetByHeaderId(Guid id)
        {
            return _context.WaybillBodies
                .Where(x => x.WaybillHeaders.Id == id)
                .Include(x=>x.WaybillHeaders)
                .Include(x=>x.Status)
                .ToList();
        }

        public WaybillBody GetById(Guid id)
        {
            return _context.WaybillBodies
                .Where(x=>x.Id.Equals(id))
                .Include(x=>x.WaybillHeaders)
                .Include(x=>x.Status).FirstOrDefault();
        }

        public IEnumerable<WaybillBody> GetBySitId(int sitId)
        {
            return _context.WaybillBodies
                .Where(x => x.SitId == sitId)
                .Include(x=>x.WaybillHeaders)
                .Include(x=>x.Status)
                .ToList();
        }
    }
}