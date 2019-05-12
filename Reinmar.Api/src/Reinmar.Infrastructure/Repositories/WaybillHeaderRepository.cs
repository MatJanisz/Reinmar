using System;
using System.Collections.Generic;
using System.Linq;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class WaybillHeaderRepository : IWaybillHeaderRepository
    {
        private ReinmarDbContext _context;
        public WaybillHeaderRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(WaybillHeader entity)
        {
            _context.WaybillHeaders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(WaybillHeader entity)
        {
            _context.WaybillHeaders.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(WaybillHeader entity)
        {
            _context.WaybillHeaders.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<WaybillHeader> GetAll()
        {
            return _context.WaybillHeaders.ToList();
        }

        public WaybillHeader GetById(Guid id)
        {
            return _context.WaybillHeaders.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        public WaybillHeader GetBySitId(int sitId)
        {
            return _context.WaybillHeaders
                .FirstOrDefault(x => x.SitId == sitId);
        }
    }
}