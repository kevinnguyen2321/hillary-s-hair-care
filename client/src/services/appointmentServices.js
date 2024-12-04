export const getAllAppointments = () => {
  return fetch('/api/appointments').then((res) => res.json());
};
