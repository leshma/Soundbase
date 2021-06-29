using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class CreatedDAO : GenericRepository<Created>
    {
        //==========================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var created = context.CreatedSet
                    .Include("Album")
                    .Include("Artist")
                    .Include("Performed")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(created).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==========================================================================================
        public List<Song> GetSongsForAlbum(int albumId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var songs = context.CreatedSet
                    .Include("Performed.Song")
                    .SingleOrDefault(x => x.AlbumId == albumId)
                    .Performed
                    .Select(x => x.Song)
                    .ToList();

                return songs;
            }
        }

        //==========================================================================================
        public override bool Insert(Created created)
        {
            if (created.Album == null && created.AlbumId != 0)
            {
                return false;
            }

            if (created.Artist == null && created.ArtistId != 0)
            {
                return false;
            }

            using (var context = new ModelSoundbaseContainer())
            {
                context.Entry(created.Album).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(created.Artist).State = System.Data.Entity.EntityState.Unchanged;
                context.CreatedSet.Add(created);
                context.SaveChanges();
            }

            return true;
        }
    }
}
