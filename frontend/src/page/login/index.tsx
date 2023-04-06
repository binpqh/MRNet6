import React, { useState } from 'react';
import { Form, Input, Button, message } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { ILogin } from '../../interfaces/ILogin';
import { LoginAsync } from '../../services/Login.service';
import { useNavigate } from 'react-router-dom';
import { StilHere } from '../../components/Authenticated/StillHere';

const Login = () => {
  const stillhere = StilHere();
  const [loginRequest, setloginReq] = useState<ILogin>({username:'',password:''});
  const handleSuccess = (text : string) =>
  {
    message.success(text,3);
  }
  const navigate = useNavigate();
  const onFinish = async () => {
  console.log(loginRequest);
      const response = await LoginAsync(loginRequest)
      if ( !response.success) 
      {
        handleSuccess('Đăng nhập thất bại. kiểm tra tài khoản mật khẩu');
      }
      localStorage.setItem('token', response.token);
      const role = response.role;
      localStorage.setItem('role', role);
      const text = 'Xin Chào '+ loginRequest.username.toString();
      handleSuccess(text);  
      navigate("/dashboard");
  };

  return (
    <div style={{border : '5px',display: 'flex', alignItems: 'center', justifyContent: 'center', minHeight: '100vh',
     background: 'linear-gradient(to bottom right, #56bce3, #aa79d8)' }}>
    <div style={{display: 'flex', 
      flexDirection: 'column',
      alignItems: 'center', 
      justifyContent: 'center', 
      minHeight: '50vh', 
      minWidth: '54vh',
      background: 'linear-gradient(to bottom right,#a3daef, #ddcaef)',
      border: '3px solid #bc93a7',
      borderRadius: 30,
      boxShadow: '0 0 10px rgba(0, 0, 0, 0.6)',
      padding: 20,
      maxWidth: 400,
      maxHeight : 200,
      margin: '0 auto',}}>
        <h2 style={{ color: '#37125a' }}>Đăng nhập</h2>
        <Form
        name="normal_login"
        className="login-form"
        initialValues={{ remember: true }}
        onFinish={onFinish}>
        <Form.Item
            name="username"
            rules={[{ required: true, message: 'Vui lòng điền thông tin!' }]}>
            <Input onChange={(e) => {const a = loginRequest; a.username= e.target.value ; setloginReq(a)}} value={loginRequest.username} prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Tài khoản" />
        </Form.Item>
        <Form.Item
            name="password"
            rules={[{ required: true, message: 'Vui lòng điền thông tin!' }]}>
            <Input onChange={(e) => {const a = loginRequest; a.password= e.target.value ; setloginReq(a)}}
            value={loginRequest.password}
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Mật khẩu"
            />
        </Form.Item>

        <Form.Item>
            <Button type="primary" htmlType="submit" className="login-form-button" >
            Đăng nhập
            </Button>
        </Form.Item>
        </Form>
    </div>
    </div>  

  );
};

export default Login;