import "./Insights.scss"
import earth from "../../../../assets/images/insights/earth.png" 
import { Link } from "react-router-dom"
import RightLine from "../../../../assets/svg/hero/right-lines.svg?react"
import LeftLine from "../../../../assets/svg/hero/left-lines.svg?react"
const Insights = () => {
  return (
    <div className="insights relative overflow-hidden py-16">
                <RightLine  className="absolute bottom-0 right-0"/>
                <LeftLine  className="absolute top-0 left-0 sm:block hidden"/>
        <div className="insights__container relative container mx-auto flex sm:flex-row flex-col items-center gap-8">
            <div className="insights__image">
                <img src={earth} alt="earth-map" />
            </div>

            <div className="insights__content flex flex-col gap-7">
                <h3>Air Quality Insights</h3>

                <p>Easily filter locations based on air quality and gas concentrations, including CO2 and methane levels. Stay informed and choose safer environments with real-time data.</p>

                <Link to={"/login"} className="secondary__btn mt-7">Log in</Link>
            </div>
        </div>
    </div>
  )
}

export default Insights