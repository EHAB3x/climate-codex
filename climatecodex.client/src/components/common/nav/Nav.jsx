import { useState } from "react";
import { Link, NavLink } from "react-router-dom";
import "./nav.scss";
import Logo from "../../../assets/svg/logo.svg?react";
import { FiMenu } from "react-icons/fi";
import { IoCloseCircleOutline } from "react-icons/io5";
const Nav = () => {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <>
      <nav className="header container mx-auto flex items-center justify-between py-4">
        <Link to={"/"} className="nav__logo flex items-center gap-6">
          <Logo />
          <p className="logo__name">ClimateFlow</p>
        </Link>

        <ul className="large__screen nav__links flex items-center gap-4">
          <NavLink to={"/"}>Home</NavLink>
          <NavLink to={"/about"}>About Us</NavLink>
          <NavLink to={"/contact"}>Contact</NavLink>
        </ul>

        <div
          className="small__screen menu__toggle cursor-pointer"
          onClick={() => setIsOpen(true)}
        >
          <FiMenu size="28" />
        </div>

        <div className=" large__screen nav__actions">
          <Link to={"/login"} className="primary__btn">
            Login
          </Link>
        </div>

        {/* Mobile Nav */}
        <div className={`mobile__nav small__screen flex-col gap-12 ${isOpen ? "open" : ""}`}>
          <Link to={"/"} className="nav__logo flex items-center justify-between gap-6">
            <div className="flex items-center gap-6">
                <Logo />
                <p className="logo__name">ClimateFlow</p>
            </div>

            <IoCloseCircleOutline 
                size="32" 
                className="hover:text-[#9cfcdc]"
                onClick={()=> setIsOpen(false)}
            />
          </Link>

          <ul className="small__screen nav__links !flex flex-col gap-4">
            <NavLink to={"/"}>Home</NavLink>
            <NavLink to={"/about"}>About Us</NavLink>
            <NavLink to={"/contact"}>Contact</NavLink>
          </ul>

          <div className="small__screen nav__actions">
            <Link to={"/login"} className="primary__btn w-full">
              Login
            </Link>
          </div>
        </div>
      </nav>
    </>
  );
};

export default Nav;
