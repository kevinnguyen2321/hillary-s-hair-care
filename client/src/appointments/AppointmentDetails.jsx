import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAppointmentById } from '../services/appointmentServices';

export const AppointmentDetails = () => {
  const [appointment, setAppointment] = useState({
    appointmentServices: [],
  });

  const { appointmentId } = useParams();

  useEffect(() => {
    getAppointmentById(appointmentId).then((data) => setAppointment(data));
  }, [appointmentId]);

  // Map through the appointment services and format them
  const serviceNames = appointment.appointmentServices.map((aps, index) => {
    if (index !== appointment.appointmentServices.length - 1) {
      return `${aps.service.name} ($${aps.service.price}), `; // Create a string for each service
    } else {
      return `${aps.service.name} ($${aps.service.price}) `;
    }
  });

  return (
    <div>
      <h2>Appointment</h2>
      <p>
        <strong>Stylist: </strong>
        {appointment.stylist?.name}
      </p>
      <p>
        <strong>Customer:</strong> {appointment.customer?.name}
      </p>
      <p>
        <strong>Services: </strong>
        {serviceNames.length > 0 ? (
          serviceNames.map((s, index) => {
            return <span key={index}>{s}</span>;
          })
        ) : (
          <span>No services found for this appointment</span>
        )}
      </p>

      <p>
        <strong>Total cost:</strong>${appointment.totalPrice}
      </p>
    </div>
  );
};
