import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";
import HomeLayout from "../layouts/HomeLayout";
import AuthLayout from "../layouts/AuthLayout";

const router = createBrowserRouter([
    {
        path:"/",
        element: <MainLayout />,   
        children:[
          {
            index: true,
            element: <HomeLayout />
          }
        ]     
    },{
      path:"/auth",
      element: <AuthLayout />,
      children:[
        {
          path:"/auth/login",
          element:<p className="flex-1">Login</p>
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