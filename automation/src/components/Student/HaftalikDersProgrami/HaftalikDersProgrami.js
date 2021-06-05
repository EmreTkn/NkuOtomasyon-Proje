import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class OgrenimBilgileri extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            userProgram: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-lessons-dates',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({userProgram: res});
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
              Haftalık Ders Programı
            </div>
            <div className="table-responsive">
              <table className="table table-striped table-sm text-white">
                <tr className="text-white border-line">
                <th></th>
                    <th>1.Ders</th>
                    <th>2.Ders</th>
                    <th>3.Ders</th>
                    <th>4.Ders</th>
                    <th>5.Ders</th>
                    <th>6.Ders</th>
                    <th>7.Ders</th>
                    <th>8.Ders</th>
                </tr>
                <tr className="border-line">
                    <th>Pazartesi</th> 
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 1}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 2}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 3}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 4}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 5}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 6}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 7}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 0 && program.lessonStartHour == 8}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                </tr>
                <tr className="border-line">
                    <th>Salı</th> 
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 1}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 2}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 3}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 4}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 5}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 6}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 7}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 1 && program.lessonStartHour == 8}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                </tr>
                <tr className="border-line">
                    <th>Çarşamba</th> 
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 1}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 2}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 3}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 4}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 5}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 6}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 7}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 2 && program.lessonStartHour == 8}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                </tr>
                <tr className="border-line">
                    <th>Perşembe</th> 
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 1}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 2}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 3}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 4}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 5}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 6}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 7}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 3 && program.lessonStartHour == 8}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                </tr>
                <tr className="border-line">
                    <th>Cuma</th> 
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 1}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 2}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 3}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 4}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 5}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 6}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 7}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                    <td> {Object.values(this.state.userProgram).map((program) =>
                    <If condition={program.lessonDay == 4 && program.lessonStartHour == 8}>
                    <Then>
                     {program.lessonName}
                    </Then>
                    </If>
                    )}</td>
                </tr>
              </table>
            </div>
          </div>
        )
    }
}
