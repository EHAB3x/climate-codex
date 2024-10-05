import { useEffect, useState } from 'react';
import '../styles/GasPage.scss';
import { useParams } from 'react-router-dom';

const GasPage = () => {
    const [gasName_1, setGasName] = useState("");
    const [questions, setQuestions] = useState([]);

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
              return response.json();
            })
            .then((data) => {
                setGasName(data.gasName);
                setQuestions(data.questions);
            })
            .catch((error) => {
              alert("Error:", error);
            });
    }, [gasId]);
    console.log(gasName_1);
    console.log(questions);

    return (
    <div className="gas__page">
            <div className="gas__container container mx-auto">
                <h2 className="gas__name">{gasName_1}</h2>
                <div className="faqs flex flex-col gap-6">
                    {questions.map((ele, index) => (
                  <div className="faq flex flex-col gap-4" key={index}>
                    <p className="question">{ele.question}</p>
                    <p className="answer">{ele.answer}</p>
                  </div>
              ))}
            </div> 
        </div>
    </div>
  )
}

export default GasPage