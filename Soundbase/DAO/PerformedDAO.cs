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
                    .Include("Song.Performed")
                    .Include("Created.Performed")
                    .SingleOrDefault(x => x.Id == (int)id);

                foreach (var created in performed.Created)
                {
                    if (created.Performed.Count == 1)
                    {
                        return false;
                    }
                }

                if (performed.Song.Performed.Count == 1)
                {
                    return false;
                }
            }
            
            return base.Delete(id);
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
