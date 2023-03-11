import React, { useState } from 'react';
import {
  QqOutlined,
  BookOutlined,
  TeamOutlined,
  UserOutlined,
} from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Layout, Menu, theme } from 'antd';
import { DeptDashboard } from './page/department/dashboard';

const { Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[],
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem('Quản lý Môn Học', 'sub1', <BookOutlined />, [
    getItem('Danh sách', '1'),
    getItem('Thêm Môn Học', '2'),
  ]),
  getItem('Quản lý Giáo Viên', 'sub2', <QqOutlined />, [
    getItem('Danh sách', '3'),
    getItem('Thêm Giáo Viên', '4'),
  ]),
  getItem('Quản lý sinh viên', 'sub3', <TeamOutlined/>, [
    getItem('Danh sách', '5'),
    getItem('Thêm', '6'),
    getItem('Điểm', '7'),
    getItem('Môn đăng kí', '8'),
  ]),
  getItem('Tài khoản', 'sub4', <UserOutlined/>, [getItem('Đăng xuất', '9'), getItem('Thông tin', '10')]),
];

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div style={{ height: 32, margin: 16, background: '#282c34' }} />
        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} />
      </Sider>
      <Layout className="site-layout">
        <Content style={{ margin: '0 12px' }}>
          <div style={{ padding: 24, minHeight: 580, background: colorBgContainer }}>
            <DeptDashboard/>
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>PQH ©2023</Footer>
      </Layout>
    </Layout>
  );
};

export default App;
