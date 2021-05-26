import React, { Component } from 'react'
import { Redirect } from 'react-router';

export default class ChangePassword extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: ''
        }
    }
    async handleForget(){
        const {email} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({email: email})
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'account/send-forgot-mail', requestOptions);
        if(response.ok){
            const res = await response.json();
            if(res.statusCode == 200){
                alert(res.message)
                this.props.history.push('/login');     
            }
            else{
                alert(res.message)
            }
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }
    render() {
        return (
            <div className="col-12 d-flex justify-content-center align-items-center login-height-100 text-center bg-dark">
            <main className="form-signin">
                         <h1 className="h3 mb-3 fw-normal text-color-white">Lütfen Mail Adresinizi Yazınız</h1>
                         <div className="form-floating">
                            <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={(e) => this.setState({email:e.target.value})}></input>
                            <label htmlFor="floatingInput">Email Adresi</label>
                        </div>
                        <hr/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleForget()} >Giriş Yap</button>
                </main>
            </div>
        )
    }
}
