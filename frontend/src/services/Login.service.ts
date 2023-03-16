import axiosClient from "../api/AxiosClient";
import { ILogin, ILoginResult } from "../interfaces/ILogin";

export const LoginAsync = async (Login:ILogin) =>
{
    return(await axiosClient.post<ILoginResult>(`Auth/login`,Login)).data;
}
