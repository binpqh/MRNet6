import React, { useEffect, useState } from "react";
import { Form, Input, Button, Modal, message } from "antd";
import { IStudent } from "../../interfaces/IStudent";




interface IStudentProps
{
  isOpen: boolean;
  onClose: () => void;
  onSave: (student: IStudent) => void;
  student?: IStudent
}
export const StudentForm: React.FC<IStudentProps> = ({
  student,isOpen,onClose,onSave
}) => {
  const handleSuccess =()=>
    {
        message.success('Cập Nhật Thành Công',3);
    }
  const [form] = Form.useForm();
  
  const handleSubmit = async (studentRequest : IStudent) => {
    const studentId=student?.id
    const res : IStudent = {
      id : studentId,
      name : studentRequest.name,
      age : studentRequest.age,
      email : studentRequest.email,
      address: studentRequest.address,
      phone: studentRequest.phone,
      major: studentRequest.major,
      gender: studentRequest.gender,         
  }
    onSave(res);
    handleSuccess();
  };
  useEffect(() => {
    handleSetFormValues();
  })
  const handleSetFormValues = () => {
    form.setFieldsValue({
      name: student?.name,
      age: student?.age,
      gender: student?.gender,
      email:student?.email,
      phone:student?.phone,
      address:student?.address,
      major:student?.address

      // Thay đổi các giá trị khác tương ứng với tên các field trong form
    });
  };
  const handleReset = () => {
    form.resetFields();
  };
  return (
    <Modal
    title="Edit text"
    open = {isOpen}
    onCancel={onClose}
    footer={[
      <Button key="cancel" onClick={onClose}>
        Cancel
      </Button>,
    ]}>
    <Form
        form={form}
        onFinish={handleSubmit}
        layout="vertical"
      >
        <Form.Item
          name="name"
          label="Name"
          rules={[{ required: true, message: "Please enter name" }]}
        >
          <Input placeholder="Enter name" />
        </Form.Item>

        <Form.Item
          name="age"
          label="Age"
          rules={[
            { required: true, message: "Please enter age" },
            { type: "number", min: 0, message: "Please enter a valid age" },
          ]}
        >
          <Input placeholder="Enter age" type="number" />
        </Form.Item>

        <Form.Item
          name="gender"
          label="Gender"
          rules={[{ required: true, message: "Please enter gender" }]}
        >
          <Input placeholder="Enter gender" />
        </Form.Item>

        <Form.Item
          name="email"
          label="Email"
          rules={[
            { required: true, message: "Please enter email" },
            { type: "email", message: "Please enter a valid email" },
          ]}
        >
          <Input placeholder="Enter email" />
        </Form.Item>

        <Form.Item
          name="phone"
          label="Phone"
          rules={[
            { required: true, message: "Please enter phone number" },
            {
              pattern: /^(\+84|0)(\d{9}|\d{10})$/,
              message: "Please enter a valid phone number",
            },
          ]}
        >
          <Input placeholder="Enter phone number" />
        </Form.Item>

        <Form.Item
          name="address"
          label="Address"
          rules={[{ required: true, message: "Please enter address" }]}
        >
          <Input placeholder="Enter address" />
        </Form.Item>

        <Form.Item
          name="major"
          label="Major"
          rules={[{ required: true, message: "Please enter major" }]}
        >
          <Input placeholder="Enter major" />
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit">
            Submit
          </Button>
          <Button htmlType="button" onClick={handleReset}>
            Reset
          </Button>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default StudentForm;
