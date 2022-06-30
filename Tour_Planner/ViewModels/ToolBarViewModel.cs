using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Views;
using System.Collections.ObjectModel;
using Shared.Models;
using System.Windows;
using System.Windows.Input;
using Tour_Planner_BL.Controller;

namespace Tour_Planner.ViewModels
{
    public class ToolBarViewModel : BaseModel
    {
        Window win3;
        TourController _tourController;
        ReportController _reportController;
        Tour _tour;


        public ICommand ExportFile { get; set; }
        public ICommand ImportFile { get; set; }
        public ICommand OpenFaqWindow { get; set; }
        
        public ToolBarViewModel()
        {
            _tourController = new TourController();
            _reportController = new ReportController();
            SetCommands();
        }

        public void ExportTourFile()
        {
            _tourController.Controller_export();
        }

        public void ImportTourFile()
        {
            _tourController.Controller_import();
        }

        public void Open_FaqWindow()
        {
            this.win3 = new FaqWindow();
            win3.Show();
        }

        public void SetCommands()
        {
            ExportFile = new RelayCommand((_) =>
            {
                ExportTourFile();
            }); 
            
            ImportFile = new RelayCommand((_) =>
            {
                ImportTourFile();
            });

            OpenFaqWindow = new RelayCommand((_) =>
            {
                Open_FaqWindow();

            });
        }
    }
}
