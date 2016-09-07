using HCRM.App.Behaviors;
using HCRM.App.Services;
using Prism.Events;
using System;
using System.Drawing;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps;

namespace HCRM.App.Views.CustomControls
{
    public class MyDocumentViewer : DocumentViewer
    {
        IEventAggregator _eventHandler;

        public IEventAggregator EventHandler
        {
            get
            {
                if (_eventHandler == null)
                {
                    _eventHandler = ApplicationService.Instance.GlobalEventAggregator;
                }
                return _eventHandler;
            }

            set
            {
                _eventHandler = value;
            }
        }

        protected override void OnPrintCommand()
        {
            // get a print dialog, defaulted to default printer and default printer's preferences.
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            printDialog.PrintTicket = printDialog.PrintQueue.DefaultPrintTicket;

            // get a reference to the FixedDocumentSequence for the viewer.
            FixedDocumentSequence docSeq = this.Document as FixedDocumentSequence;
            
            printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA5);

            // set the default page orientation based on the desired output.
            //printDialog.PrintTicket.PageOrientation = GetDesiredPageOrientation(docSeq);

            bool printResult = false;
            if (printDialog.ShowDialog() == true)
            {
                // set the print ticket for the document sequence and write it to the printer.
                docSeq.PrintTicket = printDialog.PrintTicket;

                XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(printDialog.PrintQueue);
                writer.WriteAsync(docSeq, printDialog.PrintTicket);
                printResult = true;
            }
            EventHandler.GetEvent<PrintResultEvent>().Publish(printResult);
        }
        private Visual PerformTransform(Visual v, PrintQueue pq)
        {
            ContainerVisual root = new ContainerVisual();
            const double inch = 96;

            // Set the margins.
            double xMargin = 1.25 * inch;
            double yMargin = 1 * inch;

            PrintTicket pt = pq.UserPrintTicket;
            Double printableWidth = pt.PageMediaSize.Width.Value;
            Double printableHeight = pt.PageMediaSize.Height.Value;

            Double xScale = (printableWidth - xMargin * 2) / printableWidth;
            Double yScale = (printableHeight - yMargin * 2) / printableHeight;

            root.Children.Add(v);
            root.Transform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);

            return root;
        }// end:PerformTransform()
    }
}