import React, {
    useEffect,
    useState
  } from 'react';
  import {
    Variables
  } from './Variables';
  import {
    Modal,
    Button
  } from "react-bootstrap";
  
  export default function Report() {
    const [cars, setCars] = useState([]);
    const [sellers, setSellers] = useState([]);
    const refreshCars = () => {
        fetch(Variables.API_URL + 'report/car')
          .then(response => response.json())
          .then(data => {
            setCars(data);
          });
      }
      const refreshSellers = () => {
        fetch(Variables.API_URL + 'report/seller')
          .then(response => response.json())
          .then(data => {
            setSellers(data);
          });
      }

      useEffect(() => {
            refreshCars();
            refreshSellers();
      }, [])
    return(
        <div>
        <h2>Sellings</h2>
        <table className='table table-striped'>
          <thead>
            <tr>
              <th>firstName</th>
              <th>lastName</th>
              <th>soldAt</th>
              <th>shopCommission</th>
              <th>sellerCommission</th>
              <th>totalPrice</th>
              <th>year</th>
              <th>model</th>
              <th>make</th>
              <th>licensePlate</th>
              <th>initialPrice</th>
            </tr>
          </thead>

          <tbody>
            {cars.map(c =>
              <tr key={c.id}>
                <td>{c.firstName}</td>
                <td>{c.lastName}</td>
                <td>{c.soldAt}</td>
                <td>{c.shopCommission}</td>
                <td>{c.sellerCommission}</td>
                <td>{c.totalPrice}</td>
                <td>{c.year}</td>
                <td>{c.model}</td>
                <td>{c.make}</td>
                <td>{c.licensePlate}</td>
                <td>{c.initialPrice}</td>
              </tr>)}
          </tbody>
        </table>
        <h2>Sellers</h2>
        <table className='table table-striped'>
          <thead>
            <tr>
              <th>firstName</th>
              <th>lastName</th>
              <th>commission</th>
              <th>cars</th>
            </tr>
          </thead>
          <tbody>
            {sellers.map(c =>
              <tr key={c.id}>
                <td>{c.firstName}</td>
                <td>{c.lastName}</td>
                <td>{c.commission}</td>
                <td>{c.cars}</td>
              </tr>)}
          </tbody>
        </table>
        </div>
        
    )
  }