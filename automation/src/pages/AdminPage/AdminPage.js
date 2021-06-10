import React, { Component } from 'react'
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import AdminStudents from '../../components/Admin/Students/Students'
import AdminStudentUpdate from '../../components/Admin/Students/StudentUpdate'
import AdminLessons from '../../components/Admin/Lessons/Lessons'
import AdminLessonsUpdate from '../../components/Admin/Lessons/LessonsUpdate'
import AdminTeachers from '../../components/Admin/Teachers/Teachers'
import ChangePassword from '../../components/ChangePassword/ChangePassword'
import Welcome from '../../components/Welcome/Welcome'
export default class AdminPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            userName: 'Caan',
            studentNumberForAdmin: '',
            lessonNumberForAdmin: '',
            sidebar: this.props.sidebar,
            user:this.props.user,
            contentPage: this.props.contentPage,
            loggedIn: this.props.loggedIn
        }
    }
    componentDidMount() {
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
             return <AdminLessons  takeLessonNumber={props.takeLessonNumber}  user={props.user}></AdminLessons>;  
        case 'adminlessonsupdate':
        return <AdminLessonsUpdate   pushLessonNumber={props.pushLessonNumber} user={props.user}></AdminLessonsUpdate>;       
         case 'adminteachers':
             return <AdminTeachers  user={props.user}></AdminTeachers>;     
        default:
            return <Welcome user={props.user}></Welcome>;
         }
       }

      
     takeStudentNumber = studentNumber => {
        this.setState({studentNumberForAdmin: studentNumber}, () => {
            console.log(this.state.studentNumberForAdmin);
        });
        this.props.history.push('/admin/students/update');  
      };
    
      takeLessonNumber = lessonNumber => {
        this.setState({lessonNumberForAdmin: lessonNumber}, () => {
            console.log(this.state.lessonNumberForAdmin);
        });
        this.props.history.push('/admin/lessons/update');  
      };

    render() {
        if (this.state.loggedIn != 2) {
            return <Redirect to="/login" />;
        }
        return (
            <div className={"studentPage d-flex"}>
                <Sidebar userName={this.state.userName} sidebarContent={this.state.sidebar}></Sidebar>
                <div className={"col-10 login-height-100"}>
                <this.SwitchCase value={this.props.contentPage} takeLessonNumber={this.takeLessonNumber} pushLessonNumber={this.state.lessonNumberForAdmin}  pushStudentNumber={this.state.studentNumberForAdmin} takeStudentNumber={this.takeStudentNumber} user={this.state.user}></this.SwitchCase>
                </div>
            </div>
        )
    }
}
