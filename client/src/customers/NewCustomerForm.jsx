import { useState } from 'react';
import { addNewCustomer } from '../services/customerServices';
import { useNavigate } from 'react-router-dom';

export const NewCustomerForm = () => {
  const [newCustomer, setNewCustomer] = useState({});
  const navigate = useNavigate();

  const handleOnChange = (event) => {
    const copyObj = { ...newCustomer };
    copyObj[event.target.name] = event.target.value;

    setNewCustomer(copyObj);
  };

  const handleAddClick = (event) => {
    event.preventDefault();
    if (!newCustomer.name) {
      alert('Please enter a name');
    } else {
      addNewCustomer(newCustomer).then(() => navigate('/'));
    }
  };

  return (
    <form>
      <label id="name">Customer Name:</label>
      <input onChange={handleOnChange} type="text" name="name" id="name" />
      <button onClick={handleAddClick}>Add new customer</button>
    </form>
  );
};
