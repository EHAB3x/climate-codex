import { Outlet } from "react-router-dom";
import Nav from "../components/common/nav/nav";
import Footer from "../components/common/footer/Footer";

const MainLayout = () => {
  return (
    <>
      <Nav />
      <Outlet />
      <Footer />
    </>
  );
};

export default MainLayout;
