import { Link } from "react-router-dom";
import "./Balance.scss";

const Balance = () => {
  return (
    <div className="balance flex justify-center">
      <div className="balance__container flex flex-col items-center justify-center gap-7">
        <h2>Atmospheric Balance Matters</h2>

        <p>
          The atmosphere’s delicate balance of gases is vital for life on Earth,
          controlling climate and protecting us from harmful radiation. Explore
          how preserving this balance is essential for a sustainable future.
        </p>

        <Link to={"/auth/login"} className="secondary__btn">
          Log in
        </Link>
      </div>
    </div>
  );
};

export default Balance;
