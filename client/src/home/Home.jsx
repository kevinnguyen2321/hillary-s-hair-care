import { Outlet } from 'react-router-dom';

export const Home = () => {
  return (
    <div>
      <div>
        <h2>Welcome to Hillary's Hair Care Salon</h2>
        <Outlet />
      </div>
    </div>
  );
};
