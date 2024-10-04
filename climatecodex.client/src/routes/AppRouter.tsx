import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";
import HomeLayout from "../layouts/HomeLayout";

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
    }
])


const AppRouter = () => {
  return (
    <RouterProvider router={router}></RouterProvider>
  )
}

export default AppRouter