// File: BahareBar-Api/Services/SeedService.cs
using BahareBar_Api.Data;
using BahareBar_Api.Entities;
using BahareBar_Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace BahareBar_Api.Services;

public class SeedService : ISeedService
{
    private readonly ApplicationDbContext _context;

    public SeedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedInitialDataAsync()
    {
        // فقط در صورتی داده‌ها را اضافه کن که جدولی مثل دسته‌بندی خدمات خالی باشد
        if (await _context.ServiceCategories.AnyAsync())
        {
            return; // دیتابیس قبلاً Seed شده است
        }

        // ایجاد دسته‌بندی‌های خدمات
        var serviceCategories = new List<ServiceCategory>
        {
            new() { Name = "نیروی کار" },
            new() { Name = "ماشین باربری" },
            new() { Name = "بسته‌بندی" }
        };
        await _context.ServiceCategories.AddRangeAsync(serviceCategories);

        // ایجاد دسته‌بندی‌های محصولات فیزیکی
        var productCategories = new List<ProductCategory>
        {
            new() { Name = "کارتن" },
            new() { Name = "لوازم بسته‌بندی" }
        };
        await _context.ProductCategories.AddRangeAsync(productCategories);

        // ایجاد یک کاربر ادمین اولیه
        var adminUser = new User
        {
            PhoneNumber = "09120000000", // شماره موبایل ادمین
            FirstName = "ادمین",
            LastName = "سیستم",
            Role = UserRole.Admin,
            IsActive = true
        };
        await _context.Users.AddAsync(adminUser);

        // ذخیره تمام تغییرات در دیتابیس
        await _context.SaveChangesAsync();
    }
}
