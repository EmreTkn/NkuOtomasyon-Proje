import React, { Component } from "react";
import {Link} from 'react-router-dom'

import './Cover.css';
import logo from "../../images/logo.png"


export default class Cover extends Component {
  render() {
    return (
      <div className="d-flex justify-content-center align-items-center cover-height-100 text-center text-white bg-dark">
        <div className="cover-container d-flex w-100 h-50 p-3 mx-auto flex-column">
          <main className="px-3">
            <div className="w-100 d-flex justify-content-center align-items-center">
              <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
            </div>
            <h1>Hoşgeldiniz!</h1>
            <p className="lead">
              Lütfen sisteme giriş yapmak için kullanıcı adınızı ve şifrenizi düzgün giriniz. 
            </p>
            <p className="lead">
              <Link to="/login" className={"btn btn-lg btn-secondary fw-bold border-white bg-white"}>Giriş Yap Sayfasına İlerle</Link>
            </p>
          </main>
        </div>    
      </div>
    );
  }
}
