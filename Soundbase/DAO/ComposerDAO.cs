using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class ComposerDAO : GenericRepository<Composer>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var composers = context.ComposerSet
                    .Include("Songs")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(composers).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==============================================================================================
        public List<Composer> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.ComposerSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        //==============================================================================================
        public void Compose(Composer composer, Song song)
        {
            composer.Songs.Add(song);
            Update(composer);
        }
    }
}
