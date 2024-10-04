import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";

const router = createBrowserRouter([
    {
        path:"/",
        element: <MainLayout />,        
    }
])


const AppRouter = () => {
  return (
    <RouterProvider router={router}></RouterProvider>
  )
}

export default AppRouter