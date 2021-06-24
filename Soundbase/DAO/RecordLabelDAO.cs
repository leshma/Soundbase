using Soundbase.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundbase.DAO
{
    public class RecordLabelDAO : GenericRepository<RecordLabel>
    {
        //==========================================================================================
        public List<RecordLabel> FindByName(string name)
        {
            using (var context = new ModelSoundbaseContainer())
            {
                var lowercasedName = name.ToLower();
                return context.RecordLabelSet
                    .Where(x => x.Name.ToLower() == lowercasedName)
                    .ToList();
            }
        }
    }
}
