import Hero from '../components/climaflow/Home/hero/Hero'
import Insights from '../components/climaflow/Home/insights/Insights'
import MovingText from '../components/climaflow/Home/movingText/MovingText'
import Co2 from '../components/climaflow/Home/co2/Co2'
import Nav from '../components/common/nav/nav'
import Methane from '../components/climaflow/Home/methane/Methane'

const HomeLayout = () => {
  return (
    <>
        <Nav />
        <Hero />
        <MovingText />
        <Insights />
        <Co2 />
        <Methane />
    </>
  )
}

export default HomeLayout