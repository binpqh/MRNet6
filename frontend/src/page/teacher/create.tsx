import { Button, Checkbox, Form, Input } from 'antd';
import { ITeacher, ITeacherRequest } from '../../interfaces/ITeacher';
import { CreateTeacherAsync } from '../../services/Teacher.service';
import { useNavigate } from 'react-router-dom';

export const CreateTeacher = () =>
{
    const navigate = useNavigate();
        const onFinish = async (values: ITeacherRequest) => {
          console.log("Received values of form: ", values);
          const res : ITeacher = {
              name: values.name,
              birthday: values.birthDay,
              phoneNumber: values.phoneNumber,
              email: values.email,
              department: { name: values.department },
              id: ''
          }
          console.log(res);
          
          const reposn = await CreateTeacherAsync(res)
          if ( reposn!= null)
          {
            navigate('/listTeacher');
          }
        };
      
        const onFinishFailed = (errorInfo: any) => {
          console.log("Failed:", errorInfo);
        };
    
    return(
        <>
        <h1 style={{marginLeft :'5rem', fontSize : '2rem'}}>Thêm giáo viên</h1>
         <div className="form-container">
        <Form
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        style={{ border: "none", boxShadow: "none"}}
        >
        <Form.Item
            label="Name"
            name="name"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input teacher name!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Phone Number"
            name="phoneNumber"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input teacher phone number!' },
            { pattern: /^(\+84|0)\d{9,10}$/, message: 'Invalid phone number format!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Email"
            name="email"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input teacher email!' },
            { type: 'email', message: 'Invalid email format!' },
            ]}
            style={{ width: "100%" }}>
            <Input />
        </Form.Item>
        <Form.Item
            label="Birthday"
            name="birthDay"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input teacher birthday!' },
            ]}
            style={{ width: "100%" }}>
            <Input />
        </Form.Item>
        <Form.Item
            label="Department"
            name="department"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input teacher department!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>

        <Form.Item
        wrapperCol={{ offset: 15, span: 16 }}>
            <Button type="primary" htmlType="submit">
            Submit
            </Button>
        </Form.Item>
        </Form>
    </div>
        </>
    )
} 
export default CreateTeacher;