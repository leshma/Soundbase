using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class PerformedDAO : GenericRepository<Performed>
    {
        //==========================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var performed = context.PerformedSet
                    .Include("Song")
                    .Include("Artist")
                    .Include("Created")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(performed).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==========================================================================================
        public List<Song> GetArtistSongs(int artistId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var songs = context.PerformedSet
                    .Include("Song")
                    .Where(x => x.ArtistId == artistId)
                    .Select(x => x.Song)
                    .ToList();

                return songs;
            }
        }

        //==========================================================================================
        public override bool Insert(Performed performed)
        {
            if (performed.Song == null && performed.SongId != 0)
            {
                return false;
            }

            return base.Insert(performed);
        }
    }
}
