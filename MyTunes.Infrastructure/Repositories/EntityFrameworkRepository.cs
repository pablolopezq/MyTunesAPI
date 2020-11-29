using System;
using System.Collections.Generic;
using System.Text;
using MyTunes.Core.Interfaces;
using MyTunes.Core.Entities;
using System.Linq.Expressions;
using System.Linq;

namespace MyTunes.Infrastructure.Repositories
{
    class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyTunesDbContext _myTunesDbContext;

        public EntityFrameworkRepository(MyTunesDbContext myTunesDbContext)
        {
            _myTunesDbContext = myTunesDbContext;
        }

        public T Create(T t)
        {
            _myTunesDbContext.Add(t);
            _myTunesDbContext.SaveChanges();
            return t;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _myTunesDbContext.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _myTunesDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _myTunesDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Update(T t)
        {
            T updated = _myTunesDbContext.Update(t).Entity;
            _myTunesDbContext.SaveChanges();
            return updated;
        }
    }
}
