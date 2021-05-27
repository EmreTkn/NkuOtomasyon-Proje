import React, { Component } from 'react'
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import ChangePassword from '../../components/ChangePassword/ChangePassword'
import OzlukBilgileri from '../../components/Student/OzlukBilgileri/OzlukBilgileri'
import OgrenimBilgileri from '../../components/Student/OgrenimBilgileri/OgrenimBilgileri'

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
            case 'ozlukbilgilerim':
                return <OzlukBilgileri  user={props.user}></OzlukBilgileri>;
            case 'ogrenimbilgilerim':
                return <OgrenimBilgileri  user={props.user}></OgrenimBilgileri>;     
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
                <div className={"col-10 login-height-100"}>
                <this.SwitchCase value={this.props.contentPage} user={this.props.user}></this.SwitchCase>
                </div>
            </div>
        )
    }
}
