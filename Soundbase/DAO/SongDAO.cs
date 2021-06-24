using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class SongDAO : GenericRepository<Song>
    {
        //==========================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var song = context.SongSet
                    .Include("OfficialVideo")
                    .Include("Performed")
                    .SingleOrDefault(x => x.Id == (int)id);

                if (song.Performed.Count > 0)
                {
                    return false;
                }

                if (song.OfficialVideo != null)
                {
                    return false;
                }
            }
            
            return base.Delete(id);
        }

        //==========================================================================================
        public List<Song> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.SongSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<Song> FindByDuration(int duration)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.SongSet
                    .Where(x => x.Duration == duration)
                    .ToList();
            }
        }

        //==========================================================================================
        public override bool Insert(Song song)
        {
            if (song.Genres == null || song.Genres.Count == 0)
            {
                return false;
            }

            if (song.Performed == null || song.Performed.Count == 0)
            {
                return false;
            }

            return base.Insert(song);
        }
    }
}
