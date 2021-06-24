using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO.Base
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public GenericRepository() { }

        public virtual bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                TEntity entityToDelete = context.Set<TEntity>().Find(id);
                context.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return true;
        }

        public virtual TEntity FindById(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual List<TEntity> GetList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual bool Insert(TEntity entity)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }

            return true;
        }

        public virtual bool Update(TEntity entity)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

            return true;
        }
    }
}
