import React, { Component } from 'react'
import { Redirect } from 'react-router';
import Sidebar from '../../components/Sidebar/Sidebar'
import ChangePassword from '../../components/ChangePassword/ChangePassword'
import Welcome from '../../components/Welcome/Welcome'
import TeacherLessons from '../../components/Teacher/TeacherLessons'
import TeacherLessonsUpdate from '../../components/Teacher/TeacherLessonsUpdate'
export default class TeacherPage extends Component {
    constructor(props){
        super(props);
        this.state = {
            userName: this.props.name,
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
         case 'teacherlessons':
             return <TeacherLessons takeLessonNumber={props.takeLessonNumber}  user={props.user}></TeacherLessons>;
          case 'teacherlessonsupdate':
        return <TeacherLessonsUpdate pushLessonNumber={props.pushLessonNumber}  user={props.user}></TeacherLessonsUpdate>;
        default:
            return <Welcome user={props.user}></Welcome>;
         }
       }

      takeLessonNumber = lessonNumber => {
        this.setState({lessonNumberForAdmin: lessonNumber}, () => {
            console.log(this.state.lessonNumberForAdmin);
        });
        this.props.history.push('/teacher/lessons/update');  
      };

    render() {
        if (this.state.loggedIn != 1) {
            return <Redirect to="/login" />;
        }
        return (
            <div className={"studentPage d-flex"}>
                <Sidebar userName={this.state.userName} sidebarContent={this.state.sidebar}></Sidebar>
                <div className={"col-10 login-height-100"}>
                <this.SwitchCase value={this.props.contentPage} takeLessonNumber={this.takeLessonNumber} pushLessonNumber={this.state.lessonNumberForAdmin} user={this.state.user}></this.SwitchCase>
                </div>
            </div>
        )
    }
}
