import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Cover from './pages/Cover/Cover'
import LoginPage from './pages/LoginPage/Login'
import TeacherPage from './pages/TeacherPage/TeacherPage'
import StudentPage from './pages/StudentPage/StudentPage'
import AdminPage from './pages/AdminPage/AdminPage'
import Logout from './pages/Logout/Logout'
import ForgotPassword from './pages/ForgotPassword/ForgotPassword'


import React, { Component } from 'react'
import ChangePassword from './components/ChangePassword/ChangePassword';
export const STATE_LOGGED_IN = 'logged';
export const STATE_LOGGED_OUT = 'no-login';
export default class App extends Component {
  constructor(){
    super();

    this.state = {
      loggedIn: STATE_LOGGED_OUT,
      user: '',
      email: '',
      newPasswordToken: '',
      newPasswordEmail: '',
      studentNumberForAdmin: ''
    };
  }

  handleLogin = (data) => {
    this.setState({
      loggedIn: data.type,
      user: data.token,
      email: data.email,
    },()=>{});
  };

  handleLogout = () => {
    localStorage.removeItem("authToken")
    localStorage.removeItem("authRole")
    this.setState({
      loggedIn: STATE_LOGGED_OUT,
      user: '',
      mail: ''
    },()=>{});
  };
  
  componentDidMount() {
     this.setState({
       loggedIn: localStorage.getItem('authRole'),
       user: localStorage.getItem('authToken'),
       email: localStorage.getItem("authMail")
     },()=>{
      }
    );
 }
  
  render() {
    const studentSidebar = [
      {
        path: '/student/ozlukbilgilerim',
        name: 'Özlük Bilgilerim'
      },
      {
        path: '/student/ogrenimbilgilerim',
        name: 'Öğrenim Bilgilerim'
      },
      {
        path: '/sifredegistir',
        name: 'Şifre Değiştirme'
      },
      {
        path: '/student/donemderskarnem',
        name: 'Dönem Ders Karnem'
      },
      {
        path: '/student/mufredatkarnem',
        name: 'Müfredat Karnem'
      },
      {
        path: '/student/haftalikdersprogramim',
        name: 'Haftalık Ders Programım'
      },
      {
        path: '/student/donemsinavprogramim',
        name: 'Dönem Sınav Programım'
      },
      {
        path: '/student/donemdersnotlarim',
        name: 'Dönem Ders Notlarım'
      },
      {
        path: '/student/derseklekaldir',
        name: 'Ders Ekle/Kaldır'
      },
      {
        path: '/student/derslistele',
        name: 'Ders Listele'
      }
    ];
    const adminSidebar = [
      {
        path: '/admin/students',
        name: 'Öğrenci Listesi'
      },
      {
        path: '/admin/teachers',
        name: 'Öğretmen Listesi'
      },
      {
        path: '/admin/lessons',
        name: 'Ders Listesi'
      },
      {
        path: '/sifredegistir',
        name: 'Şifre Değiştirme'
      },
    ];
    
    return (
      <div className="App">
      <Router>
        <Switch>
          <Route path="/" exact><Cover></Cover></Route>
          <Route exact path="/logout" render={props => ( <Logout {... props} handleLogout={this.handleLogout}/>)} />
          <Route exact path="/login" render={props => ( <LoginPage {... props} handleLogin={this.handleLogin}  loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/teacher" render={props => (<TeacherPage {... props} user={this.state.user}  loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/forgot-password" render={props => (<ForgotPassword {... props}/>)} />
          <Route exact path="/sifredegistir" render={props => (<ChangePassword {... props}/>)} />

          {/* STUDENT PAGE */}
          <Route exact path="/student" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/derslistele" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'derslistele'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/ozlukbilgilerim" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'ozlukbilgilerim'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/ogrenimbilgilerim" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'ogrenimbilgilerim'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/donemderskarnem" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'donemderskarnem'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/mufredatkarnem" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'mufredatkarnem'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/haftalikdersprogramim" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'haftalikdersprogramim'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/donemsinavprogramim" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'donemsinavprogramim'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/donemdersnotlarim" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'donemdersnotlarim'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student/derseklekaldir" render={props => (<StudentPage {... props} user={this.state.user} sidebar={studentSidebar} contentPage={'derseklekaldir'} loggedIn={this.state.loggedIn}/>)} />


          {/* ADMIN PAGE */}
          <Route exact path="/admin" render={props => (<AdminPage {... props} user={this.state.user} sidebar={adminSidebar} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin/students" render={props => (<AdminPage {... props}  user={this.state.user} sidebar={adminSidebar} contentPage={'adminstudents'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin/students/update" render={props => (<AdminPage {... props} user={this.state.user}  sidebar={adminSidebar} contentPage={'adminstudentsupdate'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin/lessons/update" render={props => (<AdminPage {... props} user={this.state.user}  sidebar={adminSidebar} contentPage={'adminlessonsupdate'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin/lessons" render={props => (<AdminPage {... props} user={this.state.user} sidebar={adminSidebar} contentPage={'adminlessons'} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin/teachers" render={props => (<AdminPage {... props} user={this.state.user} sidebar={adminSidebar} contentPage={'adminteachers'} loggedIn={this.state.loggedIn}/>)} />


          <script src="https://unpkg.com/react/umd/react.production.min.js"></script>

          <script
            src="https://unpkg.com/react-dom/umd/react-dom.production.min.js"
            ></script>

          <script
            src="https://unpkg.com/react-bootstrap@next/dist/react-bootstrap.min.js"
          ></script>
       </Switch>
      </Router>
    </div>
    )
  }
}
