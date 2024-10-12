/* eslint-disable react/prop-types */
import { MapContainer, TileLayer, useMap } from "react-leaflet";
import { useState } from "react";
import "leaflet/dist/leaflet.css";
import "../styles/TrackGas.scss";
import InputField from "../components/common/inputField/InputField";

const TrackGas = () => {
  const [formData, setFormData] = useState({
    gas: "co2Data",
    location: "egypt",
    month: "1",
    year: "2000",
  });

  const [gasData, setGasData] = useState({
    tiles: [
      "https://earth.gov/ghgcenter/api/raster/collections/odiac-ffco2-monthgrid-v2023/items/odiac-ffco2-monthgrid-v2023-odiac2023_1km_excl_intl_201904/tiles/WebMercatorQuad/{z}/{x}/{y}@1x?assets=co2-emissions&color_formula=gamma+r+1.05&colormap_name=rainbow&rescale=-696.9116821289062%2C35331.6484375",
    ],
    minzoom: 0,
  });

  const [mapCenter, setMapCenter] = useState([26.8206, 30.8025]); // Default center (Egypt)

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));

    const selectedCountry = countries.find(
      (country) => country.value === value
    );
    if (selectedCountry) {
      setMapCenter(selectedCountry.center);
    }
  };

  const TrackSelectedGas = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(
        `https://localhost:7093/api/${formData.gas}/${formData.year}/${formData.month}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) throw new Error("Failed to get gas data");

      const data = await response.json();
      setGasData(data);
    } catch (error) {
      alert("Error: " + error.message);
    }
  };

  return (
    <div className="track__gas container mx-auto flex sm:flex-row flex-col-reverse gap-8 mt-[110px] sm:py-24 py-0 sm:px-0 px-6 pb-12">
      <div className="gas__details flex-1">
        <h2>Track Gas Levels in Your Area</h2>

        <form className="flex flex-col gap-4 mt-6" onSubmit={TrackSelectedGas}>
          <div className="input__group flex gap-4 w-full">
            <InputField
              id="gas"
              name="gas"
              label="Gas"
              options={[
                { value: "co2Data", label: "CO2" },
                { value: "MlData", label: "Methane" },
              ]}
              value={formData.gas}
              onChange={handleChange}
            />
            <InputField
              id="location"
              name="location"
              label="Location"
              options={countries}
              value={formData.location}
              onChange={handleChange}
            />
          </div>

          <div className="input__group flex gap-4 w-full">
            <InputField
              id="month"
              name="month"
              label="Month"
              options={Array.from({ length: 12 }, (_, i) => ({
                value: (i + 1).toString(),
                label: new Date(0, i).toLocaleString("default", {
                  month: "long",
                }),
              }))}
              value={formData.month}
              onChange={handleChange}
            />
            <InputField
              id="year"
              name="year"
              label="Year"
              options={Array.from({ length: formData.gas === "co2Data" ? 23 : 18}, (_, i) => ({
                value: ((formData.gas === "co2Data" ? 2000 : 1999) + i).toString(),
                label: ((formData.gas === "co2Data" ? 2000 : 1999) + i).toString(),
              }))}
              value={formData.year}
              onChange={handleChange}
            />
          </div>

          <button type="submit" className="secondary__btn">
            Explore
          </button>
        </form>
      </div>

      <div className="gas__map flex-1">
        <MapContainer
          center={mapCenter} // Use the mapCenter state for center
          minZoom={gasData.minzoom}
          zoom={5}
          style={{ height: "100%", width: "100%" }}
        >
          <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
          <TileLayer url={gasData.tiles.join()} />
          <ChangeMapCenter mapCenter={mapCenter} />
        </MapContainer>
      </div>
    </div>
  );
};

const ChangeMapCenter = ({ mapCenter }) => {
  const map = useMap(); // Get the map instance

  // Call flyTo whenever mapCenter changes
  if (map) {
    map.flyTo(mapCenter, map.getZoom());
  }

  return null; // This component doesn't render anything
};

export default TrackGas;

const countries = [
  {
    value: "egypt",
    label: "Egypt",
    center: [26.8206, 30.8025], // Latitude, Longitude
  },
  {
    value: "saudi",
    label: "Saudi Arabia",
    center: [23.8859, 45.0792], // Latitude, Longitude
  },
  {
    value: "usa",
    label: "United States",
    center: [37.0902, -95.7129], // Latitude, Longitude
  },
  {
    value: "canada",
    label: "Canada",
    center: [56.1304, -106.3468], // Latitude, Longitude
  },
  {
    value: "uk",
    label: "United Kingdom",
    center: [55.3781, -3.436], // Latitude, Longitude
  },
  {
    value: "germany",
    label: "Germany",
    center: [51.1657, 10.4515], // Latitude, Longitude
  },
  // Add more countries as needed
];
