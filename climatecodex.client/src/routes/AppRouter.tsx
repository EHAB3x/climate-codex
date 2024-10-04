import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";
import HomeLayout from "../layouts/HomeLayout";
import AuthLayout from "../layouts/AuthLayout";
import Login from "../pages/Login";
import Register from "../pages/Register";
import GasPage from "../pages/gasPage";

const router = createBrowserRouter([
    {
        path:"/",
        element: <MainLayout />,   
        children:[
          {
            index: true,
            element: <HomeLayout />
          },
          {
            path:"gas/:gasName",
            element:<GasPage />
          }
        ]     
    },{
      path:"/auth",
      element: <AuthLayout />,
      children:[
        {
          path:"/auth/login",
          element:<Login />
        },
        {
          path:"/auth/register",
          element: <Register />,
        }
      ]
    }
])


const AppRouter = () => {
  return (
    <RouterProvider router={router}></RouterProvider>
  )
}

export default AppRouter