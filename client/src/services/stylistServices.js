export const getAllStylists = () => {
  return fetch('/api/stylists').then((res) => res.json());
};

export const addNewStylist = (stylistObj) => {
  return fetch('/api/stylists', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(stylistObj),
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to add stylist');
    }
    return response.json();
  });
};

export const deactivateStylist = (id) => {
  return fetch(`/api/stylists/${id}/deactivate`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to deactivate stylist');
    }
    return response.status;
  });
};
