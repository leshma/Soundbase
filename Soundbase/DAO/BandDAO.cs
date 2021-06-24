using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class BandDAO : GenericRepository<Band>
    {
        //==============================================================================================
        public List<Band> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.BandSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<Artist> GetBandMembers(int bandId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.BandSet
                    .Include("Artists")
                    .SingleOrDefault(x => x.Id == bandId)
                    .Artists
                    .ToList();
            }
        }

        public List<RecordLabel> GetBandLabels(int bandId)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.BandSet
                    .Include("RecordLabels")
                    .SingleOrDefault(x => x.Id == bandId)
                    .RecordLabels
                    .ToList();
            }
        }

        //==============================================================================================
        public override bool Insert(Band band)
        {
            if (band.Artists == null || band.Artists.Count == 0)
            {
                return false;
            }

            return base.Insert(band);
        }

        //==============================================================================================
        public void ContractALabel(Band band, RecordLabel recordLabel)
        {
            band.RecordLabels.Add(recordLabel);
            Update(band);
        }

        public void AcquireAMember(Band band, Artist artist)
        {
            band.Artists.Add(artist);
            Update(band);
        }
    }
}
