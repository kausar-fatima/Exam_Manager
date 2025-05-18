using System.Data;
using System.Windows;
using ClosedXML.Excel;

namespace ExamManagementSystem.views.ClerkViews
{
    public partial class PreviewWindow : Window
    {
        private readonly bool isAttendancePreview;

        public PreviewWindow(string filePath, bool isSeatingPlan)
        {
            InitializeComponent();
            isAttendancePreview = !isSeatingPlan;

            if (isSeatingPlan)
            {
                LoadSeatingPreview(filePath);
            }
            else
            {
                LoadAttendencePreview(filePath);
            }
        }

        public void LoadSeatingPreview(string filePath)
        {
            try
            {
                using var workbook = new XLWorkbook(filePath);

                if (workbook.TryGetWorksheet("Seating Plan", out var seatingSheet))
                {
                    PlanPreviewGrid.ItemsSource = WorksheetToDataTable(seatingSheet).DefaultView;
                }
                else
                {
                    MessageBox.Show("Sheet 'Seating Plan' not found in the Excel file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seating plan preview: " + ex.Message);
            }
        }

        public void LoadAttendencePreview(string filePath)
        {
            try
            {
                using var workbook = new XLWorkbook(filePath);

                if (workbook.TryGetWorksheet("Attendance Sheet", out var attendenceSheet))
                {
                    PlanPreviewGrid.ItemsSource = WorksheetToDataTable(attendenceSheet).DefaultView;
                }
                else
                {
                    MessageBox.Show("Sheet 'Attendence Sheet' not found in the Excel file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance preview: " + ex.Message);
            }
        }

        private DataTable WorksheetToDataTable(IXLWorksheet worksheet)
        {
            var dataTable = new DataTable();

            var firstRow = worksheet.FirstRowUsed();
            if (firstRow == null) return dataTable;

            var existingHeaders = new HashSet<string>();
            foreach (var cell in firstRow.Cells())
            {
                var header = cell.GetString().Trim();
                if (string.IsNullOrWhiteSpace(header))
                    header = $"Column{cell.Address.ColumnNumber}";

                // Ensure uniqueness
                string uniqueHeader = header;
                int counter = 1;
                while (existingHeaders.Contains(uniqueHeader))
                {
                    uniqueHeader = $"{header}_{counter++}";
                }

                dataTable.Columns.Add(uniqueHeader);
                existingHeaders.Add(uniqueHeader);
            }

            // Add 'Signature' column if previewing attendance
            if (isAttendancePreview)
            {
                dataTable.Columns.Add("Signature");
            }

            // Add rows
            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                var dataRow = dataTable.NewRow();
                int i = 0;
                foreach (var cell in row.Cells(1, dataTable.Columns.Count - (isAttendancePreview ? 1 : 0)))
                {
                    dataRow[i++] = cell.Value.ToString();
                }

                // Leave Signature column blank
                if (isAttendancePreview)
                {
                    dataRow[dataTable.Columns.Count - 1] = string.Empty;
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

    }
}
