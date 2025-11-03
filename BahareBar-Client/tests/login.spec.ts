import { test, expect } from '@playwright/test';

test('login page renders correctly after simplification', async ({ page }) => {
  await page.goto('http://localhost:5173/login');
  await expect(page.getByText('Login Page Test')).toBeVisible();
});
