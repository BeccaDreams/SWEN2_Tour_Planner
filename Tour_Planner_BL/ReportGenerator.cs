using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Shared.Models;
using System.Globalization;

namespace Tour_Planner_BL
{
    public class ReportGenerator
    {
        public ReportGenerator() 
        {
        }

        public void GenerateTourReport(Tour tour, List<TourLog> logs) 
        {
            var fileName = string.Format("reports/{0} - TourReport.pdf", tour.Name);
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            var Header = new Paragraph("Tour Report")
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(20)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(ColorConstants.GRAY);
            document.Add(Header);

            var tourTable = new Table(2, false)
                .SetMarginTop(20)
                .SetWidth(520);

            var cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Name"));
            var cell12 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.Name));

            var cell21 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Description"));
            var cell22 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.Description));

            var cell31 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("From"));
            var cell32 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.From));

            var cell41 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("To"));
            var cell42 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.To));

            var cell51 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Duration"));
            var cell52 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.Time.ToString()));

            var cell61 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Distance"));
            var cell62 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.Distance.ToString(CultureInfo.InvariantCulture)));

            var cell71 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Transport Type"));
            var cell72 = new Cell(1, 1)
               .SetPadding(5)
               .Add(new Paragraph(tour.TransportType));

            tourTable.AddCell(cell11);
            tourTable.AddCell(cell12);
            tourTable.AddCell(cell21);
            tourTable.AddCell(cell22);
            tourTable.AddCell(cell31);
            tourTable.AddCell(cell32);
            tourTable.AddCell(cell41);
            tourTable.AddCell(cell42);
            tourTable.AddCell(cell51);
            tourTable.AddCell(cell52);
            tourTable.AddCell(cell61);
            tourTable.AddCell(cell62);            
            tourTable.AddCell(cell71);
            tourTable.AddCell(cell72);
            document.Add(tourTable);

            var subHeader1 = new Paragraph("Map")
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(14)
                .SetBold()
                .SetMarginTop(20)
                .SetFontColor(ColorConstants.GRAY);

            document.Add(subHeader1);

            var imageData = ImageDataFactory.Create(tour.RouteInformation);
            document.Add(new Image(imageData));
            document.Add(new AreaBreak());

            var subHeader2 = new Paragraph("Logs")
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(14)
                .SetBold()
                .SetMarginTop(20)
                .SetFontColor(ColorConstants.GRAY);

            document.Add(subHeader2);

            var logTable = new Table(5, false)
                .SetMarginTop(5)
                .SetWidth(520);

            var logCell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Date"));

            var logCell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Comment"));

            var logCell13 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Difficulty"));

            var logCell14 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Rating"));

            var logCell15 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Total Time"));

            logTable.AddCell(logCell11);
            logTable.AddCell(logCell12);
            logTable.AddCell(logCell13);
            logTable.AddCell(logCell14);
            logTable.AddCell(logCell15);

            logs.ForEach(log => 
            {
                var logCell21 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(log.LogDate.ToString(CultureInfo.InvariantCulture)));
                var logCell22 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(log.Comment));
                var logCell23 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(log.Difficulty.ToString()));
                var logCell24 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(log.Rating.ToString()));
                var logCell25 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(log.TotalTime.ToString()));

                logTable.AddCell(logCell21);
                logTable.AddCell(logCell22);
                logTable.AddCell(logCell23);
                logTable.AddCell(logCell24);
                logTable.AddCell(logCell25);
            });

            document.Add(logTable);
            document.Close();
        }

        public void GenerateSummarizeReport(List<Tour> tours) 
        {
            var fileName = string.Format("reports/Summarize Report.pdf");
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            var Header = new Paragraph("Summarize Report")
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(20)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(ColorConstants.GRAY);

            document.Add(Header);

            var table = new Table(7, false)
                .SetMarginTop(20)
                .SetWidth(520);

            var cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Name"));

            var cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Description"));

            var cell13 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("From"));

            var cell14 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("To"));

            var cell15 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Transport Type"));

            var cell16 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Distance"));

            var cell17 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
               .SetPadding(5)
               .Add(new Paragraph("Duration"));

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);
            table.AddCell(cell16);
            table.AddCell(cell17);

            tours.ForEach(tour =>
            {
                var cell21 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.Name));
                
                var cell22 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.Description));                
                
                var cell23 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.From)); 
                
                var cell24 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.To));
                
                var cell25 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.TransportType)); 
                
                var cell26 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.Distance.ToString(CultureInfo.InvariantCulture)));
                
                var cell27 = new Cell(1, 1)
                    .SetPadding(5)
                    .Add(new Paragraph(tour.Time.ToString()));

                table.AddCell(cell21);
                table.AddCell(cell22);
                table.AddCell(cell23);
                table.AddCell(cell24);
                table.AddCell(cell25);
                table.AddCell(cell26);
                table.AddCell(cell27);
            });

            document.Add(table);
            document.Close();
        }
    }
}
