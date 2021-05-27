import React, { Component } from 'react'
import logo from "../../images/logo.png"
import queryString from 'query-string'

export default class ForgotPassword extends Component {
    constructor(props){
        super(props);
        this.state = {
            password: '',
            token:'',
            email:''
        }
    }
    async handleForgotPassword(){
        const {email,token,password} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({email: email,password: password,token: token})
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'account/reset-password', requestOptions);
        if(response.ok){
            const res = await response.json();
            if(res.statusCode == 200){
                this.props.history.push('/login');     
            }
            else{
                alert(res.message);
                this.props.history.push('/sifredegistir');  
            }
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }
    componentDidMount() {
        const value=queryString.parse(this.props.location.search);
        const token=value.token;
        this.setState({
            token: token
        },()=>{
          console.log(this.state.token);
         }
       );
     }
    render() {
        return (
            <div className="d-flex justify-content-center align-items-center login-height-100 text-center  bg-dark">
            <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <h1 className="h3 mb-3 fw-normal text-color-white">Yeni Şifrenizi Giriniz.</h1>
                         <div className="form-floating">
                            <input type="email" className="form-control" id="floatingPassword" placeholder="Email"  onChange={(e) => this.setState({email:e.target.value})}></input>
                            <label htmlFor="floatingPassword">Mail Adresi</label>
                        </div>
                        <div className="form-floating">
                            <input type="password" className="form-control" id="floatingPassword" placeholder="Password"  onChange={(e) => this.setState({password:e.target.value})}></input>
                            <label htmlFor="floatingPassword">Yeni Şifre</label>
                        </div>
                        <hr/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleForgotPassword()} >Şifremi Yenile</button>
                </main>
            </div>
        )
    }
}
