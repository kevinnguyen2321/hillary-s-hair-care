import { useEffect, useState } from 'react';
import { getAllAppointments } from '../services/appointmentServices';
import { useNavigate } from 'react-router-dom';

export const AppointmentsList = () => {
  const [appointments, setAppointments] = useState([]);

  const navigate = useNavigate();

  useEffect(() => {
    getAllAppointments().then((data) => setAppointments(data));
  }, []);

  const handleDetailsBtnClick = (id) => {
    navigate(`/appointments/${id}`);
  };

  return (
    <div>
      <ul>
        {appointments.map((a) => {
          return (
            <li key={a.id}>
              {`Appointment booked by ${a.customer.name} with stylist ${a.stylist.name}`}
              <button onClick={() => handleDetailsBtnClick(a.id)}>
                Details
              </button>
            </li>
          );
        })}
      </ul>
    </div>
  );
};
