// File: BahareBar-Api/DTOs/OrderSummaryDto.cs
namespace BahareBar_Api.DTOs;

public class OrderSummaryDto
{
    public Guid Id { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
}
