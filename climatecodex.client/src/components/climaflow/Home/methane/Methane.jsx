import './Methane.scss'
import { Link } from "react-router-dom";
import Methane_img from "../../../../assets/images/methane/stats.png"
const Methane = () => {
  return (
    <div className="methane py-16">
      <div className="methane__container container mx-auto flex sm:flex-row flex-col items-center justify-center gap-8">
        <div className="gas__statistics flex flex-col items-center gap-6">
          <div className="gas__card flex sm:flex-row flex-col justify-between gap-8 text-center">
            <img src={Methane_img} alt="Methane" />
          </div>
        </div>

        <div className="methane__content relative flex flex-col gap-7">
          <h2>
            Methane and Its Impact
          </h2>

          <p>
            Methane is a potent greenhouse gas that contributes heavily to climate change and can degrade air quality. Learn how methane levels affect your environment and find out ways to track and reduce its impact.
          </p>

          <Link to={"/gas/methane"} className="secondary__btn">More About CH<sub>4</sub></Link>
        </div>
      </div>
    </div>
  )
}

export default Methane