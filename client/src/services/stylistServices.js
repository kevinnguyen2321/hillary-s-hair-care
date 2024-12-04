export const getAllStylists = () => {
  return fetch('/api/stylists').then((res) => res.json());
};
