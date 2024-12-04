import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { addNewStylist } from '../services/stylistServices';

export const NewStylistForm = () => {
  const [newStylist, setNewStylist] = useState({});
  const navigate = useNavigate();

  const handleOnChange = (event) => {
    const copyObj = { ...newStylist };
    copyObj[event.target.name] = event.target.value;
    setNewStylist(copyObj);
  };

  const handleAddBtnClick = (event) => {
    event.preventDefault();
    addNewStylist(newStylist).then(() => {
      navigate('/stylists');
    });
  };

  return (
    <form>
      <label>Name:</label>
      <input onChange={handleOnChange} type="text" name="name" />
      <button onClick={handleAddBtnClick}>Add new stylist</button>
    </form>
  );
};
