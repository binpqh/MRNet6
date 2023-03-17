import { useEffect, useState } from "react";

import { Table } from "antd";
import { IStudent } from "../../interfaces/IStudent";
import { GetAllStudent } from "../../services/Student.service";


 export const StudentDashboard = () =>
 {
    const [listStudent,setlistStudent] = useState<IStudent[]>([])
    useEffect(()=>
    {
        const fetchData = async () => {
            const results = await GetAllStudent();
            setlistStudent(results);
          };
          fetchData();
    },[])
    console.log(listStudent);
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
      ];
    return(
        <>
        <Table dataSource={listStudent} columns={columns} />
        </>
    )
 } 