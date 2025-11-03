// File: BahareBar-Client/src/components/AdminSidebar.tsx
import { NavLink } from 'react-router-dom';
import { Button } from '@/components/ui/button';
import { LayoutDashboard, Package, Users, Truck } from 'lucide-react';

const navItems = [
    { to: '/admin/dashboard', icon: LayoutDashboard, label: 'داشبورد' },
    { to: '/admin/orders', icon: Package, label: 'مدیریت سفارشات' },
    { to: '/admin/users', icon: Users, label: 'مدیریت کاربران' },
    { to: '/admin/services', icon: Truck, label: 'مدیریت خدمات' },
];

export function AdminSidebar() {
    return (
        <aside className="w-64 h-screen p-4 border-l bg-gray-50 dark:bg-gray-800">
            <h2 className="text-xl font-bold mb-6">پنل مدیریت بهار</h2>
            <nav className="flex flex-col gap-2">
                {navItems.map((item) => (
                    <NavLink
                        key={item.to}
                        to={item.to}
                        className={({ isActive }) =>
                            `flex items-center gap-3 rounded-lg px-3 py-2 transition-all hover:text-primary ${
                                isActive ? 'bg-muted text-primary' : 'text-muted-foreground'
                            }`
                        }
                    >
                        <item.icon className="h-4 w-4" />
                        {item.label}
                    </NavLink>
                ))}
            </nav>
        </aside>
    );
}
