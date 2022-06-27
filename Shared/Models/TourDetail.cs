using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TourDetail : BaseModel
    {
        private string Title
        {
            get => this.Title;
            set
            {
                this.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public TourDetail(string title)
        {
            Title = title;
        }

     
    }
}
