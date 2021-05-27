import React, { Component } from "react";
import logo from "../../images/logo.png";
import { Link } from "react-router-dom";
import "./Sidebar.css";

export default class Sidebar extends Component {
  render() {
    return (
      <div className={"custom-sidebar col-2"}>
        <div className="d-flex w-100 flex-column flex-shrink-0 p-3 text-white bg-dark">
          <a
            href="/"
            className="d-flex  align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none"
          >
            <img src={logo} style={{ width: "100px" }} alt={"logo"}></img>
            <span className="fs-4">NKU</span>
          </a>
          <hr />
          <ul className="nav nav-pills flex-column mb-auto">
          {this.props.sidebarContent.map((sidebar) => (
                        <li key={sidebar.path}>
                        <Link to={sidebar.path} className={"nav-link text-white"}>
                          {" "}
                          {sidebar.name}
                        </Link>
                      </li>
          ))}
          </ul>
          <hr />
          <div className="dropdown">
            <a
              href="#"
              className="d-flex align-items-center text-white text-decoration-none dropdown-toggle"
              id="dropdownUser1"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              <strong>{this.props.userName}</strong>
            </a>
            <ul
              className="dropdown-menu dropdown-menu-dark text-small shadow"
              aria-labelledby="dropdownUser1"
            >
              <li>
                <Link to={"/logout"} className={"dropdown-item"}>
                  Çıkış Yap
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </div>
    );
  }
}
