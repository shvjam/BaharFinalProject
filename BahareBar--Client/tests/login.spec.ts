import { test, expect } from '@playwright/test';

test('login page renders correctly', async ({ page }) => {
  await page.goto('http://localhost:5173/login');
  await expect(page.getByText('برای ورود یا ثبت‌نام، شماره موبایل خود را وارد کنید.')).toBeVisible();
});
