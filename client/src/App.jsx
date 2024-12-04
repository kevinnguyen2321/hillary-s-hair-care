import { Route, Routes } from 'react-router-dom';
import { NavBar } from './navbar/NavBar';
import { Home } from './home/Home';
import { Stylists } from './stylists/Stylists';
import { NewStylistForm } from './stylists/NewStylistForm';

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
        </Route>
      </Routes>
    </>
  );
}

export default App;
