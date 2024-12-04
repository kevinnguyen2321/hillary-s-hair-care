import { useEffect, useState } from 'react';
import { deactivateStylist, getAllStylists } from '../services/stylistServices';
import { useNavigate } from 'react-router-dom';

export const Stylists = () => {
  const [stylists, setStylists] = useState([]);

  const fetchAndSetStylists = () => {
    getAllStylists().then((data) => setStylists(data));
  };

  useEffect(() => {
    fetchAndSetStylists();
  }, []);

  const navigate = useNavigate();

  const handleAddNewStylistClick = () => {
    navigate('/stylists/new');
  };

  const handlRemoveClick = (stylistId) => {
    deactivateStylist(stylistId).then(() => {
      fetchAndSetStylists();
    });
  };

  return (
    <div className="stylist-wrapper">
      <div className="stylist-list-wrapper">
        <button onClick={handleAddNewStylistClick}>Add new Stylist</button>
        <h2>List of Stylists</h2>
        <ul>
          {stylists.map((s) => {
            return (
              <li key={s.id}>
                {s.name}
                <button onClick={() => handlRemoveClick(s.id)}>Remove</button>
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
};
