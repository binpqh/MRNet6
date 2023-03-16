import axiosClient from "../api/AxiosClient";
import { ITeacher } from "../interfaces/ITeacher";


export const GetallTeacher = async () =>
{
    return(await axiosClient.get<ITeacher[]>(`/Teacher/GetAll`)).data;
}
export const CreateTeacherAsync =async (teacher:ITeacher) => {
    return  (await axiosClient.post(`/Teacher/Create`,teacher)).data;
}