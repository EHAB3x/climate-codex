import { Outlet } from "react-router-dom";
import Nav from "../components/common/nav/nav";

const MainLayout = () => {
  return (
    <>
      <Nav />
      <Outlet />
    </>
  );
};

export default MainLayout;
