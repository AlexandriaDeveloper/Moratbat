namespace Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;

public class EmployeePartTimeDto
{
    public int? Id { get; set; }
    public int EmployeeId { get; set; }
    public string? Details { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool? InPartTime { get; set; }

}

