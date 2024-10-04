import "./Welcome.scss";

const Welcome = () => {
  return (
    <div className="welcome">
      <div className="welcome__container container mx-auto">
        <div className="welcome__content relative flex flex-col gap-7">
          <h2>
            Welcome to, <span>ClimateFlow</span>
          </h2>

          <p>
            Harnessing open-source climate data from the U.S. GHG Center, we aim
            to create an intuitive, data-driven narrative about our planet’s
            changing climate. Explore interactive insights, understand the
            impacts of greenhouse gases, and discover actionable solutions.
            Together, let’s turn data into meaningful stories that inspire
            change!
          </p>
        </div>

        <div className="empty"></div>
      </div>
    </div>
  );
};

export default Welcome;
