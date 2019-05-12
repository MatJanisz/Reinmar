using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class WaybillRepository : IWaybillRepository
    {
        private ReinmarDbContext _context;
        public WaybillRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }       
        public void Add(Waybill entity)
        {
            _context.Waybills.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Waybill entity)
        {
            _context.Waybills.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Waybill entity)
        {
            _context.Waybills.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Waybill> GetAll()
        {
            return _context.Waybills.ToList();
        }

        public Waybill GetById(Guid id)
        {
            return _context.Waybills
                .Include("Header")
                .Include("Body")
                .Where(x=>x.Id.Equals(id))
                .FirstOrDefault();
        }

        public Waybill GetBySitId(int sitId)
        {
            return _context.Waybills
                .Include("Header")
                .Include("Body")
                .FirstOrDefault(x => x.Header.SitId == sitId);
        }
    }
}