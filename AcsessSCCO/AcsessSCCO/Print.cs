using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace AcsessSCCO
{
    static class Print
    {
        public static void ExportToExcel(DataGridView dgwToExport)
        {
            try
            {

                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 15;
                int i = 1;
                int j = 0;
                foreach (DataGridViewColumn col in dgwToExport.Columns)
                {

                    if (col.Visible)
                        ExcelApp.Cells[1, ++j] = col.HeaderText;
                }


                foreach (DataGridViewRow row in dgwToExport.Rows)
                {
                    i++;
                    j = 0;

                    foreach (DataGridViewColumn col in dgwToExport.Columns)
                    {
                        if (col.Visible)
                        {
                            j++;
                            ExcelApp.Cells[i, j] = row.Cells[col.Index].FormattedValue.ToString().Replace("\r\n", " ");
                        }
                    }

                }
                ExcelApp.Visible = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void ExportToWord(DataGridView dgwToExport)
        {
            try
            {
                Word.Application wordapp;
                wordapp = new Word.Application();
                wordapp.Visible = true;
                //Object filename = PathDirDoc;
                Object confirmConversions = Type.Missing;
                Object readOnly = Type.Missing;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;

                wordapp.Documents.Add();

                Word.Document document = wordapp.Application.ActiveDocument;


                wordapp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                wordapp.Selection.PageSetup.LeftMargin = wordapp.CentimetersToPoints((float)1.0);
                Object unit = Word.WdUnits.wdStory;
                Object extend = Word.WdMovementType.wdMove;
                wordapp.Selection.HomeKey(ref unit, ref extend);
                Word.Find fnd = wordapp.Selection.Find;
                Object findText = "";
                object oEndOfDoc = "\\endofdoc";

                Word.Range range = document.Bookmarks.get_Item(oEndOfDoc).Range;


                range = document.Bookmarks.get_Item(oEndOfDoc).Range;
                Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
                Word.Table table = document.Tables.Add(range, 1, 1, defaultTableBehavior, autoFitBehavior);
                table.Rows.Add();
                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                foreach (DataGridViewColumn col in dgwToExport.Columns)
                {
                    if (col.Visible)
                    {
                        table.Columns.Add();
                        table.Columns[table.Columns.Count - 1].Width = 70;
                        table.Rows[1].Cells[table.Columns.Count - 1].Range.Font.Size = 8;
                        table.Rows[1].Cells[table.Columns.Count - 1].Range.Font.Bold = 1;
                        table.Rows[1].Cells[table.Columns.Count - 1].Range.Text = col.HeaderText;
                        //table.Rows[1].Cells[table.Columns.Count - 1].Range.Orientation = Word.WdTextOrientation.wdTextOrientationVertical;
                    }
                }
                table.Columns[table.Columns.Count].Delete();

                int i = 1;
                int j = 0;
                foreach (DataGridViewRow row in dgwToExport.Rows)
                {
                    i++;
                    j = 0;
                    table.Rows.Add();
                    foreach (DataGridViewColumn col in dgwToExport.Columns)
                    {
                        if (col.Visible)
                        {
                            j++;
                            table.Rows[i].Cells[j].Range.Font.Size = 8;
                            table.Rows[i].Cells[j].Range.Font.Bold = 0;
                            table.Rows[i].Cells[j].Range.Text = row.Cells[col.Index].FormattedValue.ToString();
                        }
                    }
                }
                table.Rows[table.Rows.Count].Delete();
                table.AllowAutoFit = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

    }
}
