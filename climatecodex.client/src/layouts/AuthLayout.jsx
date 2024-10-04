import { Outlet } from "react-router-dom"
import "../styles/authLayouyt.scss"
const AuthLayout = () => {
  return (
    <div className="auth__container flex">
        <Outlet />
        <div className="auth__background">
            
        </div>
    </div>
  )
}

export default AuthLayout