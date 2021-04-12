using Core.Interfaces;
using InfraStructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.UnitOfWork
{
    public class UnitOfWork<Type> : IUnitOfWork<Type> where Type : class
    {
        private readonly DataContext _context;
        private IGenericRepository<Type> _entity; 

        public UnitOfWork(DataContext context)
        {
            _context = context;
        } 
        public IGenericRepository<Type> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<Type>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
