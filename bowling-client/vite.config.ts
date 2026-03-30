import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    // Proxy /api requests to the ASP.NET backend during development so
    // the React dev server and the API run on different ports without CORS issues.
    proxy: {
      '/api': {
        target: 'http://localhost:5205',
        changeOrigin: true,
      },
    },
  },
})
