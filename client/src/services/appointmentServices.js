export const getAllAppointments = () => {
  return fetch('/api/appointments').then((res) => res.json());
};

export const getAppointmentById = (id) => {
  return fetch(`/api/appointments/${id}`).then((res) => res.json());
};

export const bookAppointment = (appointmentObj) => {
  return fetch('/api/appointments', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(appointmentObj),
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to add appointment');
    }
    return response.json();
  });
};
