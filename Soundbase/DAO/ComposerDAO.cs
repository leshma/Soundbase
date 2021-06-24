﻿using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class ComposerDAO : GenericRepository<Composer>
    {
        //==============================================================================================
        public List<Composer> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.ComposerSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        //==============================================================================================
        public void Compose(Composer composer, Song song)
        {
            composer.Songs.Add(song);
            Update(composer);
        }
    }
}