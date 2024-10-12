import { MapContainer, TileLayer } from "react-leaflet";
import { useState } from "react";
import "leaflet/dist/leaflet.css";
import "../styles/TrackGas.scss";
const TrackGas = () => {
  const [formData, setFormData] = useState({
    gas: "co2",
    location: "egypt",
    month: "1",
    year: "2000",
  });

  const [gasData, setGasData] = useState({
    tiles:["https://earth.gov/ghgcenter/api/raster/collections/odiac-ffco2-monthgrid-v2023/items/odiac-ffco2-monthgrid-v2023-odiac2023_1km_excl_intl_201904/tiles/WebMercatorQuad/{z}/{x}/{y}@1x?assets=co2-emissions&color_formula=gamma+r+1.05&colormap_name=rainbow&rescale=-696.9116821289062%2C35331.6484375"]
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const TrackSelectedGas = (e) => {
    e.preventDefault();
    fetch(`https://localhost:7093/api/Co2Data/${formData.year}/${formData.month}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => {
        if (!response.ok) {
          alert("Failed to get gas data");
        }
        return response.json();
      })
      .then((data) => {
        setGasData(data)
      })
      .catch((error) => {
        alert("Error:", error);
      });
  };

  console.log(gasData);
  
  return (
    <div className="track__gas container mx-auto flex sm:flex-row flex-col-reverse gap-8 mt-[110px] sm:py-24 py-0 sm:px-0 px-6 pb-12">
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
                  CO2
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
                <option value="1">January</option>
                <option value="2">February</option>
                <option value="3">March</option>
                <option value="4">April</option>
                <option value="5">May</option>
                <option value="6">June</option>
                <option value="7">July</option>
                <option value="8">August</option>
                <option value="9">September</option>
                <option value="10">October</option>
                <option value="11">November</option>
                <option value="12">December</option>
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
                <option value="2000">2000</option>
                <option value="2001">2001</option>
                <option value="2002">2002</option>
                <option value="2002">2003</option>
              </select>
            </div>
          </div>

          <button type="submit" className="secondary__btn" onClick={(e)=> TrackSelectedGas(e)}>Explore</button>
        </form>
      </div>

      <div className="gas__map flex-1">
        <MapContainer
            className="sm:h-full h-[40vh]"
          center={[26.8206, 30.8025]}
          minZoom={gasData.minzoom || 0}
          zoom={5}
          style={{ height: "100%", width: "100%" }}
          bounds={[
            -180.0,
            -90.0,
            180.0,
            90.0
          ]}
        >
          <TileLayer
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          <TileLayer
            url={gasData.tiles.join() || "https://earth.gov/ghgcenter/api/raster/collections/odiac-ffco2-monthgrid-v2023/items/odiac-ffco2-monthgrid-v2023-odiac2023_1km_excl_intl_201904/tiles/WebMercatorQuad/{z}/{x}/{y}@1x?assets=co2-emissions&color_formula=gamma+r+1.05&colormap_name=rainbow&rescale=-696.9116821289062%2C35331.6484375"}
          />
        </MapContainer>
      </div>
    </div>
  );
};

export default TrackGas;
