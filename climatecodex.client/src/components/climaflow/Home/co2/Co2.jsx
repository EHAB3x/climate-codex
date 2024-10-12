import { Link } from "react-router-dom";
import "./Co2.scss";

const Co2 = () => {
  return (
    <div className="co2  py-16">
      <div className="co2__container container mx-auto flex sm:flex-row flex-col items-center justify-center gap-8">
        <div className="co2__content relative flex flex-col gap-7">
          <h2>
            CO<sub>2</sub> and Its Effects
          </h2>

          <p>
            High levels of CO2 in the air can significantly impact both climate and health, making it essential to monitor. Discover how CO2 concentrations affect your surroundings and what steps you can take to stay informed.
          </p>

          <Link to={"/gas/track"} className="secondary__btn">Track CO2 Impact</Link>
        </div>

        <div className="gas__statisticts flex flex-col items-center gap-6">
          <div className="gas__card flex sm:flex-row flex-col justify-between gap-8 text-center">
            <div className="gas__level">
              <p className="gas__detail">CO2 level:</p>
              <p className="gas__value"> 0.042%</p>
            </div>
            <div className="gas__level">
              <p className="gas__detail">CO2 level:</p>
              <p className="gas__value"> 0.042%</p>
            </div>
            <div className="gas__level">
              <p className="gas__detail">CO2 level:</p>
              <p className="gas__value"> 0.042%</p>
            </div>
            <div className="gas__level">
              <p className="gas__detail">CO2 level:</p>
              <p className="gas__value"> 0.042%</p>
            </div>
          </div>
          <div className="gas__card sm:w-fit w-full">
            <div className="gas__name">CO<sub>2</sub></div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Co2;
