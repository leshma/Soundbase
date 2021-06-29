using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class RecordLabelDAO : GenericRepository<RecordLabel>
    {
        //==========================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var recordLabel = context.RecordLabelSet
                    .Include("Artists")
                    .Include("Bands")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(recordLabel).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==========================================================================================
        public List<RecordLabel> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.RecordLabelSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }
    }
}
