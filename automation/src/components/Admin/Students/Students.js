import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class Students extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            students: {},
        }
    }
    async componentDidMount() {
        const requestOptions = {
            method: 'GET',
            headers: {
                // 'Authorization': `Bearer `+this.state.token,
                'Content-Type': `application/json`,
            }
        };
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-all-students',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({students: res});
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
     }

     handleGoUpdatePage(studentNumber){
         this.props.takeStudentNumber(studentNumber);
    }

    render() {
        return (
            <div className="h-100 bg-dark text-white">
               <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                   Öğrenciler
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Öğrenci Adı</th>
                                <th>Öğrenci Numarası</th>
                                <th>Okuduğu Bölüm</th>
                                <th>İşlemler</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.state.students).map((student) =>
                                <tr key={student.studentNumber} className="text-white" >
                                <td>{student.fullName}</td>
                                <td>{student.studentNumber}</td>
                                <td>{student.studyPrograms}</td>
                                <td><button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit" onClick={(e) => this.handleGoUpdatePage(student.studentNumber)} >Düzenle</button></td>
                                </tr>
                        )}
                </tbody>
                </table>
                </div>
            </div>
        )
    }
}
