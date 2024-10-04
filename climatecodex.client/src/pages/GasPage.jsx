import { useEffect, useState } from 'react';
import '../styles/GasPage.scss';
import { useParams } from 'react-router-dom';

const GasPage = () => {
    const [gasInfo, setGasInfo] = useState([]);
    const {gasName} = useParams();
    let gasId;
    switch (gasName) {
        case "methane":
            gasId = 1;
            break;
        case "co2":
            gasId = 2;
            break;
        default:
            break;
    } 

    useEffect(()=>{
        fetch(`https://localhost:7093/api/GHGType/faq/${gasId}`, {
            method: "GET",
            headers: {
              "Content-Type": "application/json",
            },
          })
            .then((response) => {
              if (!response.ok) {
                alert("Failed to get gas information");
              }
              return response.json();
            })
            .then((data) => {
              setGasInfo(data);
            })
            .catch((error) => {
              alert("Error:", error);
            });
    },[gasId]);
    console.log(gasInfo);
    
  return (
    <div className="gas__page">
        <div className="gas__container container mx-auto">
            <h2 className="gas__name">Carbon Dioxide (CO<sub>2</sub>)</h2> 

        </div>
    </div>
  )
}

export default GasPage