using System.Drawing.Printing;

namespace PrintToPrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string filePath { get; private set; }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Read text from the file
            string text = File.ReadAllText(filePath);

            // Choose font
            Font font = new Font("Arial", 12);

            // Define print area
            RectangleF area = new RectangleF(
                e.MarginBounds.Left,
                e.MarginBounds.Top,
                e.MarginBounds.Width,
                e.MarginBounds.Height
            );

            // Debug check
            MessageBox.Show("About to send to printer!");

            // Print the text
            if (e.Graphics != null)
            {
                e.Graphics.DrawString(text, font, Brushes.Black, area);
            }

            // theres only one page
            e.HasMorePages = false;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            // Let the user pick a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                // Force A4 size if needed
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

                // Explicitly attach the event handler
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings = printDialog.PrinterSettings;

                    try
                    {
                        printDocument1.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error printing: " + ex.Message);
                    }
                    finally
                    {
                        //Detach handler so multiple clicks don’t duplicate it
                        printDocument1.PrintPage -= new PrintPageEventHandler(printDocument1_PrintPage);
                    }
                }
            }
        }
    }
}
