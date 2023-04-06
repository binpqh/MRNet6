import { Navigate, Outlet, useLocation, useNavigate} from "react-router-dom";
import { message } from "antd";

interface Iprop{
  roles:string;
}

export const PrivateRoute : React.FC <Iprop> = ({roles}) => {
  const handleSuccess = () => {
    message.warning("Bạn Không Có Quyền Truy Cập");
  }

  const location = useLocation();
  const Token = localStorage.getItem("token");
  const navigate = useNavigate();

  if (!Token) {
    handleSuccess();
    return <Navigate to={"/login"} state={{from: location}} replace />      
  }

  const Role = localStorage.getItem("role");

  if (roles === Role) {
    // check if user is logged in and not trying to access login page
    if (location.pathname === "/login") {
      return <Navigate to={"/dashboard"} replace />;
    }
    return <Outlet/>;
  }

  handleSuccess();
  return <Navigate to={"/login"} state={{from: location}} replace />  
}

