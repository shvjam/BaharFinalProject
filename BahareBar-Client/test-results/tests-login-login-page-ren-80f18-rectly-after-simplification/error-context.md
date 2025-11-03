# Page snapshot

```yaml
- generic [ref=e3]:
  - generic [ref=e4]: "[plugin:vite:import-analysis] Failed to resolve import \"@/services/auth\" from \"src/components/auth/AdminProtectedRoute.tsx\". Does the file exist?"
  - generic [ref=e5]: /app/BahareBar-Client/src/components/auth/AdminProtectedRoute.tsx:3:28
  - generic [ref=e6]: "1 | import { jsxDEV } from \"react/jsx-dev-runtime\"; 2 | import { Navigate, Outlet } from \"react-router-dom\"; 3 | import { authService } from \"@/services/auth\"; | ^ 4 | import { jwtDecode } from \"jwt-decode\"; 5 | const isAdmin = () => {"
  - generic [ref=e7]: at TransformPluginContext._formatLog (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:31106:43) at TransformPluginContext.error (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:31103:14) at normalizeUrl (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:29590:18) at process.processTicksAndRejections (node:internal/process/task_queues:105:5) at async file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:29648:32 at async Promise.all (index 2) at async TransformPluginContext.transform (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:29616:4) at async EnvironmentPluginContainer.transform (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:30905:14) at async loadAndTransform (file:///app/BahareBar-Client/node_modules/vite/dist/node/chunks/config.js:26043:26)
  - generic [ref=e8]:
    - text: Click outside, press Esc key, or fix the code to dismiss.
    - text: You can also disable this overlay by setting
    - code [ref=e9]: server.hmr.overlay
    - text: to
    - code [ref=e10]: "false"
    - text: in
    - code [ref=e11]: vite.config.js
    - text: .
```