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
  
  export default function Cars() {
    const [cars, setCars] = useState([]);
    const [modalTitle, setModalTitle] = useState("");
    const [id, setId] = useState(0);
    const [year, setYear] = useState(0);
    const [model, setModel] = useState("");
    const [make, setMake] = useState("");
    const [licensePlate, setLicensePlate] = useState("");
    const [description, setDescription] = useState("");
    const [initialPrice, setInitialPrice] = useState(0);
    const [shopCommission, setShopCommission] = useState(0);
    const [sellerCommission, setSellerCommission] = useState(0);
    const [totalPrice, setTotalPrice] = useState(0);
    const [show, setShow] = useState(false);
    const [sellShow, setSellShow] = useState(false);
    const [code, setCode] = useState("");
    const [sold, setSold] = useState(false);
  
  
    const changeCode = (e) => {
      setCode(e.target.value);
    }
    const changeYear = (e) => {
      setYear(e.target.value);
    }
    const changeModel = (e) => {
      setModel(e.target.value);
    }
    const changeMake = (e) => {
      setMake(e.target.value);
    }
    const changeLicensePlate = (e) => {
      setLicensePlate(e.target.value);
    }
    const changeDescription = (e) => {
      setDescription(e.target.value);
    }
    const changeInitialPrice = (e) => {
      setInitialPrice(e.target.value);
    }
  
  
    let isFirstRun = false;
  
    const showModal = (e) => {
      setShow(true);
    };
  
    const handleClose = (e) => {
      setShow(false);
      setSellShow(false);
    };
  
    const refreshList = () => {
      fetch(Variables.API_URL + 'car')
        .then(response => response.json())
        .then(data => {
          setCars(data);
        });
        refreshCars();
            refreshSellers();
    }
    useEffect(() => {
      console.log('test');
      if (isFirstRun === false) {
        refreshList();
        console.log('test if');
        isFirstRun = true;
      }
    }, [])
    const sellClick = (e) => {
      setId(e.id);
      setSellShow(true);
    }
  
    const sellAction = (e) => {
      fetch(Variables.API_URL + 'car/' + id + '/sell/' + code, {
          method: 'POST',
          headers: {
            //  'Accept':'application/json',
            'Content-Type': 'application/json'
          }
  
        })
        .then(res => res.json())
        .then((result) => {
          refreshList();
          setSellShow(false);
        }, (error) => {
          refreshList();
          setSellShow(false);
        })
    }
    const addClick = (e) => {
      setModalTitle("Add car");
      setYear(0);
      setModel("");
      setMake("");
      setLicensePlate("");
      setDescription("");
      setInitialPrice(0);
      setShow(true);
    }
    const editClick = (c) => {
      setModalTitle("Edit car");
      setYear(c.year);
      setModel(c.model);
      setMake(c.make);
      setLicensePlate(c.licensePlate);
      setDescription(c.description);
      setInitialPrice(c.initialPrice);
      setShow(true);
    }
  
    const createClick = () => {
      fetch(Variables.API_URL + 'car', {
          method: 'POST',
          headers: {
            //'Accept':'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            year: year,
            model: model,
            make: make,
            licensePlate: licensePlate,
            description: description,
            initialPrice: initialPrice
          })
        })
        .then(res => res.json())
        .then((result) => {
          refreshList();
          setShow(false);
        }, (error) => {
          refreshList();
          setShow(false);
        })
    }
  
    const updateClick = () => {
      fetch(Variables.API_URL + 'car', {
          method: 'PUT',
          headers: {
            //  'Accept':'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            year: year,
            model: model,
            make: make,
            licensePlate: licensePlate,
            description: description,
            initialPrice: initialPrice
          })
        })
        .then(res => res.json())
        .then((result) => {
          refreshList();
          setShow(false);
        }, (error) => {
          refreshList();
          setShow(false);
        })
    }
    const [reportCars, setReportCars] = useState([]);
    const [sellers, setSellers] = useState([]);
    const refreshCars = () => {
        fetch(Variables.API_URL + 'report/car')
          .then(response => response.json())
          .then(data => {
            setReportCars(data);
          });
      }
      const refreshSellers = () => {
        fetch(Variables.API_URL + 'report/seller')
          .then(response => response.json())
          .then(data => {
            setSellers(data);
          });
      }

      
    return (
        <div>
        <h2>Cars</h2>

        <button type="button"
          className="btn btn-primary m-2 float-end"
         onClick={() => addClick()}
         >
          Add Car
        </button>
        <table className='table table-striped'>
          <thead>
            <tr>
              <th>year</th>
              <th>model</th>
              <th>make</th>
              <th>licensePlate</th>
              <th>description</th>
              <th>initialPrice</th>
              <th>shopCommission</th>
              <th>sellerCommission</th>
              <th>totalPrice</th>
              <th>sold</th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            {cars.map(c =>
              <tr key={c.id}>
                <td>{c.year}</td>
                <td>{c.model}</td>
                <td>{c.make}</td>
                <td>{c.licensePlate}</td>
                <td>{c.description}</td>
                <td>{c.initialPrice}</td>
                <td>{c.shopCommission}</td>
                <td>{c.sellerCommission}</td>
                <td>{c.totalPrice}</td>
                <td>{c.sold === true ? 'SOLD' : ''}</td>
                <td>
                  <button type="button" className='btn btn-warning mr-1'
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    //onClick={() => this.editClick(c)}
                    onClick={() => editClick(c)}
                    >Edit</button>
                
                  {c.sold !== true && <button type="button" className='btn btn-warning mr-1'
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    //onClick={() => this.editClick(c)}
                    onClick={() => sellClick(c)}
                    >Sell</button>}
                </td>

              </tr>)}
          </tbody>
        </table>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Car</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div className='input-group mb-3'>
              <span className='input-group-text'>year</span>
              <input type="text" className="form-control"
                value={year}
                onChange={changeYear}
                 />
            </div>
            <div className='input-group mb-3'>
              <span className='input-group-text'>model</span>
              <input type="text" className="form-control"
                value={model}
                onChange={changeModel}
                 />
            </div>
            <div className='input-group mb-3'>
              <span className='input-group-text'>make</span>
              <input type="text" className="form-control"
                value={make}
                onChange={changeMake} 
                />
            </div>
            <div className='input-group mb-3'>
              <span className='input-group-text'>licensePlate</span>
              <input type="text" className="form-control"
                value={licensePlate}
                onChange={changeLicensePlate} 
                />
            </div>
            <div className='input-group mb-3'>
              <span className='input-group-text'>description</span>
              <input type="text" className="form-control"
                value={description}
                onChange={changeDescription} 
                />
            </div>
            <div className='input-group mb-3'>
              <span className='input-group-text'>initialPrice</span>
              <input type="text" className="form-control"
                value={initialPrice}
               onChange={changeInitialPrice} 
                />
            </div>
            
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
            {id == 0 ?
              <Button type='button' className='btn btn-primary float-start' 
              onClick={() => createClick()}
              >OK</Button> : null
            }
            {id != 0 ?
              <Button type='button' className='btn btn-primary float-start' 
              onClick={() => updateClick()}
              >OK</Button> : null
            }
          </Modal.Footer>
        </Modal>
        <Modal show={sellShow} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Sell Car</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div className='input-group mb-3'>
              <span className='input-group-text'>Code</span>
              <input type="text" className="form-control"
                value={code}
                onChange={changeCode}
                 />
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
              <Button type='button' className='btn btn-primary float-start' 
              onClick={() => sellAction()}
              >Sell</Button> 
          </Modal.Footer>
        </Modal>
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
            {reportCars.map(c =>
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
        );
}
