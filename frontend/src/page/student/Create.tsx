import {  useNavigate } from 'react-router-dom';
import { IStudent } from "../../interfaces/IStudent";
import { Button, Form, Input, message} from 'antd';
import { CreateStudentAsync } from '../../services/Student.service';
export const CreateNewStudent = () =>
{
    const handleSuccess =(text : string)=>
    {
        message.success(text,3);
    }
    const navigate = useNavigate();
    const onFinish = async (values : IStudent) => 
    {
        console.log("Received values of form ", values);
        const res : IStudent = {
            name : values.name,
            age : values.age,
            email : values.email,
            address: values.address,
            phone: values.phone,
            major: values.major,
            gender: values.gender,    
            
        }
        console.log(res);
        const reposn = await CreateStudentAsync(res)
        if (reposn!=null)
        {
           handleSuccess('Đăng kí thành công');
           navigate('/listStudent');
        }
      
    };
    const onFinishFailed = (errorInfo: any)=>
    {
        
        console.log('failed',errorInfo);
    };
    return(
        <>
        <h1 style={{marginLeft :'5rem', fontSize : '2rem'}}>Thêm Học Sinh</h1>
         <div className="form-container">
        <Form
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        style={{ border: "none", boxShadow: "none"}}
        >
        <Form.Item
            label="Tên"
            name="name"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student name!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Tuổi"
            name="age"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student age!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Giới Tính"
            name="gender"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student Gender!' },
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
            { required: true, message: 'Please input Student email!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Số Điện Thoại"
            name="phone"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student phone!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Địa Chỉ"
            name="address"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student adress!' },
            ]}
            style={{ width: "100%" }}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Chuyên Nghành"
            name="major"
            labelCol={{ span: 4 }}
            wrapperCol={{ flex: 1 }}
            rules={[
            { required: true, message: 'Please input Student major!' },
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
export default CreateNewStudent;