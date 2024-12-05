import { Route, Routes } from 'react-router-dom';
import { NavBar } from './navbar/NavBar';
import { Home } from './home/Home';
import { Stylists } from './stylists/Stylists';
import { NewStylistForm } from './stylists/NewStylistForm';
import { AppointmentsList } from './appointments/AppointmentsList';
import { AppointmentDetails } from './appointments/AppointmentDetails';
import { NewAppointmentForm } from './appointments/NewAppointmentForm';
import { EditAppointment } from './appointments/EditAppointment';
import { NewCustomerForm } from './customers/NewCustomerForm';

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route path="/">
          <Route index element={<Home />} />
          <Route path="stylists">
            <Route index element={<Stylists />} />
            <Route path="new" element={<NewStylistForm />} />
          </Route>
          <Route path="appointments">
            <Route index element={<AppointmentsList />} />
            <Route path=":appointmentId" element={<AppointmentDetails />} />
            <Route path="book" element={<NewAppointmentForm />} />
            <Route path="edit/:appointmentId" element={<EditAppointment />} />
          </Route>
          <Route path="customers/new" element={<NewCustomerForm />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
