using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tour_Planner.ViewModels;

namespace Tour_Planner.Views
{
    /// <summary>
    /// Interaktionslogik für TourEditView.xaml
    /// </summary>
    public partial class TourEditView : Window
    {
        public TourEditView(Tour tour)
        {
            InitializeComponent();
            ((EditTourViewModel)this.DataContext).Id = tour.Id;
            ((EditTourViewModel)this.DataContext).Name = tour.Name;
            ((EditTourViewModel)this.DataContext).Description = tour.Description;
            ((EditTourViewModel)this.DataContext).From = tour.From;
            ((EditTourViewModel)this.DataContext).To = tour.To;
            ((EditTourViewModel)this.DataContext).TransportType = tour.TransportType;
        }
    }
}
