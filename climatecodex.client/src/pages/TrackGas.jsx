import { MapContainer, TileLayer } from "react-leaflet";
import { useState } from "react";
import "leaflet/dist/leaflet.css";
import "../styles/TrackGas.scss";
const TrackGas = () => {
  const [formData, setFormData] = useState({
    gas: "co2",
    location: "egypt",
    month: "January",
    year: "2023",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };
  return (
    <div className="track__gas container mx-auto flex gap-8 mt-[110px] py-24">
      <div className="gas__details flex-1">
        <h2>Track Gas <br/> Levels in Your Area</h2>

        <form className="flex flex-col gap-4 mt-6">
          <div className="input__group flex gap-4 w-full">
            <div className="input__filed flex flex-col flex-1">
              <label htmlFor="gas">Gas</label>
              <select
                id="gas"
                name="gas"
                value={formData.gas}
                onChange={handleChange}
              >
                <option value="co2">
                  CO<sub>2</sub>
                </option>
                <option value="methane">Methane</option>
              </select>
            </div>

            <div className="input__filed flex flex-col flex-1">
              <label htmlFor="location">Location</label>
              <select
                id="location"
                name="location"
                value={formData.location}
                onChange={handleChange}
              >
                <option value="egypt">Egypt</option>
                <option value="saudi">Saudi Arabia</option>
              </select>
            </div>
          </div>

          <div className="input__group flex gap-4 w-full">
            <div className="input__filed flex flex-col flex-1">
              <label htmlFor="month">Month</label>
              <select
                id="month"
                name="month"
                value={formData.month}
                onChange={handleChange}
              >
                <option value="January">January</option>
                <option value="February">February</option>
                <option value="March">March</option>
                <option value="April">April</option>
                <option value="May">May</option>
                <option value="June">June</option>
                <option value="July">July</option>
                <option value="August">August</option>
                <option value="September">September</option>
                <option value="October">October</option>
                <option value="November">November</option>
                <option value="December">December</option>
              </select>
            </div>

            <div className="input__filed flex flex-col flex-1">
              <label htmlFor="year">Year</label>
              <select
                id="year"
                name="year"
                value={formData.year}
                onChange={handleChange}
              >
                <option value="2021">2021</option>
                <option value="2022">2022</option>
                <option value="2023">2023</option>
                <option value="2024">2024</option>
              </select>
            </div>
          </div>

          <button type="submit" className="secondary__btn">Explore</button>
        </form>
      </div>

      <div className="gas__map flex-1">
        <MapContainer
          center={[0, 0]}
          zoom={2}
          style={{ height: "100%", width: "100%" }}
        >
          <TileLayer
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          />
          <TileLayer
            url="https://earth.gov/ghgcenter/api/raster/collections/odiac-ffco2-monthgrid-v2023/items/odiac-ffco2-monthgrid-v2023-odiac2023_1km_excl_intl_201904/tiles/WebMercatorQuad/{z}/{x}/{y}@1x?assets=co2-emissions&color_formula=gamma+r+1.05&colormap_name=rainbow&rescale=-696.9116821289062%2C35331.6484375"
            attribution="&copy; <a href='https://earth.gov'>Earth.gov</a> contributors"
          />
        </MapContainer>
      </div>
    </div>
  );
};

export default TrackGas;
