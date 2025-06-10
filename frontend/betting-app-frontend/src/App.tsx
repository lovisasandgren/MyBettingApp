import { Route, Routes } from 'react-router-dom'
import './App.css'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import Home from './routes/home/home'
import NavigationBar from './routes/navigationBar/navigationBar'
import SignUps from './routes/signUps/signUps'

function App() {

  return (
    <Routes>
      <Route path="/" element={<NavigationBar />}>
      <Route path="/" element={<Home/>} />
      <Route path="/signup" element={<SignUps/>} />
      </Route>
    </Routes>
  )
}

export default App
