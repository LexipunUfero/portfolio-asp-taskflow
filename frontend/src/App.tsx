import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './App.css'
import MainLayout from './ui/layouts/mainLayout/mainLayout'
import OverviewPage from './ui/pages/overviewPage'
import ProjectPage from './ui/pages/projectPage/projectPage'
import ProjectManagementPage from './ui/pages/projectManagementPage/projectManagementPage'
import NotFoundPage from './ui/pages/notFoundPage/notFoundPage'
import InvitePage from './ui/pages/InvitePage/invitePage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* публичные */}
        <Route element={<MainLayout />}>
          <Route path="/" element={<OverviewPage />} />
          <Route
            path="/project/:projectId/task/:taskId"
            element={<ProjectPage />}
          />
          <Route path="/project/:projectId" element={<ProjectPage />} />
          <Route
            path="/project/management/:projectId"
            element={<ProjectManagementPage />}
          />
          <Route path="/Invite/:id" element={<InvitePage />} />

          <Route path="*" element={<NotFoundPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
