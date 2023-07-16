using System.Data;
using NPOI.SS.UserModel;
namespace Application.Services;

public class NPOIServiceReadEmployeeFinancialData
{
    IWorkbook _workbook;
    // HSSFFormulaEvaluator formula;
    ISheet _sheet;
    TablStructure dt = new TablStructure();
    public NPOIServiceReadEmployeeFinancialData()
    {

    }

    public DataTable ReadFile(string filePath, string sheetName)
    {
        throw new NotImplementedException();
    }

    public TablStructure ReadEmployeeBasicFinancialDataFile(string filePath, string sheetName)
    {

        if (_workbook == null)
        {
            _workbook = WorkbookFactory.Create(filePath);
            //  formula = new HSSFFormulaEvaluator(_workbook);
        }



        ISheet sheet = _workbook.GetSheet(sheetName);

        if (dt == null)
        {
            dt = new TablStructure();

        }
        return CreateTableHeader(sheet);

    }

    private TablStructure CreateTableHeader(ISheet sheet)
    {


        IRow financialSourceRow = sheet.GetRow(sheet.FirstRowNum);
        IRow startDateRow = sheet.GetRow(1);
        IRow accountTreeRow = sheet.GetRow(2);
        IRow accountTreeDetails = sheet.GetRow(3);

        for (int i = 2; i < financialSourceRow.LastCellNum; i++)
        {
            ICell headerCell = financialSourceRow.GetCell(i);

            // int colIndex = headerCell.ColumnIndex;
            if (headerCell == null)
            {
                // headerCell = headerRow.CreateCell(i);
                // headerCell.SetCellValue("Blank_" + i);
                return null;
            }
            if (headerCell.CellType == CellType.String && !string.IsNullOrEmpty(headerCell.StringCellValue))

            {
                DataByColumnHeader col = new();

                col.AccountTreeId = Convert.ToInt32(accountTreeRow.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim());
                col.AccountTreeDetailsId = Convert.ToInt32(accountTreeDetails.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim());
                col.colIndex = i;
                col.StartDate = Convert.ToDateTime(startDateRow.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim());
                col.FinancialSource = financialSourceRow.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim();
                col.Rows = SheetToDataTable(sheet, col);
                dt.Columns.Add(col);

            }


            // if (headerCell.CellType == CellType.Numeric)
            // dt.Columns.Add(headerCell.NumericCellValue.ToString().Trim());


        }
        return dt;

    }

    private List<DataRowItem> SheetToDataTable(ISheet sheet, DataByColumnHeader currentCol)
    {

        if (dt == null)
        {
            dt = new TablStructure();
        }
        int rowIndex = 0;
        List<DataRowItem> rows = new List<DataRowItem>();
        foreach (IRow rowNum in sheet)
        {
            // skip header row 
            if (rowIndex++ <= 3) continue;

            //
            DataRowItem row = new DataRowItem();


            try
            {


                row.EmployeeTegaraCode = sheet.GetRow(rowIndex - 1).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim().Trim();
                row.Amount = Convert.ToDecimal(sheet.GetRow(rowIndex - 1).GetCell(currentCol.colIndex, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString().Trim());
                rows.Add(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        return rows;
    }
}

public class TablStructure
{

    public List<DataByColumnHeader> Columns { get; set; } = new List<DataByColumnHeader>();
}

public class DataByColumnHeader
{

    public int colIndex { get; set; }
    public string FinancialSource { get; set; }
    public int AccountTreeDetailsId { get; set; }
    public int AccountTreeId { get; set; }
    public DateTime? StartDate { get; set; }
    public List<DataRowItem> Rows { get; set; } = new List<DataRowItem>();
}

public class DataRowItem
{
    public string EmployeeTegaraCode { get; set; }
    public decimal Amount { get; set; }
}