import Nav from '../components/common/nav/nav'
import { Outlet } from 'react-router-dom'

const MainLayout = () => {
  return (
    <>
        <Nav />
        <div>
            <Outlet />
        </div>
        {/* <Footer /> */}
    </>
  )
}

export default MainLayout