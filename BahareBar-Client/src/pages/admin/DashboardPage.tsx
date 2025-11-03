// File: BahareBar-Client/src/pages/admin/DashboardPage.tsx
import { useEffect, useState } from 'react';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import api from '@/services/api';

interface DashboardStats {
    totalUsers: number;
    totalOrders: number;
    totalRevenue: number;
}

interface OrderSummary {
    id: string;
    customerPhoneNumber: string;
    orderDate: string;
    totalPrice: number;
    status: string;
}

export function DashboardPage() {
    const [stats, setStats] = useState<DashboardStats | null>(null);
    const [recentOrders, setRecentOrders] = useState<OrderSummary[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                const [statsResponse, ordersResponse] = await Promise.all([
                    api.get('/admin/dashboard-stats'),
                    api.get('/admin/recent-orders'),
                ]);
                setStats(statsResponse.data);
                setRecentOrders(ordersResponse.data);
            } catch (error) {
                console.error("Failed to fetch dashboard data:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    if (loading) {
        return <div>در حال بارگذاری اطلاعات...</div>;
    }

    return (
        <div className="flex flex-col gap-8">
            <h1 className="text-3xl font-bold">داشبورد</h1>
            <div className="grid gap-4 md:grid-cols-3">
                <Card>
                    <CardHeader>
                        <CardTitle>مجموع کاربران</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <p className="text-2xl font-bold">{stats?.totalUsers ?? '...'}</p>
                    </CardContent>
                </Card>
                <Card>
                    <CardHeader>
                        <CardTitle>مجموع سفارشات</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <p className="text-2xl font-bold">{stats?.totalOrders ?? '...'}</p>
                    </CardContent>
                </Card>
                <Card>
                    <CardHeader>
                        <CardTitle>درآمد کل (تومان)</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <p className="text-2xl font-bold">{stats?.totalRevenue.toLocaleString() ?? '...'}</p>
                    </CardContent>
                </Card>
            </div>
            <div>
                <h2 className="text-2xl font-bold mb-4">۱۰ سفارش اخیر</h2>
                <Card>
                    <Table>
                        <TableHeader>
                            <TableRow>
                                <TableHead>شناسه سفارش</TableHead>
                                <TableHead>مشتری</TableHead>
                                <TableHead>تاریخ</TableHead>
                                <TableHead>مبلغ کل</TableHead>
                                <TableHead>وضعیت</TableHead>
                            </TableRow>
                        </TableHeader>
                        <TableBody>
                            {recentOrders.map((order) => (
                                <TableRow key={order.id}>
                                    <TableCell className="font-medium">{order.id.substring(0, 8)}</TableCell>
                                    <TableCell>{order.customerPhoneNumber}</TableCell>
                                    <TableCell>{new Date(order.orderDate).toLocaleDateString('fa-IR')}</TableCell>
                                    <TableCell>{order.totalPrice.toLocaleString()}</TableCell>
                                    <TableCell>{order.status}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Card>
            </div>
        </div>
    );
}
