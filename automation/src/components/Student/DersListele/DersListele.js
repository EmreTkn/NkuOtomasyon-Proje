import React, { Component } from 'react'
import logo from "../../../images/logo.png"


export default class DersListele extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            lessons: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'student/get-lessons',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({lessons: res});
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
     }

     async handlePDF(lessonNumber){
        const requestOptions = {
            method: 'GET',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': 'application/json',
            }
        };
        const response = await fetch(process.env.REACT_APP_BASE_URL+'student/get-pdf?lessonCode='+lessonNumber, requestOptions);
         
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
                    Ara Sınav
                </div>
                <div className="table-responsive">
                             <table className="table table-striped table-sm text-white">
                             <thead>
                                 <tr className="text-white" >
                                 <th>Ders Adı</th>
                                 <th>Ders Öğretmeni</th>
                                 <th>Kredi</th>
                                 <th>Teori Süresi</th>
                                 <th>Uygulama Süresi</th>
                                 </tr>
                             </thead>
                             <tbody>
                         {Object.values(this.state.lessons).map((lesson) =>
                                 <tr key={lesson.lessonCode} className="text-white" >
                                 <td>{lesson.lessonName}</td>
                                 <td>{lesson.teacherName}</td>
                                 <td>{lesson.akts}</td>
                                 <td>{lesson.theoryTime}</td>
                                 <td>{lesson.practiceTime}</td>
                                 <td><button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit" onClick={(e) => this.handlePDF(lesson.lessonCode)} >PDF Görüntüle</button></td>
                                 </tr>
                         )}
                 </tbody>
                 </table>
                 </div>
          </div>
        )
    }
}
