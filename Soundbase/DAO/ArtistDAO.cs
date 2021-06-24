using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class ArtistDAO : GenericRepository<Artist>
    {
        //==============================================================================================
        public override bool Delete(object id)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var artist = context.ArtistSet
                    .Include("Bands.Artists")
                    .Include("Created")
                    .Include("Performed")
                    .SingleOrDefault(x => x.Id == (int)id);

                foreach (var band in artist.Bands)
                {
                    if (band.Artists.Count == 1)
                    {
                        return false;
                    }
                }

                if (artist.Created.Count > 0)
                    return false;

                if (artist.Performed.Count > 0)
                    return false;
            }

            return base.Delete(id);
        }

        //==============================================================================================
        public List<Artist> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.ArtistSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

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

        public List<Album> GetArtistAlbums(int artistId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var albums = context.CreatedSet
                    .Include("Album")
                    .Where(x => x.ArtistId == artistId)
                    .Select(x => x.Album)
                    .ToList();

                return albums;
            }
        }

        //==============================================================================================
        public void PerformASong(Artist artist, Song song)
        {
            artist.Performed.Add(new Performed
            {
                Song = song,
            });
            Update(artist);
        }

        public void CreateAnAlbum(List<Artist> artists, Album album, List<Performed> performedSongsOnAlbum)
        {
            var albumDAO = new AlbumDAO();
            albumDAO.Insert(album);

            foreach (var artist in artists)
            {
                artist.Created.Add(new Created
                {
                    AlbumId = album.Id,
                    Performed = performedSongsOnAlbum
                });
                Update(artist);
            }
        }

        public void SignALabel(Artist artist, RecordLabel recordLabel)
        {
            artist.RecordLabels.Add(recordLabel);
            Update(artist);
        }

        public void GoIntoABand(Artist artist, Band band)
        {
            artist.Bands.Add(band);
            Update(artist);
        }
    }
}
