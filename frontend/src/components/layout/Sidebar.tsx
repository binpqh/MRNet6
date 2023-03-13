import { Layout, Menu  } from "antd";
import { Link } from "react-router-dom";
import {
  TeamOutlined,
  UserOutlined,
} from '@ant-design/icons';
const { Sider } = Layout;
const { SubMenu } = Menu;
interface Props {
    collapsed: boolean;
    onToggleSidebar: () => void;
  }
export const Sidebar = (props : Props) => {
  return (
    <Sider collapsible collapsed={props.collapsed} onCollapse={props.onToggleSidebar}>
      <div className="logo"></div>
      <Menu mode="inline" defaultSelectedKeys={['1']} defaultOpenKeys={['sub1']}>
        <SubMenu key="sub1" title="Quản lý sinh viên" icon={<UserOutlined />}>
          <Menu.Item key="1"><Link to="/">Danh sách</Link></Menu.Item>
          <Menu.Item key="2"><Link to="/page2">Thêm</Link></Menu.Item>
        </SubMenu>
        <SubMenu key="sub2" title="Quản lý giáo viên" icon={<TeamOutlined />}>
          <Menu.Item key="4"><Link to="/page4">Danh sách</Link></Menu.Item>
          <Menu.Item key="5"><Link to="/page5">Thêm</Link></Menu.Item>
        </SubMenu>
        <SubMenu key="sub3" title="Quản lý môn học" icon={<UserOutlined />}>
          <Menu.Item key="6"><Link to="/">Danh sách</Link></Menu.Item>
          <Menu.Item key="7"><Link to="/page2">Thêm</Link></Menu.Item>
          <Menu.Item key="8"><Link to="/page3">Lớp</Link></Menu.Item>
        </SubMenu>
        <SubMenu key="sub4" title="Quản lý tài khoản" icon={<UserOutlined />}>
          <Menu.Item key="9"><Link to="/">Danh sách</Link></Menu.Item>
          <Menu.Item key="10"><Link to="/page2">Thêm</Link></Menu.Item>
        </SubMenu>
        <SubMenu key="sub5" title="Tài khoản" icon={<UserOutlined />}>
          <Menu.Item key="11"><Link to="/">Thông tin</Link></Menu.Item>
          <Menu.Item key="12"><Link to="/page2">Đổi mật khẩu</Link></Menu.Item>
          <Menu.Item key="13"><Link to="/page3">Đăng xuất</Link></Menu.Item>
        </SubMenu>
      </Menu>
    </Sider>
  );
}