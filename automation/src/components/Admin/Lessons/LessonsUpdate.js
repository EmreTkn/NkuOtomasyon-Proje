import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";

export default class StudentUpdate extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            lessonNumber : this.props.pushLessonNumber,
            teachers: {},
            lastExamDate : '',
            finalExamDate: '',
            midExamDate: '',
            teacherCode: ''
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-teachers',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({teachers: res});
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
     }

     async handleUpdateExamTime(){
        const {lastExamDate,finalExamDate,midExamDate,lessonNumber} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ 
                midExamDate  : midExamDate,
                finalExamDate : finalExamDate,
                lastExamDate : lastExamDate,
                lessonCode  : lessonNumber,
            })
        };
   
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/update-exam-date', requestOptions);
        
        if(response.ok){
            const res = await response.json();
            alert(res.message)
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }

    async handleUpdateTeacher(){
        const {teacherCode,lessonNumber} = this.state;
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ 
                teacherCode : teacherCode,
                lessonCode  : lessonNumber,
            })
        };
   
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/update-lesson-teacher', requestOptions);
        
        if(response.ok){
            const res = await response.json();
            alert(res.message)
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
                   {this.props.pushLessonNumber} Kodlu Ders İçin Sınav Tarihi Güncelleme
                </div>
                 <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <div className="form-group">
                            <label htmlFor="midExamDate">Vize Sınavı Tarihi Giriniz.</label>
                            <input type="date" className="form-control" id="midExamDate" placeholder="Vize Tarihi"  onChange={(e) => this.setState({midExamDate :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="finalExamDate">Final Sınavı Tarihi Giriniz.</label>
                            <input type="date" className="form-control" id="finalExamDate" placeholder="Final Tarihi"  onChange={(e) => this.setState({finalExamDate :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="lastExamDate">Büt Sınavı Tarihi Giriniz.</label>
                            <input type="date" className="form-control" id="lastExamDate" placeholder="Büt Tarihi"  onChange={(e) => this.setState({lastExamDate :e.target.value})}></input>
                         </div>
                        <br/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleUpdateExamTime()} >Sınav Tarihi Güncelle</button>
                </main>

                <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                   {this.props.pushLessonNumber} Kodlu Ders İçin Öğretmen Güncelleme
                </div>
                 <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <div className="form-group">
                            <label htmlFor="teacherCode">Lütfen Öğretmen Seçiniz</label>
                            <select  className="form-control" id="teacherCode"  onChange={(e) => this.setState({teacherCode:e.target.value})}>
                            <option>-</option>
                            {Object.values(this.state.teachers).map((teacher) =>
                                <option value={teacher.id}>{teacher.firstName} {teacher.lastName}</option>
                            )}
                            </select>
                         </div>
                        <br/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleUpdateTeacher()} >Öğretmen Güncelle</button>
                </main>
            </div>
        )
    }
}
