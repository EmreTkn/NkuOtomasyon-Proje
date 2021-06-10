import React, { Component } from 'react'
import logo from "../../images/logo.png"
import { Redirect } from 'react-router';
export default class Register extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: '',
            name: '',
            surname: '',
            type:'',
            schoolnumber:''
        }
    }
    async handleRegister(){
        const {email,password,type,surname,name,schoolnumber} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({  
                schoolNumber  : schoolnumber,
                type : type,
                password :  password,
                email :email,
                lastName : surname,
                firstName : name,
            })
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'account/register', requestOptions);
        if(response.ok){
            const res = await response.json();
            alert(res.email + "ile kayıt oluşturuldu.")
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }

    render() {
        const role = localStorage.getItem('authRole');
         if (role != 2) {
             return <Redirect to="/login" />;
         }
        return (
            <div className="d-flex justify-content-center align-items-center login-height-100 text-center  bg-dark">
            <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <h1 className="h3 mb-3 fw-normal text-color-white">Lütfen Giriş Yapın</h1>
                         <div className="form-floating">
                            <input type="text" className="form-control" id="schoolnumber" placeholder="Okul Numarası"  onChange={(e) => this.setState({schoolnumber:e.target.value})}></input>
                            <label htmlFor="schoolnumber">Okul No</label>
                        </div>
                         <div className="form-floating">
                            <input type="text" className="form-control" id="ad" placeholder="Adı"  onChange={(e) => this.setState({name:e.target.value})}></input>
                            <label htmlFor="ad">Adı</label>
                        </div>
                        <div className="form-floating">
                            <input type="text" className="form-control" id="soyad" placeholder="Soyadı"  onChange={(e) => this.setState({surname:e.target.value})}></input>
                            <label htmlFor="soyad">Soyadı</label>
                        </div>
                         <div className="form-floating">
                            <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={(e) => this.setState({email:e.target.value})}></input>
                            <label htmlFor="floatingInput">Kullanıcı Adı</label>
                        </div>
                        <div className="form-floating">
                            <input type="password" className="form-control" id="floatingPassword" placeholder="Password"  onChange={(e) => this.setState({password:e.target.value})}></input>
                            <label htmlFor="floatingPassword">Şifre</label>
                        </div>
                        <div className="form-group">
                            <label htmlFor="type">Lütfen Tip Seçiniz</label>
                            <select  className="form-control" id="recordType"  onChange={(e) => this.setState({type:parseInt(e.target.value)})}>
                                <option>-</option>
                                <option value={2}>Admin</option>
                                <option value={0}>Öğrenci</option>
                                <option value={1}>Öğretmen</option>
                            </select>
                         </div>
                        <hr/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleRegister()} >Kayıt Ol</button>
                </main>
            </div>
        )
    }
}
