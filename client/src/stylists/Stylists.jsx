import { useEffect, useState } from 'react';
import { getAllStylists } from '../services/stylistServices';
import { useNavigate } from 'react-router-dom';

export const Stylists = () => {
  const [stylists, setStylists] = useState([]);

  useEffect(() => {
    getAllStylists().then((data) => setStylists(data));
  }, []);

  const navigate = useNavigate();

  const handleAddNewStylistClick = () => {
    navigate('/stylists/new');
  };

  return (
    <div className="stylist-wrapper">
      <div className="stylist-list-wrapper">
        <button onClick={handleAddNewStylistClick}>Add new Stylist</button>
        <h2>List of Stylists</h2>
        <ul>
          {stylists.map((s) => {
            return <li key={s.id}>{s.name}</li>;
          })}
        </ul>
      </div>
    </div>
  );
};
