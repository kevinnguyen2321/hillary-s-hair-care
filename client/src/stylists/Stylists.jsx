import { useEffect, useState } from 'react';
import { getAllStylists } from '../services/stylistServices';

export const Stylists = () => {
  const [stylists, setStylists] = useState([]);

  useEffect(() => {
    getAllStylists().then((data) => setStylists(data));
  }, []);
  
  
  return <div className='stylist-wrapper'>
    <div className='stylist-list-wrapper'>
      
      <h2>List of Stylists</h2>
      <ul>
        {stylists.map(s => {
          return <li key={s.id}>{s.name}</li>
        })}
      </ul>
    </div>
  </div>
};
