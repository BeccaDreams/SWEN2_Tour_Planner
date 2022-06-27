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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tour_Planner.Views;

namespace Tour_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        #if DEBUG
                    System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
        #endif
        }

        private void StackPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        //private void AddTourWin(object sender, RoutedEventArgs e)
        //{
        //    AddTourWindow win2 = new AddTourWindow();
        //    win2.Show();
        //}

        //private void CloseTourWin(object sender, RoutedEventArgs e)
        //{
        //    AddTourWindow win2 = new AddTourWindow();
        //    win2.Close();
        //}
    }
}
