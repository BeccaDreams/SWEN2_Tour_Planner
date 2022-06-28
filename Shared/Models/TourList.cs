using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TourList : BaseModel
    {
        private Dictionary<int, string> _tourDictionary { get; set; }
        private List<Tour> _list;
        public TourList(List<Tour> tours)
        {
            _tourDictionary = new Dictionary<int, string>();
            foreach(var item in tours)
            {
                _tourDictionary.Add(item.Id, item.Name);
            }

        }


    }
}
