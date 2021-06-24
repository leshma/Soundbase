using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class AlbumDAO : GenericRepository<Album>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var album = context.AlbumSet
                    .Include("Artwork")
                    .Include("Created")
                    .SingleOrDefault(x => x.Id == (int)id);

                if (album.Artwork != null)
                    return false;

                if (album.Created.Count > 0)
                    return false;
            }

            return base.Delete(id);
        }

        //==============================================================================================
        public List<Album> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.AlbumSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<Album> FindByYear(int year)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.AlbumSet
                    .Where(x => x.Year == year)
                    .ToList();
            }
        }

        public List<Album> FindWithArtwork()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.AlbumSet
                    .Include("Artwork")
                    .Where(x => x.Artwork != null)
                    .ToList();
            }
        }

        public Artwork GetAlbumArtwork(int albumId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.AlbumSet
                    .Include("Artwork")
                    .SingleOrDefault(x => x.Id == albumId)
                    .Artwork;
            }
        }

        public List<Artist> GetArtistsOfAlbum(int albumId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var creators = context.AlbumSet
                    .Include("Created")
                    .SingleOrDefault(x => x.Id == albumId)
                    .Created
                    .ToList();

                return context.CreatedSet
                    .Include("Artist")
                    .Where(x => creators.Any(y => y.ArtistId == x.ArtistId))
                    .Select(x => x.Artist)
                    .ToList();
            }
        }

        //==============================================================================================
        public override bool Insert(Album album)
        {
            //if (album.Created == null || album.Created.Count == 0)
            //{
            //    return false;
            //}

            return base.Insert(album);
        }
    }
}
