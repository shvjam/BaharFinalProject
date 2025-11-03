// File: BahareBar-Api/Entities/Enums/OrderStatus.cs
namespace BahareBar_Api.Entities.Enums;

public enum OrderStatus
{
    Draft,                  // سفارش موقت ایجاد شده توسط کاربر مهمان
    PendingApproval,        // سفارش نهایی شده و منتظر تایید ادمین
    Approved,               // تایید شده توسط ادمین
    DriverAssigned,         // راننده تخصیص داده شد
    DriverEnRoute,          // راننده در مسیر
    Loading,                // در حال بارگیری
    EnRouteToDestination,   // در مسیر مقصد
    Unloading,              // در حال تخلیه
    Completed,              // تکمیل شده
    Canceled                // لغو شده
}
