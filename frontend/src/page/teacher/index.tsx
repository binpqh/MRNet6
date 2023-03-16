import { useEffect, useState } from "react";
import { ITeacher } from "../../interfaces/ITeacher";
import { GetallTeacher } from "../../services/Teacher.service";
import { Table } from "antd";

export const TeacherDashboard = () =>
{
    const [listTeacher,setlistTeacher] = useState<ITeacher[]>([])
    useEffect(()=>
    {
        const fetchData = async () => {
            const results = await GetallTeacher();
            setlistTeacher(results);
          };
          fetchData();
    },[])
    console.log(listTeacher);
    const columns = [
        {
            title: 'Id',
            dataIndex:'id',
            key: 'id'
        },
        {
          title: 'Name',
          dataIndex: 'name',
          key: 'name',
        },
        {
          title: 'Birthday',
          dataIndex: 'birthday',
          key: 'birthday',
        },
        {
          title: 'PhoneNumber',
          dataIndex: 'phoneNumber',
          key: 'phoneNumber',
        },
        {
            title: 'Email',
            dataIndex: 'email',
            key: 'email',
          },
          {
            title: 'DepartmentName',
            dataIndex: 'departmentName',
            key: 'departmentName',
          },
      ];
    return(
        <>
        <Table dataSource={listTeacher} columns={columns} />
        </>
    )
}