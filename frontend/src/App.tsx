import React, { useState } from 'react';
import { Layout, theme } from 'antd';
import { DeptDashboard } from './page/department/dashboard';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Sidebar } from './components/layout/Sidebar';

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
    <BrowserRouter>
    <Layout style={{ minHeight: '100vh' }}>
      <Sidebar collapsed = {collapsed} onToggleSidebar={toggleSidebar}/>
      <Layout className="site-layout">
        <Content style={{ margin: '0 12px' }}>
          <div style={{ padding: 24, minHeight: 580, background: colorBgContainer }}>
            <Routes>
              <Route path= "/" element = {<DeptDashboard/>}/>
            </Routes>
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>PQH ©2023</Footer>
      </Layout>
    </Layout>
    </BrowserRouter>
  );
};

export default App;
