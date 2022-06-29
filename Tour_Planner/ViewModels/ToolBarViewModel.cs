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
        Tour_Planner_BL.ReportController _reportController;
        Tour _tour;


        public ICommand ExportFile { get; set; }
        public ICommand ImportFile { get; set; }
        //public ICommand TourReport { get; set; }
        //public ICommand SummarizeReport { get; set; }
        public ICommand OpenFaqWindow { get; set; }
        
        public ToolBarViewModel()
        {
            _tourController = new TourController();
            _reportController = new Tour_Planner_BL.ReportController();
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

        /*public void GenerateTourReport()
        {
            _reportController.GenerateTourReport(_tour);
        }

        public void GenerateSummarizeReport()
        {
            _reportController.GenerateSummarizeReport();
        }*/

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

            /*TourReport = new RelayCommand((_) =>
            {
                GenerateTourReport();
            });

            SummarizeReport = new RelayCommand((_) =>
            {
                GenerateSummarizeReport();
            });*/

            OpenFaqWindow = new RelayCommand((_) =>
            {
                Open_FaqWindow();

            });
        }
    }
}
