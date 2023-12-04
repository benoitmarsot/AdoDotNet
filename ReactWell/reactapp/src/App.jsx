import React, { useState, setState, useEffect, createContext } from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Routes, Route, useNavigate as navigate} from 'react-router-dom';
import Home from './pages/index.jsx';
import About from './pages/about.jsx';
import CreatePatient from './pages/createPatient.jsx';
import UpdatePatient from './pages/updatePatient.jsx';
import Assesment from './pages/assessment.jsx';
import SelectPatient from './pages/selectPatient.jsx';
import Profile from './pages/profile.jsx';
import SignUp from './pages/signup.jsx';
import SignIn from './pages/signIn.jsx';

const ProviderContext =createContext(null);
const PatientContext =createContext(null);

function App() {
    const [provider, setProvider] = useState(null);
    const [patient, setPatient] = useState(null);
    const changePatient=(newPatient) => {
        if(newPatient) {
            setPatient(newPatient);
            console.log("changePatient: ",newPatient);
        }
    }
    const changeProvider = (newProvider) => {
        setProvider(newProvider);
        console.log("changeProvider: ", newProvider);
        //window.location.href='/selectpatient';
        // if the provider has patients, then go to select patient else go to create patient
    }
    const providerId=(provider)?provider.providerId:0;
    const patientId=(patient)?patient.patientId:0;
    // useEffect(()=> {
    //     if(providerId!=0) {
    //         if(provider.patients) {
    //             //use 
    //             window.location.href='/selectpatient';
    //         } else {
    //             window.location.href='/createpatient';
    //         }
    //     }
    // });
    return (
        <ProviderContext.Provider value={{provider,setProvider}}>
            <PatientContext.Provider value={{patient,setPatient}}>
                <Router>
                    <Navbar  patientid={patientId} providerid={providerId} />
                    <Routes>
                        <Route path='/' element={<Home/>} />
                        <Route path='/about' element={<About/>} />
                        <Route path='/createpatient' element={<CreatePatient onChangePatient={changePatient} providerid={providerId} />} />
                        <Route path='/updatepatient' element={<UpdatePatient onChangePatient={changePatient} providerid={providerId}  />} /> //useContext(PatientContext)
                        <Route path='/Assesment' element={<Assesment providerid={providerId} patientid={patientId} />} />
                        <Route path='/selectpatient' element={<SelectPatient onChangePatient={changePatient} patientid={patientId} />} /> //useContext(ProviderContext)
                        <Route path='/profile' element={<Profile />} />  //useContext(ProviderContext)
                        <Route path='/sign-up' element={<SignUp onChangeProvider={changeProvider} />} />
                        <Route path='/signin' element={<SignIn onChangeProvider={changeProvider} />} />
                    </Routes>
                </Router>
            </PatientContext.Provider>
        </ProviderContext.Provider>
    );
}
export {App,ProviderContext,PatientContext};
