import './Hero.scss'

const Hero = () => {
  return (
    <section className="hero__section">
        <div className="hero__container container mx-auto flex sm:justify-center justify-start sm:items-center items-start gap-8 h-full">
            <div className="hero__content flex flex-col gap-7 flex-1">
                <h2>Welcome to, <span>ClimateFlow</span></h2>

                <p>Harnessing open-source climate data from the U.S. GHG Center, we aim to create an intuitive, data-driven narrative about our planet’s changing climate. Explore interactive insights, understand the impacts of greenhouse gases, and discover actionable solutions. Together, let’s turn data into meaningful stories that inspire change!</p>
            </div>

            <div className="gases grid sm:grid-cols-3 grid-cols-1 gap-6 flex-1">
                <div className="gas__card flex sm:block sm:flex-col flex-row gap-4">
                    <h4 className="gas__name">CO<sub>2</sub></h4>

                    <div className="gas__content">
                        <p><span>CO2 level:</span> 0.042%</p>
                        <p><span>0.0002% - 0.0003%</span></p>
                        <p><span>China emissions:</span> 28%</p>
                        <p><span>in atmosphere:</span> 0.04%</p>
                    </div>
                </div>
                <div className="gas__card flex sm:block sm:flex-col flex-row gap-4">
                    <h4 className="gas__name">Methane</h4>

                    <div className="gas__content">
                        <p><span>CO2 level:</span> 0.042%</p>
                        <p><span>0.0002% - 0.0003%</span></p>
                        <p><span>China emissions:</span> 28%</p>
                        <p><span>in atmosphere:</span> 0.04%</p>
                    </div>
                </div>
                <div className="gas__card flex sm:block sm:flex-col flex-row gap-4">
                    <h4 className="gas__name">Temperature</h4>

                    <div className="gas__content">
                        <p><span>CO2 level:</span> 0.042%</p>
                        <p><span>0.0002% - 0.0003%</span></p>
                        <p><span>China emissions:</span> 28%</p>
                        <p><span>in atmosphere:</span> 0.04%</p>
                    </div>
                </div>
                
            </div>
        </div>
    </section>
  )
}

export default Hero