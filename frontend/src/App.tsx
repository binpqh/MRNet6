import React, { useState } from 'react';
import { ConfigProvider, Layout, theme } from 'antd';
import { DeptDashboard } from './page/department/dashboard';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Sidebar } from './components/layout/Sidebar';
import Login from './page/login';
import './App.css';
const { Content, Footer } = Layout;

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const toggleSidebar = () => {
    setCollapsed(!collapsed);
  }
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
        <Route path='/login' element={<Login />} />
        <Route path='/*' element={<Layout style={{ minHeight: '100vh' }}>
          <Sidebar collapsed={collapsed} onToggleSidebar={toggleSidebar} />
          <Layout className="site-layout">
            <Content style={{ margin: '0 12px' }}>
              <div style={{ padding: 24, minHeight: 580, background: colorBgContainer }}>
                <Routes>
                  <Route path='/' element={<DeptDashboard />} />
                  {/* Các Route khác nếu có */}
                </Routes>
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>PQH ©2023</Footer>
          </Layout>
        </Layout>} />
      </Routes>
    </BrowserRouter>
  </ConfigProvider>
  );
};

export default App;
