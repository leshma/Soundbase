using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class EngineerDAO : GenericRepository<Engineer>
    {
        //==============================================================================================
        public List<Engineer> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.EngineerSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<RecordingEngineer> FindRecordingEngineersByStudioName(string studioName)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = studioName.ToLower();
                return context.EngineerSet
                    .OfType<RecordingEngineer>()
                    .Where(x => x.StudioName.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<MixingEngineer> FindMixingEngineersByAwards(string awards)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = awards.ToLower();
                return context.EngineerSet
                    .OfType<MixingEngineer>()
                    .Where(x => x.Awards.ToLower() == lowercasedName)
                    .ToList();
            }
        }

        public List<MixingEngineer> GetMixingEngineersList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.EngineerSet.OfType<MixingEngineer>().ToList();
            }
        }

        public List<RecordingEngineer> GetRecordingEngineersList()
        {
            using (var context = new ModelSoundbaseContainer())
            {
                return context.EngineerSet.OfType<RecordingEngineer>().ToList();
            }
        }
    }
}
