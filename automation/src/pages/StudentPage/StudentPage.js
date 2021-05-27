import React, { Component } from 'react'
import { STATE_LOGGED_IN, STATE_LOGGED_OUT } from '../../App';
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import ChangePassword from '../../components/ChangePassword/ChangePassword'
import {
    BrowserRouter as Router,
    Switch,
    Route
  } from "react-router-dom";
import './StudentPage.css';

export default class StudentPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            // content = this.props.pageContent,
            userName: 'Caan'
        }
    }
    componentDidMount() {
        // console.log(this.props.loggedIn);      
    }
    SwitchCase(props) {
        switch(props.value) {
          case 'sifredegistir':
            return <ChangePassword></ChangePassword>;
          default:
            return 'Hoşgeldiniz';
        }
      }
    render() {
        if (this.props.loggedIn != 0) {
            return <Redirect to="/login" />;
        }
        return (
            <div className={"studentPage d-flex"}>
                <Sidebar userName={this.state.userName} sidebarContent={this.props.sidebar}></Sidebar>
                <this.SwitchCase value={this.props.contentPage}></this.SwitchCase>
            </div>
        )
    }
}
