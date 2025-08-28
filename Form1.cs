using System.Drawing.Printing;

namespace PrintToPrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Path to a file you want to print
            string filePath = @"C:\Users\keaga\Downloads\new1.txt";

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

            // Print the text
            e.Graphics.DrawString(text, font, Brushes.Black, area);

            // Tell the printer there’s only one page
            e.HasMorePages = false;

        }

        private void Print_Click(object sender, EventArgs e)
        {
            // Attach event handler
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // Show print dialog
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog.PrinterSettings;
                printDocument1.Print();
            }
        }
    }
}
