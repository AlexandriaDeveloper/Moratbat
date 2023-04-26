using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Application.Services;
public interface INPOIService
{
    DataTable ReadFile(string filePath, string sheetName);
}
public class NPOIService : INPOIService
{
    IWorkbook _workbook;
    // HSSFFormulaEvaluator formula;
    ISheet _sheet;
    DataTable dt;
    public NPOIService()
    {

    }
    public DataTable ReadFile(string filePath, string sheetName)
    {

        if (_workbook == null)
        {
            _workbook = WorkbookFactory.Create(filePath);
            //  formula = new HSSFFormulaEvaluator(_workbook);
        }



        ISheet sheet = _workbook.GetSheet(sheetName);

        if (dt == null)
        {
            dt = new DataTable();
            CreateTableHeader(sheet);
        }

        SheetToDataTable(sheet);

        return dt;
    }

    private void CreateTableHeader(ISheet sheet)
    {


        IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
        for (int i = 0; i < headerRow.LastCellNum; i++)
        {
            ICell headerCell = headerRow.GetCell(i);

            // int colIndex = headerCell.ColumnIndex;
            if (headerCell == null)
            {
                headerCell = headerRow.CreateCell(i);
                headerCell.SetCellValue("Blank_" + i);
            }
            if (headerCell.CellType == CellType.String)
                dt.Columns.Add(headerCell.StringCellValue.Trim());
            if (headerCell.CellType == CellType.Numeric)
                dt.Columns.Add(headerCell.NumericCellValue.ToString().Trim());
        }
        //return dt;

    }

    private DataTable SheetToDataTable(ISheet sheet)
    {

        if (dt == null)
        {
            dt = new DataTable();
        }
        int rowIndex = 0;
        foreach (IRow row in sheet)
        {
            // skip header row 
            if (rowIndex++ == 0) continue;
            DataRow dataRow = dt.NewRow();

            for (int i = 0; i < row.LastCellNum; i++)
            {

                var currentCell = row.GetCell(i);
                if (currentCell == null)
                {
                    currentCell = row.CreateCell(i);
                }
                else
                {
                    //      formula.EvaluateInCell(currentCell);
                    switch (currentCell.CellType)
                    {
                        case CellType.Formula:
                            dataRow[i] = currentCell.ToString();
                            break;
                        case CellType.String:
                            dataRow[i] = currentCell.ToString();
                            break;
                        case CellType.Numeric:
                            dataRow[i] = currentCell.NumericCellValue;
                            break;
                        case CellType.Boolean:
                            dataRow[i] = currentCell.BooleanCellValue;
                            break;
                        default:
                            // dataRow[i] = currentCell.ToString();
                            break;
                    }

                }
            }

            dt.Rows.Add(dataRow);
        }
        return dt;
    }
}