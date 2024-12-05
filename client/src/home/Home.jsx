import { Outlet, useNavigate } from 'react-router-dom';

export const Home = () => {
  const navigate = useNavigate();
  const handleNewCustomerClick = () => {
    navigate('customers/new');
  };

  return (
    <div>
      <div>
        <button onClick={handleNewCustomerClick}>Add new customer</button>
        <h2>Welcome to Hillary's Hair Care Salon</h2>
        <Outlet />
      </div>
    </div>
  );
};
