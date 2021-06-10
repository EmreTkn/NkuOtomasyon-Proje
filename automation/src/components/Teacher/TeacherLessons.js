import React, { Component } from 'react'
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";

 export default class TeacherLessons extends Component {
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
         const response = await fetch(process.env.REACT_APP_BASE_URL+'teacher/get-lessons',requestOptions);
         if(response.ok){
             const res = await response.json();
             this.setState({lessons: res});
         }
         else{
             const res = await response.json();
             alert(res.message)
         }
      }
      
      handleGoUpdateLesson(lessonNumber){
          this.props.takeLessonNumber(lessonNumber);
     }

     async updatePDF(url,lessonCode){

        var formdata = new FormData();    
        formdata.append("fileToCome", url);

      const requestOptions = {
          method: 'POST',
          headers: { 
              'Authorization': `Bearer `+this.state.token,
          },
          body: formdata
      };
   
      const response = await fetch(process.env.REACT_APP_BASE_URL+'teacher/upload-pdf?lessonCode='+lessonCode+'&name=PDF', requestOptions);

      if(response.ok){
          const res = await response.json();
          alert(res.message + "dosyası" + lessonCode + "kodlu dersin içeriğine eklendi.")
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
                    Dersler
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
                                 <td><button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit" onClick={(e) => this.handleGoUpdateLesson(lesson.lessonCode)} >Öğrenci Listesi</button></td>
                                 <td>
                                    <form enctype="multipart/form-data">
                                        <div className="form-group">
                                            <label htmlFor="updatePhoto">PDF Yükle</label>
                                            <input type="file" className="form-control-file" id="updatePhoto"  onChange={(e) => this.updatePDF(e.target.files[0],lesson.lessonCode)}></input>
                                        </div>
                                    </form>
                                 </td>
                                 </tr>
                         )}
                 </tbody>
                 </table>
                 </div>
             </div>
         )
     }
 }

