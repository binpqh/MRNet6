import { useEffect, useState } from "react";
import {Table, message } from "antd";
import { IStudent } from "../../interfaces/IStudent";
import { EditStudentAsync, GetAllStudent } from "../../services/Student.service";
import StudentForm from "./Edit";

 export const StudentDashboard = () =>
{
  
  const handleDelete =(record : any)=> 
  {
    console.log("mssv",record);
  }
  //thực hiện điều kiện để mở edit
  const[isOpen,setIsOpen] = useState<boolean>(false);
  //lưu student để gửi sang api chỉnh sửa
  const[student,setStudent] = useState<IStudent>();
  //tạo list để fill vào columns
  const [listStudent,setlistStudent] = useState<IStudent[]>([]) 
  //nạp danh sách qua api sau đó set vào list
  useEffect(()=>{
      const fetchData = async () => {
          const results = await GetAllStudent();
          setlistStudent(results);
        };
        fetchData();
  },[])
  const OpenModal = ()=>
  {
    setIsOpen(!isOpen);
  }
  const EditStudent = async (student:IStudent) => {
    setStudent(student);
    OpenModal();  
     //sẽ call api => submit edit lại
    EditStudentAsync(student);
    //tim vị trí cần update
    const index = listStudent.findIndex(item => item.id === student.id);
    //sao chep một list danh sach 
    const updatedList = [...listStudent];
    // cap nhật lại đối tượng 
    updatedList[index]=student;
    //gọi và set lại list (react sẽ tự cập nhật lại component)
    setlistStudent(updatedList);
  }
  const columns = [
      {
          title: 'Mã Số Sinh Viên',
          dataIndex:'id',
          key: 'id'
      },
      {
        title: 'Tên',
        dataIndex: 'name',
        key: 'name',
      },
      {
          title: 'Tuổi',
          dataIndex: 'age',
          key: 'age',
        },
      {
        title: 'Giới Tính',
        dataIndex: 'gender',
        key: 'gender',
      },
      {
        title: 'Số Điện Thoại',
        dataIndex: 'phone',
        key: 'phone',
      },
      {
          title: 'Email',
          dataIndex: 'email',
          key: 'email',
        },
        {
          title: 'Địa chỉ',
          dataIndex: 'address',
          key: 'address',
        },
        {
          title: 'Khoa',
          dataIndex: 'major',
          key: 'major',
        }, 
        {
          title: 'Sửa Sinh Viên',
          key: 'actions',
          render: (text : any, record : IStudent ) => (
            <span>
              <a onClick={ async () => EditStudent( record) }>Sửa</a>
            </span>
          ),
        },
        {
          title: 'Xóa Sinh Viên',
          key: 'actions',
          render: (text : any, record : any ) => (
            <span>
              <a onClick={() => handleDelete(record.id)}>Xóa</a>
            </span>
          ),
        },
    ];
  return(
      <>
      <StudentForm student={student} isOpen={isOpen} onClose={OpenModal} onSave={EditStudent}  />
      <Table dataSource={listStudent} columns={columns} />
      </>
  )
}