using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO.Base
{
    public interface IRepository<TEntity>
    {
        TEntity FindById(object id);

        List<TEntity> GetList();

        bool Insert(TEntity entity);

        bool Delete(object id);

        bool Update(TEntity entity);
    }
}
