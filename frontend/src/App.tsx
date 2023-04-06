import React, { useEffect, useState } from 'react';
import { ConfigProvider, Layout, theme } from 'antd';
import { DeptDashboard } from './page/department/dashboard';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Sidebar } from './components/layout/Sidebar';
import Login from './page/login';
import './App.css';
import { TeacherDashboard } from './page/teacher';
import { CreateTeacher } from './page/teacher/create';
import { StudentDashboard } from './page/student';
import { CreateNewStudent } from './page/student/Create';
import { PrivateRoute } from './components/Authenticated/PrivateRoute';
import { StilHere } from './components/Authenticated/StillHere';
const { Content, Footer } = Layout;

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const toggleSidebar = () => {
    setCollapsed(!collapsed);
  }
  useEffect(()=> 
  {
    StilHere();
  })
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  return (
    <ConfigProvider
    theme={{
      token: {
        colorPrimary: '#9d67d0',
        colorError : '#910c39',
        colorBgBase : '#efcfda',
        colorBgLayout: '#efcfda !important',
        colorBgContainer : '#f2e6ea',
        colorPrimaryText : '#7c1639',
        colorBgContainerDisabled : '#efcfda',
      },
    }}>
    <BrowserRouter>
      <Routes>
       
        <Route path='/*' element={<Layout style={{ minHeight: '100vh' }}>
          <Sidebar collapsed={collapsed} onToggleSidebar={toggleSidebar} />
          <Layout className="site-layout">
            <Content style={{ margin: '0 12px' }}>
              <div style={{ padding: 24, minHeight: 580, background: colorBgContainer }}>
                
                <Routes>  
                  <Route  element={<PrivateRoute roles={"Admin"} />}>
                  <Route path='/dashboard' element={<DeptDashboard />} />
                  <Route path='/listTeacher' element={<TeacherDashboard/>} />
                  <Route path='/addTeacher' element={<CreateTeacher/>}/>
                  <Route path='/listStudent' element={< StudentDashboard />}/>
                  <Route path='/addStudent' element={< CreateNewStudent />}/>
                  {/* Các Route khác nếu có */}
                  </Route>                            
                </Routes>
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>PQH ©2023</Footer>
          </Layout>        
        </Layout>}/>
        <Route path='/login' element={<Login />} />
      </Routes>
    </BrowserRouter>
  </ConfigProvider>
  );
};

export default App;
