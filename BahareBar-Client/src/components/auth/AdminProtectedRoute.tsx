// File: BahareBar-Client/src/components/auth/AdminProtectedRoute.tsx
import { Navigate, Outlet } from 'react-router-dom';
import { authService } from '@/services/auth';
import { jwtDecode } from 'jwt-decode';

interface JwtPayload {
    role: string;
    exp: number;
}

const isAdmin = () => {
    const token = authService.getToken();
    if (!token) {
        return false;
    }

    try {
        const decodedToken = jwtDecode<JwtPayload>(token);
        // Check if token is expired
        if (decodedToken.exp * 1000 < Date.now()) {
            authService.removeToken();
            return false;
        }
        // Check for Admin role claim
        return decodedToken.role === 'Admin';
    } catch (error) {
        console.error("Invalid token:", error);
        authService.removeToken();
        return false;
    }
};

export const AdminProtectedRoute = () => {
    return isAdmin() ? <Outlet /> : <Navigate to="/login" />;
};
