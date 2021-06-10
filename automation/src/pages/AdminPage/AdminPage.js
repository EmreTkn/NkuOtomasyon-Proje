import React, { Component } from 'react'
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import AdminStudents from '../../components/Admin/Students/Students'
import AdminStudentUpdate from '../../components/Admin/Students/StudentUpdate'
import AdminLessons from '../../components/Admin/Lessons/Lessons'
import AdminTeachers from '../../components/Admin/Teachers/Teachers'
import ChangePassword from '../../components/ChangePassword/ChangePassword'

export default class AdminPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            // content = this.props.pageContent,
            userName: 'Caan',
            studentNumberForAdmin: ''
        }
    }
    componentDidMount() {
        // console.log(this.props.loggedIn);      
    }

     
    SwitchCase(props) {
        switch(props.value) {
          case 'sifredegistir':
            return <ChangePassword></ChangePassword>;
        case 'adminstudents':
            return <AdminStudents takeStudentNumber={props.takeStudentNumber}  user={props.user}></AdminStudents>;
        case 'adminstudentsupdate':
            return <AdminStudentUpdate pushStudentNumber={props.pushStudentNumber} user={props.user}></AdminStudentUpdate>;
        case 'adminlessons':
            return <AdminLessons  user={props.user}></AdminLessons>;     
        case 'adminteachers':
            return <AdminTeachers  user={props.user}></AdminTeachers>;     
          default:
            return <AdminStudents  user={props.user}></AdminStudents>;
        }
      }

      
     takeStudentNumber = studentNumber => {
        this.setState({studentNumberForAdmin: studentNumber}, () => {
            console.log(this.state.studentNumberForAdmin);
        });
        this.props.history.push('/admin/students/update');  
      };
    

    render() {
        // if (this.props.loggedIn != 1) {
        //     return <Redirect to="/login" />;
        // }
        return (
            <div className={"studentPage d-flex"}>
                <Sidebar userName={this.state.userName} sidebarContent={this.props.sidebar}></Sidebar>
                <div className={"col-10 login-height-100"}>
                <this.SwitchCase value={this.props.contentPage} pushStudentNumber={this.state.studentNumberForAdmin} takeStudentNumber={this.takeStudentNumber} user={this.props.user}></this.SwitchCase>
                </div>
            </div>
        )
    }
}
