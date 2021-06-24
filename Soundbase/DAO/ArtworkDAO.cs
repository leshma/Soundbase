﻿using Soundbase.DAO.Base;
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

        //==============================================================================================
        public override bool Insert(Artwork artwork)
        {
            if (artwork.Album == null)
            {
                return false;
            }

            return base.Insert(artwork);
        }
    }
}