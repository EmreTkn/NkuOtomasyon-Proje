import React, { Component } from 'react'

export default class TeacherLessonsUpdate extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            students: {},
            lessonNumber : this.props.pushLessonNumber,
        }
    }
    async componentDidMount() {
         const requestOptions = {
             method: 'GET',
             headers: {
                 'Authorization': `Bearer `+this.state.token,
                 'Content-Type': `application/json`,
             }
         };
         const response = await fetch(process.env.REACT_APP_BASE_URL+'teacher/get-student-by-lesson?lessonCode='+this.state.lessonNumber,requestOptions);
         if(response.ok){
             const res = await response.json();
             this.setState({students: res});
         }
         else{
             const res = await response.json();
             alert(res.message)
         }
     }


    render() {
        return (
            <div className="h-100 bg-dark text-white">
            <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                {this.state.lessonNumber} Dersi Öğrencileri
             </div>
             <div className="table-responsive">
                         <table className="table table-striped table-sm text-white">
                         <thead>
                             <tr className="text-white" >
                             <th>Öğrenci Numarası</th>
                             <th>Öğrenci Adı</th>
                             <th>Öğrenim Programı</th>
                             </tr>
                         </thead>
                         <tbody>
                     {Object.values(this.state.students).map((student) =>
                             <tr key={student.studentNumber} className="text-white" >
                             <td>{student.studentNumber}</td>
                             <td>{student.fullName}</td>
                             <td>{student.studyPrograms}</td>
                             </tr>
                     )}
             </tbody>
             </table>
             </div>
         </div>
        )
    }
}
