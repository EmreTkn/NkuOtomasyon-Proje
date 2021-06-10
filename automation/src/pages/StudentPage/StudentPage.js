import React, { Component } from 'react'
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import ChangePassword from '../../components/ChangePassword/ChangePassword'
import OzlukBilgileri from '../../components/Student/OzlukBilgileri/OzlukBilgileri'
import OgrenimBilgileri from '../../components/Student/OgrenimBilgileri/OgrenimBilgileri'
import DonemDersKarnem from '../../components/Student/DonemDersKarnem/DonemDersKarnem'
import MufredatKarnem from '../../components/Student/MufredatKarnem/MufredatKarnem'
import HaftalikDersProgrami from '../../components/Student/HaftalikDersProgrami/HaftalikDersProgrami'
import DonemSinavProgrami from '../../components/Student/DonemSinavProgrami/DonemSinavProgrami'
import DonemDersNotlari from '../../components/Student/DonemDersNotlari/DonemDersNotlari'
import DersEkleKaldir from '../../components/Student/DersEkleKaldir/DersEkleKaldir'
import DersListeleme from '../../components/Student/DersListele/DersListele'

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
            case 'donemderskarnem':
                return <DonemDersKarnem  user={props.user}></DonemDersKarnem>;     
            case 'mufredatkarnem':
                return <MufredatKarnem  user={props.user}></MufredatKarnem>;   
            case 'haftalikdersprogramim':
                return <HaftalikDersProgrami  user={props.user}></HaftalikDersProgrami>;  
            case 'donemsinavprogramim':
                return <DonemSinavProgrami  user={props.user}></DonemSinavProgrami>;  
            case 'donemdersnotlarim':
                return <DonemDersNotlari  user={props.user}></DonemDersNotlari>;  
            case 'derseklekaldir':
                return <DersEkleKaldir  user={props.user}></DersEkleKaldir>;  
            case 'derslistele':
                return <DersListeleme  user={props.user}></DersListeleme>;  
          default:
            return <OzlukBilgileri  user={props.user}></OzlukBilgileri>;
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
