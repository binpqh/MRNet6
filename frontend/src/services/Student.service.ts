import axios from "axios"
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