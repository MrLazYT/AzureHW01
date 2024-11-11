import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

function App() {
  const [cars, setCars] = useState([]);

  const getCars = async () => {
    var response = await fetch(
      "api/cars",
      {
        method: "get"
      }
    )
  
    var responseJson = await response.json();
    const carsData = responseJson.$values;
    
    console.log(carsData);
    
    setCars([...cars, ...carsData]);
    console.log(cars);
  }

  return (
    <div className="App">
      <button onClick={getCars}>Get Cars</button>

      <div style={{ display: 'flex', flexWrap: 'wrap' }}>
        {cars.map((car) => (
            <div key={car.Id} className="car">
              <img src={car.imagePath} alt={car.model} width="256px"/>
              <h3>{car.model}</h3>
              <p>Category: {car.categoryName}</p>
              <p>Color: {car.color}</p>
              <p>Year: {car.year}</p>
              <p>Price: ${car.price}</p>
            </div>
          ))}
      </div>
    </div>
  );
}

export default App;
