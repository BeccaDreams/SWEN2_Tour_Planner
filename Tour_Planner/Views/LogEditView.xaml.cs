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
    /// Interaktionslogik für LogEditView.xaml
    /// </summary>
    public partial class LogEditView : Window
    {
        public LogEditView(TourLog log)
        {
            InitializeComponent();
            ((EditLogViewModel)this.DataContext).Id = log.Id;
            ((EditLogViewModel)this.DataContext).LogDate = log.LogDate.ToDateTime(TimeOnly.Parse("10:00 PM"));
            ((EditLogViewModel)this.DataContext).Comment = log.Comment;
            ((EditLogViewModel)this.DataContext).Rating = log.Rating;
            ((EditLogViewModel)this.DataContext).Difficulty = log.Difficulty;
            ((EditLogViewModel)this.DataContext).TotalTime = log.TotalTime;
        }
    }
}
