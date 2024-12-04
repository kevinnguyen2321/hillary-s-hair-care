import './NavBar.css';
import { Link } from 'react-router-dom';

export const NavBar = () => {
  return (
    <div className="navbar-wrapper">
      <ul>
        <li>
          <Link to={'/'}>Home</Link>
        </li>
        <li>
          <Link to={'/stylists'}>Stylists</Link>
        </li>
        <li>Book Appointment</li>
        <li>
          <Link to={'/appointments'}>Appointments</Link>
        </li>
      </ul>
    </div>
  );
};
