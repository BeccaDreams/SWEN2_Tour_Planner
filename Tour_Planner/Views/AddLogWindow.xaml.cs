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
    /// Interaktionslogik für AddLogWindow.xaml
    /// </summary>
    public partial class AddLogWindow : Window
    {
        public AddLogWindow(TourLogsViewModel viewModel)
        {
            InitializeComponent();
            ((AddLogToTourViewModel)this.DataContext).TourId = viewModel.SelectedTourId;
            ((AddLogToTourViewModel)this.DataContext).DataChanged += viewModel.List_DataChanged;
        }

        private void NumericOnly(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }


    }

   
}
