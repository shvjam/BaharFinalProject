// File: BahareBar-Api/DTOs/SendOtpRequest.cs
using System.ComponentModel.DataAnnotations;

namespace BahareBar_Api.DTOs;

public class SendOtpRequest
{
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}
