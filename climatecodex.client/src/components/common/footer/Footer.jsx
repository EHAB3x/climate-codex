import Logo from "../../../assets/svg/logo.svg?react";
import { Link } from "react-router-dom";
import { FaPhone } from "react-icons/fa6";
import { CgMail } from "react-icons/cg";
import {
  FaYoutube,
  FaFacebook,
  FaTwitter,
  FaInstagram,
  FaLinkedin,
} from "react-icons/fa";
import "./Footer.scss";
const Footer = () => {
  return (
    <footer className="sm:px-0 px-6">
      <div className="footer__container container mx-auto flex flex-col">
        <div className="first__row flex sm:flex-row flex-col justify-between items-center gap-4">
          <Link to={"/"} className="footer__logo flex items-center gap-6">
            <Logo />
            <p className="logo__name">GreenMatrix</p>
          </Link>

          <div className="newsletter flex items-center gap-4">
            <input
              type="email"
              placeholder="Enter your email to get the latest news..."
            />
            <button>Subscribe</button>
          </div>
        </div>

        <div className="second__row flex sm:flex-row flex-col justify-between gap-4">
          <div className="flex flex-col gap-4">
            <h4>Support</h4>
            <ul>
              <li>Common Questions</li>
              <li>Help and Support</li>
              <li>Privacy Policy</li>
            </ul>
          </div>

          <div className="flex flex-col gap-4">
            <h4>Contact Us</h4>
            <ul className="flex flex-col gap-2">
              <li className="flex items-center gap-3">
                <FaPhone />
                (+20) 999-999-999
              </li>

              <li className="flex items-center gap-">
                <CgMail />
                Greenmatrix@gmail.com
              </li>
            </ul>
          </div>

          <div className="flex flex-col gap-4">
            <h4>Join Us</h4>
            <ul className="flex gap-4">
              <li><FaYoutube/></li>
              <li><FaFacebook /></li>
              <li><FaTwitter /></li>
              <li><FaInstagram /></li>
              <li><FaLinkedin /></li>
            </ul>
          </div>
        </div>

        <div className="third__row text-center pt-3">
          Greenmatrix &copy; 2024. All Rights Reserved.
        </div>
      </div>
    </footer>
  );
};

export default Footer;
