import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import logo from "../../images/logo.png"

export default class Header extends Component {
    render() {
        return (
            <div>
                <header>
                    <div className="px-3 py-2 bg-dark text-white">
                    <div className="container">
                        <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                        <a href="/" className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                            <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                        </a>

                        <ul className="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-small">
                            <li>
                            <a href="#" className="nav-link text-secondary">
                                {this.props.userName}
                            </a>
                            </li>        
                            <li>
                                <Link to={'/logout'} className={"nav-link text-white"}>Çıkış Yap</Link>
                            </li>
                        </ul>
                        </div>
                    </div>
                    </div>
                </header>
            </div>
        )
    }
}
