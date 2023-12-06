import React, {useState,setState,useEffect} from 'react';
import {useNavigate} from 'react-router-dom';
import providerSvc from '../services/provider.js';

import './signup.css';

const SignUp = (props) => {
    const navigate=useNavigate();
    const [email, setEmail] = useState(null);
    const [password,setPassword] = useState(null);
    const [errorMsg,setErrorMsg] = useState(null);
    const onChangeProvider=props.onChangeProvider;
    const handleInputChange = (e) => {
        const {id , value} = e.target;
        if(id === "email"){
            setEmail(value);
        }
        if(id === "password"){
            setPassword(value);
        }
    };

    const handleSubmit  = () => {
        const provInfo={email:email,password:password};
        providerSvc.signIn(provInfo).then((provider)=>{
            if(provider.status===401) {
                setErrorMsg(provider.title);
                return;
            }
            console.log(provider);
            onChangeProvider(provider); 
            if(provider.patients) {
                return navigate('/selectpatient');
            } else {
                return navigate('/createpatient');
            }
        }, (error) => {
            setErrorMsg(!error.error?error:error.error);
        });
    };
    const Error= (props) => {
        return props.errorMsg
            ?(<div>{props.errorMsg}</div>)
            :'';
    };

    return (
        <div className="form">
            <div className="form-body">
                <div className="row">
                  <div className="col-25">
                    <label htmlFor="email">Email</label>
                  </div>
                  <div className="col-75">
                    <input type="text" id="email" name="email" placeholder="email.." onChange={handleInputChange}/>
                  </div>
                </div>
                <div className="row">
                  <div className="col-25">
                    <label htmlFor="password">Password</label>
                  </div>
                  <div className="col-75">
                    <input type="password"  id="password" name="password" placeholder="Password.." onChange={handleInputChange} />
                  </div>
                </div>
            </div>
            <div className="footer">
                <button onClick={handleSubmit} type="submit" className="btn">Sign in</button>
            </div>
            <Error errorMsg={errorMsg} />
        </div>

    );
};

export default SignUp;
