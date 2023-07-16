using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData
{
    public partial class UploadEmployeeBasicFinancialDataCommandHandler
    {
        public class FileUpload
        {
            public IFormFile File { get; set; }
        }


    }

    public class GetEmployeeAccountTreeAmountByAccountTreeIdDto
    {
        public int AccountId { get; set; }
        public decimal Amount => EmployeeAccountTreeDetails.Sum(x => x.Amount);
        public List<GetEmployeeAccountTreeAmountByAccountTreeData> EmployeeAccountTreeDetails { get; set; }

    }
    public partial class GetEmployeeAccountTreeAmountByAccountTreeData
    {
        int AccountTreeDetailsId { get; set; }
        public string AccountTreeDetailsName { get; set; }
        public decimal Amount { get; set; }
    }

    public class EmployeeDataInfoDto
    {
        public string EmployeeName { get; set; }
        public List<EmployeeDataDto> WazifiData { get; set; } = new List<EmployeeDataDto>();
        public decimal TotalAmount => WazifiData.Sum(x => x.Amount);

    }
    public class EmployeeDataDto
    {
        public int AccountTreeId { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class EmployeeBasicSallaryInfoDto
    {
        public EmployeeBasicSallaryInfoDto() { }
        List<Data> data = new List<Data>();

        public List<Data> SetQanon81(decimal? wazifi, decimal? mokamel, decimal? tawidi)
        {
            if (wazifi.HasValue)
                this.data.Add(new Data { AccountTreeName = "الاجر الوظيفى", Amount = wazifi.Value });
            if (mokamel.HasValue)
                this.data.Add(new Data { AccountTreeName = "الاجر المكمل", Amount = mokamel.Value });
            if (tawidi.HasValue)
                this.data.Add(new Data { AccountTreeName = "الحافز التعويضى", Amount = tawidi.Value });
            return this.data;
        }

        public EmployeeBasicSallaryInfoDto SetQanon49(decimal? asasi, decimal? alwaat, decimal? badalat, decimal? others)
        {

            return this;
        }


        public class Data
        {

            public string AccountTreeName { get; set; }
            public decimal Amount { get; set; }
        }


        public class EmployeeBasicFinancialDataDto
        {
            public int EmployeeId { get; set; }
            public int AccountTreeDetailsId { get; set; }
            public int AccountTreeDetailsAccountTreeId { get; set; }
            public FinancialSourceEnum? FinancialSource { get; set; }
            public DateTime StartDate { get; set; }
            public Decimal Amount { get; set; }
            public bool Repeat { get; set; }

        }

    }
}