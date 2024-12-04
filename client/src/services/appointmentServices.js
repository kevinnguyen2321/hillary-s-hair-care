export const getAllAppointments = () => {
  return fetch('/api/appointments').then((res) => res.json());
};

export const getAppointmentById = (id) => {
  return fetch(`/api/appointments/${id}`).then((res) => res.json());
};
