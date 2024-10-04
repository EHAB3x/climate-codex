import "../styles/login.scss"
import Google from "../assets/svg/auth/google.svg?react";
import Apple from "../assets/svg/auth/apple.svg?react";
import { Link } from "react-router-dom";
import { useState } from "react";
const Login = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");

  const login = (e)=>{
    e.preventDefault();
    fetch("https://localhost:7093/api/User",{
      method: "GET",
    })
  }
  return (
    <div className="auth__form">
        <div className="auth_container flex flex-col gap-12">
            <h2>Get Started Now</h2>

            <form className="flex flex-col gap-6">
              <div className="input__field">
                <label htmlFor="username">Name</label>
                <input 
                  type="text" 
                  name="Username" 
                  id="username" 
                  placeholder="Enter your name"
                  onChange={(e)=> setUsername(e.target.value)}
                />
              </div>

              <div className="input__field">
              <label htmlFor="email">Email</label>
              <input 
                type="email" 
                name="Email" 
                id="email" 
                placeholder="Enter your email"
                onChange={(e)=> setEmail(e.target.value)}
              />
              </div>

              <button 
                className="secondary__btn" 
                type="submit" 
                value="Sign in" 
                onClick={(e)=> login(e)}
              >
                Sign in
              </button>
            </form>

            <p className="log__method flex items-center gap-2">
              <span></span>
              OR
              <span></span>
            </p>

            <div className="flex sm:flex-row flex-col items-center justify-between gap-4">
              <Google className="cursor-pointer"/>
              <Apple className="cursor-pointer"/>
            </div>

            <p className="no__account">Don&apos;t Have Account? <Link to="/auth/register">Register</Link></p>
        </div>
    </div>
  )
}

export default Login