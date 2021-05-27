import React, { Component } from 'react'
import './Login.css';
import logo from "../../images/logo.png"
import { Redirect } from 'react-router';
export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: '',
            role:'',
        }
    }
    async handleLogin(){
        const {email,password} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({  email: email,
                password: password })
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'account/login', requestOptions);
        if(response.ok){
            const res = await response.json();
            localStorage.setItem("authToken", res.token)
            localStorage.setItem("authRole", res.type)
            localStorage.setItem("authMail", res.email)
            this.handleSuccessfullAuth(res);
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }


     handleSuccessfullAuth(data){
        this.props.handleLogin(data);
        if(data.type === 0){
            this.props.history.push('/student');
          }
          else if(data.type === 1){
            this.props.history.push('/teacher');
          }
          else if(data.type === 2){
            this.props.history.push('/admin');
          }
    }

     async componentDidMount(){
       
    }


    render() {
        if (this.props.loggedIn == 0) {
            return <Redirect to="/student" />;
        }
        else if (this.props.loggedIn == 1) {
            return <Redirect to="/teacher" />;
        }
        else if (this.props.loggedIn == 2) {
            return <Redirect to="/admin" />;
        }
        return (
            <div className="d-flex justify-content-center align-items-center login-height-100 text-center  bg-dark">
            <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <h1 className="h3 mb-3 fw-normal text-color-white">Lütfen Giriş Yapın</h1>
                         <div className="form-floating">
                            <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={(e) => this.setState({email:e.target.value})}></input>
                            <label htmlFor="floatingInput">Kullanıcı Adı</label>
                        </div>
                        <div className="form-floating">
                            <input type="password" className="form-control" id="floatingPassword" placeholder="Password"  onChange={(e) => this.setState({password:e.target.value})}></input>
                            <label htmlFor="floatingPassword">Şifre</label>
                        </div>
                        <hr/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleLogin()} >Giriş Yap</button>
                </main>
            </div>
        )
    }
}
