import { useNavigate } from 'react-router-dom';
export const StilHere =()=> 
{
    const navigate =  useNavigate();
    const token = localStorage.getItem('token');
    const Role = localStorage.getItem('role');
    if(!token && !Role){
        navigate("/login");
    }
    navigate("/dashboard");
}