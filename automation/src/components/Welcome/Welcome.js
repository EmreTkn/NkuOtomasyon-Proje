import React, { Component } from 'react'
import logo from "../../images/logo.png"
export default class Welcome extends Component {
    render() {
        return (
            <div className="col-12 h-100 flex-column d-flex align-items-center justift-content-center bg-dark text-white">
                <div className="py-5 text-center">
                <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                <h2>Hoşgeldiniz.</h2>
                </div>
            </div>
        )
    }
}
