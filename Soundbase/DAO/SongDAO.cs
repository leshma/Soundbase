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
                    .Include("Composers")
                    .Include("Genres")
                    .Include("Engineers")
                    .Include("Writers")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(song).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
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

        public List<Song> GetFullList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.SongSet
                    .Include("Composers")
                    .Include("Genres")
                    .Include("Writers")
                    .Include("OfficialVideo")
                    .Include("Engineers")
                    .Include("Performed")
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

            using (var context = new ModelSoundbaseContainer())
            {
                if (song.Composers != null && song.Composers.Count > 0)
                {
                    foreach (var item in song.Composers)
                    {
                        context.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }

                if (song.Engineers != null && song.Engineers.Count > 0)
                {
                    foreach (var item in song.Engineers)
                    {
                        context.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }

                if (song.Writers != null && song.Writers.Count > 0)
                {
                    foreach (var item in song.Writers)
                    {
                        context.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }

                if (song.Genres != null && song.Genres.Count > 0)
                {
                    foreach (var item in song.Genres)
                    {
                        context.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }

                context.SongSet.Add(song);
                context.SaveChanges();
            }

            return true;
        }
    }
}
