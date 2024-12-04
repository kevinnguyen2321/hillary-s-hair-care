import { useEffect, useState } from 'react';
import { getAllAppointments } from '../services/appointmentServices';

export const AppointmentsList = () => {
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    getAllAppointments().then((data) => setAppointments(data));
  }, []);

  return (
    <div>
      <ul>
        {appointments.map((a) => {
          return (
            <li
              key={a.id}
            >{`Appointment booked by ${a.customer.name} with stylist ${a.stylist.name}`}</li>
          );
        })}
      </ul>
    </div>
  );
};
