// File: BahareBar-Client/src/services/api.ts
import axios from 'axios';
import { authService } from './auth';

const api = axios.create({
    baseURL: 'http://localhost:5080/api', // Adjust if your backend runs on a different port
    headers: {
        'Content-Type': 'application/json',
    },
});

// Request interceptor to add the auth token header to requests
api.interceptors.request.use(
    (config) => {
        const token = authService.getToken();
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default api;
