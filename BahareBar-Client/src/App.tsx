// File: BahareBar-Client/src/App.tsx
import { Routes, Route } from 'react-router-dom';
import { LoginPage } from './pages/LoginPage';
import { HomePage } from './pages/HomePage';
import { AdminProtectedRoute } from './components/auth/AdminProtectedRoute';
import { AdminLayout } from './layouts/AdminLayout';
import { DashboardPage } from './pages/admin/DashboardPage';

function App() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route path="/" element={<HomePage />} />

      {/* Admin Routes */}
      <Route element={<AdminProtectedRoute />}>
        <Route element={<AdminLayout />}>
          <Route path="/admin/dashboard" element={<DashboardPage />} />
          {/* Add other admin routes here in the future, e.g., /admin/orders */}
        </Route>
      </Route>

    </Routes>
  );
}

export default App;
