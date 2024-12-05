import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import {
  getAppointmentById,
  updateAppointment,
} from '../services/appointmentServices';
import { getAllStylists } from '../services/stylistServices';
import { getAllServices } from '../services/services';

export const EditAppointment = () => {
  const [appointment, setAppointment] = useState({});
  const [stylists, setStylists] = useState([]);
  const [services, setServices] = useState([]);
  const { appointmentId } = useParams();

  const navigate = useNavigate();

  useEffect(() => {
    getAppointmentById(appointmentId).then((data) => {
      // Transform appointmentServices to only include serviceId
      const transformedData = {
        ...data,
        appointmentServices: data.appointmentServices.map((aps) => ({
          serviceId: aps.serviceId,
        })),
      };
      setAppointment(transformedData);
    });

    getAllStylists().then((data) => setStylists(data));

    getAllServices().then((data) => setServices(data));
  }, [appointmentId]);

  // Function to format the datetime-local value
  const formatDateTime = (isoString) => {
    if (!isoString) return '';
    const date = new Date(isoString);
    return date.toISOString().slice(0, 16); // Trim to yyyy-MM-ddTHH:mm
  };

  const handleOnChange = (event) => {
    const copyObj = { ...appointment };

    copyObj[event.target.name] = parseInt(event.target.value);
    setAppointment(copyObj);
  };

  const handleServiceChange = (serviceId) => {
    const copyObj = { ...appointment };

    // Check if the serviceId already exists in appointmentServices
    const existingService = copyObj.appointmentServices.find(
      (service) => service.serviceId === serviceId
    );

    if (existingService) {
      // Remove the service if already selected
      copyObj.appointmentServices = copyObj.appointmentServices.filter(
        (service) => service.serviceId !== serviceId
      );
    } else {
      // Add the service as an object with serviceId
      copyObj.appointmentServices = [
        ...copyObj.appointmentServices,
        { serviceId: serviceId },
      ];
    }

    setAppointment(copyObj);
  };

  const handleUpdateClick = (event) => {
    event.preventDefault();
    if (
      !appointment.scheduledTime ||
      !appointment.stylistId ||
      !appointment.appointmentServices
    ) {
      alert('Please fill out all forms before submitting');
    } else {
      updateAppointment(appointmentId, appointment).then(() =>
        navigate('/appointments')
      );
    }
  };

  return (
    <form>
      <h2>Edit Appointment</h2>

      <div>
        <label id="stylist">Stylist: </label>
        <select
          name="stylistId"
          value={appointment.stylistId ?? ''}
          onChange={handleOnChange}
        >
          <option value={''}>--Please choose a stylist</option>
          {stylists.map((s) => {
            return (
              <option key={s.id} value={s.id}>
                {s.name}
              </option>
            );
          })}
        </select>
      </div>

      <fieldset>
        <legend>Select Services</legend>
        {services.map((service) => (
          <div key={service.id}>
            <label>
              <input
                onChange={() => handleServiceChange(service.id)}
                type="checkbox"
                value={service.id}
                checked={appointment.appointmentServices?.some(
                  (s) => s.serviceId === service.id
                )}
              />
              {service.name} - ${service.price}
            </label>
          </div>
        ))}
      </fieldset>

      <label htmlFor="scheduledTime">Choose a Time:</label>
      <input
        type="datetime-local"
        id="scheduledTime"
        name="scheduledTime"
        value={formatDateTime(appointment.scheduledTime) ?? ''}
        onChange={(e) =>
          setAppointment({
            ...appointment,
            scheduledTime: e.target.value,
          })
        }
      />

      <button onClick={handleUpdateClick}>Update appointment</button>
    </form>
  );
};
