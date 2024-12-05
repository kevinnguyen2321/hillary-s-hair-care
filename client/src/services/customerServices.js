export const addNewCustomer = (customerObj) => {
  return fetch('/api/customers', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(customerObj),
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to add customer');
    }
    return response.json();
  });
};
