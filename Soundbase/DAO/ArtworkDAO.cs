using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class ArtworkDAO : GenericRepository<Artwork>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var artwork = context.ArtworkSet
                    .Include("Album")
                    .SingleOrDefault(x => x.Id == (int)id);

                context.Entry(artwork).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        //==============================================================================================
        public List<Artwork> FindByArtworkArtistName(string artworkArtistName)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = artworkArtistName.ToLower();
                return context.ArtworkSet
                    .Where(x => x.Artist.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<Artwork> FindByFormat(string format)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedFormat = format.ToLower();
                return context.ArtworkSet
                    .Where(x => x.Format.ToLower() == lowercasedFormat)
                    .ToList();
            }
        }

        public override List<Artwork> GetList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.ArtworkSet
                    .Include("Album")
                    .ToList();
            }
        }

        //==============================================================================================
        public override bool Insert(Artwork artwork)
        {
            if (artwork.Album == null)
            {
                return false;
            }

            using (var context = new ModelSoundbaseContainer())
            {
                context.Entry(artwork.Album).State = System.Data.Entity.EntityState.Unchanged;
                context.ArtworkSet.Add(artwork);
                context.SaveChanges();
            }

            return true;
        }
    }
}
