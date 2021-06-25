using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class GenreDAO : GenericRepository<Genre>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var genre = context.GenreSet
                    .Include("Songs.Genres")
                    .SingleOrDefault(x => x.Id == (int)id);

                foreach (var song in genre.Songs)
                {
                    if (song.Genres.Count == 1)
                    {
                        return false;
                    }
                }
            }

            return base.Delete(id);
        }

        //==============================================================================================
        public List<Genre> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.GenreSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<Genre> GetFullList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.GenreSet
                    .Include("Subgenres")
                    .Include("Supergenre")
                    .ToList();
            }
        }

        public List<Song> GetSongsInGenre(int genreId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.GenreSet
                    .Include("Songs")
                    .SingleOrDefault(x => x.Id == genreId)
                    .Songs
                    .ToList();
            }
        }

        public List<Genre> GetSubgenres(int genreId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.GenreSet
                    .Include("Subgenres")
                    .SingleOrDefault(x => x.Id == genreId)
                    .Subgenres
                    .ToList();
            }
        }

        public Genre GetSupergenere(int genreId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.GenreSet
                    .Include("Supergenre")
                    .SingleOrDefault(x => x.Id == genreId)
                    .Supergenre;
            }
        }

        //==============================================================================================
        public override bool Insert(Genre genre)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                if (genre.Subgenres != null && genre.Subgenres.Count > 0)
                {
                    foreach (var subgenre in genre.Subgenres)
                    {
                        context.Entry(subgenre).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }

                if (genre.Supergenre != null)
                {
                    context.Entry(genre.Supergenre).State = System.Data.Entity.EntityState.Unchanged;
                }

                context.GenreSet.Add(genre);
                context.SaveChanges();
            }

            return true;
        }
    }
}
