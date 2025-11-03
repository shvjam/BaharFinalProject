// File: BahareBar-Client/src/layouts/AdminLayout.tsx
import { Outlet } from 'react-router-dom';
import { AdminSidebar } from '@/components/AdminSidebar';

export function AdminLayout() {
    return (
        <div className="flex" dir="rtl">
            <AdminSidebar />
            <main className="flex-1 p-8 bg-background">
                <Outlet />
            </main>
        </div>
    );
}
