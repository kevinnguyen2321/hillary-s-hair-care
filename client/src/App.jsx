import { Route, Routes } from 'react-router-dom';
import { NavBar } from './navbar/NavBar';
import { Home } from './home/Home';
import { Stylists } from './stylists/Stylists';

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route path="/">
         <Route index element={<Home />}/>
          <Route path="stylists" element={<Stylists />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
