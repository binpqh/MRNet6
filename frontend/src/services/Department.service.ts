import axiosClient from "../api/AxiosClient";
import { IDepartment } from "../interfaces/IDepartmentService";

export const GetAllDept = async()=>
{
    return(await axiosClient.get<IDepartment[]>(`/Department`)).data;
}