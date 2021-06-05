import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class DonemSinavProgrami extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            finalExam: {},
            midExam: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-final-exam',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({finalExam: res});
        }
        else{
            const res = await response.json();
            alert(res.message)
        }

        const response2 = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-mid-exam',requestOptions);
        if(response2.ok){
            const res = await response2.json();
            this.setState({midExam: res});
        }
        else{
            const res = await response2.json();
            alert(res.message)
        }
     }
    render() {
        return (
            <div className="h-100 bg-dark text-white">
               <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                    Ara Sınav
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Ders Kodu</th>
                                <th>Ders Adı</th>
                                <th>Dersi Veren</th>
                                <th>Sınav Tarihi</th>
                                <th>Sınav Yeri</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.state.midExam).map((mid) =>
                                <tr className="text-white" >
                                <td>{mid.lessonCode}</td>
                                <td>{mid.lessonName}</td>
                                <td>{mid.teacherName}</td>
                                <td>{mid.midExamDate}</td>
                                <td>{mid.classroomName}</td>
                                </tr>
                        )}
                </tbody>
                </table>
                </div>
                <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                    Dönem Sonu Sınavı
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Ders Kodu</th>
                                <th>Ders Adı</th>
                                <th>Dersi Veren</th>
                                <th>Sınav Tarihi</th>
                                <th>Sınav Yeri</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.state.finalExam).map((final) =>
                                <tr className="text-white" >
                                <td>{final.lessonCode}</td>
                                <td>{final.lessonName}</td>
                                <td>{final.teacherName}</td>
                                <td>{final.finalExamDate}</td>
                                <td>{final.classroomName}</td>
                                </tr>
                        )}
                </tbody>
                </table>
                </div>
          </div>
        )
    }
}
