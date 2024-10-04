import Hero from '../components/climaflow/Home/hero/Hero'
import Insights from '../components/climaflow/Home/insights/Insights'
import MovingText from '../components/climaflow/Home/movingText/MovingText'
import Welcome from '../components/climaflow/Home/welcome/Welcome'

const HomeLayout = () => {
  return (
    <>
        <Hero />
        <MovingText />
        <Insights />
        <Welcome />
    </>
  )
}

export default HomeLayout