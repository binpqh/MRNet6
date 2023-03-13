import { Route, Routes } from 'react-router-dom'
import { DeptDashboard } from '../page/department/dashboard'

export const DeptRouter = () => {
  return (
    <Routes>
        <Route path ="/dept" element={<DeptDashboard/>} />
    </Routes>
  )
}