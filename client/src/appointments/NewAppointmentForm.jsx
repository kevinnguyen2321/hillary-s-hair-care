import { useEffect, useState } from 'react';
import { getAllStylists } from '../services/stylistServices';
import { getAllServices } from '../services/services';
import { bookAppointment } from '../services/appointmentServices';
import { useNavigate } from 'react-router-dom';

export const NewAppointmentForm = () => {
  const [stylists, setStylists] = useState([]);
  const [services, setServices] = useState([]);
  const [newAppointment, setNewAppointment] = useState({
    appointmentServices: [],
  });

  const navigate = useNavigate();

  useEffect(() => {
    getAllStylists().then((data) => setStylists(data));

    getAllServices().then((data) => setServices(data));
  }, []);

  const handleOnChange = (event) => {
    const copyObj = { ...newAppointment };

    copyObj[event.target.name] = parseInt(event.target.value);
    setNewAppointment(copyObj);
  };

  const handleServiceChange = (serviceId) => {
    const copyObj = { ...newAppointment };

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

    setNewAppointment(copyObj);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    // Send newAppointment to your API
    if (
      !newAppointment.customerId ||
      !newAppointment.stylistId ||
      !newAppointment.appointmentServices ||
      !newAppointment.scheduledTime
    ) {
      alert('Please fill out all fields before submitting');
    } else {
      bookAppointment(newAppointment).then(() => navigate('/appointments'));
    }
  };

  return (
    <div>
      <h2>New Appointment</h2>
      <form>
        <div>
          <label id="customerId">Customer Id:</label>
          <input
            type="text"
            id="customerId"
            onChange={handleOnChange}
            name="customerId"
          />
        </div>
        <div>
          <label id="stylist">Stylist: </label>
          <select name="stylistId" onChange={handleOnChange}>
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
                  type="checkbox"
                  value={service.id}
                  checked={newAppointment.appointmentServices.some(
                    (s) => s.serviceId === service.id
                  )}
                  onChange={() => handleServiceChange(service.id)}
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
          onChange={(e) =>
            setNewAppointment({
              ...newAppointment,
              scheduledTime: e.target.value,
            })
          }
        />

        <button onClick={handleSubmit} type="submit">
          Book Appointment
        </button>
      </form>
    </div>
  );
};
