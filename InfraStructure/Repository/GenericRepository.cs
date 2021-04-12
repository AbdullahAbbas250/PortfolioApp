using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfraStructure.Repository
{
    public class GenericRepository<Type> : IGenericRepository<Type> where Type : class
    {
        private readonly DataContext _context;
        private DbSet<Type> table = null;

        public GenericRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<Type>();
        }
        public void Delete(Type Entity)
        {
            Type exist = GetById(Entity);
            table.Remove(exist);

        }

        public IEnumerable<Type> GetAll()
        {
            return table.ToList();
        }

        public Type GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(Type Entity)
        {
            table.Add(Entity);
        }

        public void Update(Type Entity)
        {
            table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
