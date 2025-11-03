// File: BahareBar-Client/src/services/api.ts
import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5080/api', // Adjust if your backend runs on a different port
    headers: {
        'Content-Type': 'application/json',
    },
});

export default api;
