using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class OfficialVideoDAO : GenericRepository<OfficialVideo>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var officialVideo = context.OfficialVideoSet
                    .Include("Song")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(officialVideo).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==============================================================================================
        public List<OfficialVideo> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.OfficialVideoSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<OfficialVideo> FindByFormat(string format)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedFormat = format.ToLower();
                return context.OfficialVideoSet
                    .Where(x => x.Format.ToLower() == lowercasedFormat)
                    .ToList();
            }
        }

        public List<OfficialVideo> GetFullList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.OfficialVideoSet
                    .Include("Song")
                    .ToList();
            }
        }

        //==============================================================================================
        public override bool Insert(OfficialVideo officialVideo)
        {
            if (officialVideo.Song == null && officialVideo.SongId == 0)
            {
                return false;
            }

            using (var context = new ModelSoundbaseContainer())
            {
                context.Entry(officialVideo.Song).State = System.Data.Entity.EntityState.Unchanged;
                context.OfficialVideoSet.Add(officialVideo);
                context.SaveChanges();
            }

            return true;
        }
    }
}
