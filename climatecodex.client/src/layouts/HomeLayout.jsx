import Hero from '../components/climaflow/Home/hero/Hero'
import Insights from '../components/climaflow/Home/insights/Insights'
import MovingText from '../components/climaflow/Home/movingText/MovingText'
import Co2 from '../components/climaflow/Home/co2/Co2'
import Methane from '../components/climaflow/Home/methane/Methane'
import Balance from '../components/climaflow/Home/balance/Balance'

const HomeLayout = () => {
  return (
    <>
        <Hero />
        <MovingText />
        <Insights />
        <Co2 />
        <Methane />
        <Balance />
    </>
  )
}

export default HomeLayout