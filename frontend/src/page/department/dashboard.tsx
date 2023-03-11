import { useEffect, useState } from "react"
import { IDepartment } from '../../interfaces/IDepartmentService';
import { GetAllDept } from "../../services/Department.service";

export const DeptDashboard = () =>
{
    const [listDept,setlistDept] = useState<IDepartment[]>([])
    useEffect(()=>
    {
        const fetchData = async () => {
            const results = await GetAllDept();
            setlistDept(results);
          };
          fetchData();
    },[])
    console.log(listDept);
    return(
        <>
        {listDept.map((item,index)=>
        {
            return(
                <p>{item.name}</p>
            )
        })}
        </>
    )
}