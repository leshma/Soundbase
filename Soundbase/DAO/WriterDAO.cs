using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class WriterDAO : GenericRepository<Writer>
    {
        //==========================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var writer = context.WriterSet
                    .Include("Songs")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(writer).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
