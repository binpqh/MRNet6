import { Console } from "console"
import axiosClient from "../api/AxiosClient"
import { IStudent } from "../interfaces/IStudent"

export const GetAllStudent = async () => 
{
    return (await axiosClient.get<IStudent[]>(`/Student/GetAll`) ).data
}
export const CreateStudentAsync = async(Student : IStudent) =>
{
    return (await axiosClient.post(`/Student/Create`,Student)).data
}
export const GetOneStudentAsync = async(Id :string)=>
{
    return(await axiosClient.get<IStudent>(`/Student/Get?Id=${Id}`)).data
}
export const EditStudentAsync = async(Student:IStudent)=>
{
    return(await axiosClient.put<IStudent>(`/Student/Update`,Student)).data  
}