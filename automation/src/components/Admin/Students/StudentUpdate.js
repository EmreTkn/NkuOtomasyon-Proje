import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";

export default class StudentUpdate extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            faculties: {},
            studyPrograms: {},
            teachers: {},
            formstudentNumber:'',
            studentNumber : this.props.pushStudentNumber,
            educationType : '',
            studyTimeId : '',
            advisorTeacherId : '',
            gradeAverage : '',
            facultyId : '',
            studyProgramId : '',
            semesterId : '',
            recordType : '',
            comeFromUniversity : '',
            comeFromFaculty : '',
            comeFromBranch : '',
            graduationYear : ''
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
         const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-update-params',requestOptions);
         if(response.ok){
             const res = await response.json();
             this.setState({faculties: res.faculties});
             this.setState({studyPrograms: res.studyPrograms});
             this.setState({teachers: res.teachers});
         }
         else{
             const res = await response.json();
             alert(res.message)
         }
     }

     async handleUpdate(){
         const {formstudentNumber,educationType,studyTimeId,advisorTeacherId,gradeAverage,facultyId,studyProgramId,semesterId,recordType,comeFromUniversity,comeFromFaculty,comeFromBranch,graduationYear} = this.state;
         const requestOptions = {
             method: 'POST',
             headers: { 
                  // 'Authorization': `Bearer `+this.state.token,
                 'Content-Type': 'application/json',
             },
             body: JSON.stringify({ 
                 studentNumber  : formstudentNumber,
                 educationType : educationType,
                 studyTimeId : studyTimeId,
                 advisorTeacherId  : advisorTeacherId,
                 gradeAverage  : gradeAverage,
                 facultyId  : facultyId,
                 studyProgramId  : studyProgramId,
                 semesterId  : semesterId,
                 recordType  : recordType,
                 comeFromUniversity  : comeFromUniversity,
                 comeFromFaculty  : comeFromFaculty,
                 comeFromBranch   : comeFromBranch,
                 graduationYear   : graduationYear, 
             })
         };
    
         const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/update-education?studentNumber='+this.state.studentNumber, requestOptions);
         
         if(response.ok){
             const res = await response.json();
             alert(res.message)
         }
         else{
             const res = await response.json();
             alert(res.message)
         }
    }

    async updatePhoto(photoUrl){
         const requestOptions = {
             method: 'POST',
             headers: { 
                  // 'Authorization': `Bearer `+this.state.token,
                 'Content-Type': 'application/json',
             },
             body: JSON.stringify({ 
                fileToCome  : photoUrl,
                studentNumber: this.state.studentNumber
             })
         };
   
         const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/upload-photo', requestOptions);

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
                   {this.state.studentNumber} Numaralı Öğrenci Update Sayfası
                </div>
                 <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <div class="form-group">
                            <label for="updatePhoto">Profil Fotoğrafı Değiştirme</label>
                            <input type="file" class="form-control-file" id="updatePhoto"  onChange={(e) => this.updatePhoto(e.target.value)}></input>
                        </div>
                         <div class="form-group">
                            <label for="formstudentNumber">Lütfen Öğrenci No Giriniz</label>
                            <input type="text" className="form-control" id="formstudentNumber"  onChange={(e) => this.setState({formstudentNumber :e.target.value})}></input>
                         </div>
                         <div class="form-group">
                            <label for="egitimtipi">Lütfen Semester Seçiniz</label>
                            <select  className="form-control" id="egitimtipi"  onChange={(e) => this.setState({semesterId:parseInt(e.target.value)})}>
                            <option>-</option>
                            <option value={1}>1. Semester</option>
                            <option value={2}>2. Semester</option>
                            <option value={3}>3. Semester</option>
                            <option value={4}>4. Semester</option>
                            <option value={5}>5. Semester</option>
                            <option value={6}>6. Semester</option>
                            <option value={7}>7. Semester</option>
                            <option value={8}>8. Semester</option>
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="egitimtipi">Lütfen Eğitim Tipi Seçiniz</label>
                            <select  className="form-control" id="egitimtipi"  onChange={(e) => this.setState({educationType:parseInt(e.target.value)})}>
                            <option>-</option>
                            <option value={0}>AssociateDegree</option>
                            <option value={1}>Degree</option>
                            <option value={2}>Master</option>
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="studyTimeId">Lütfen Eğitim Zamanını Seçiniz</label>
                            <select  className="form-control" id="studyTimeId"  onChange={(e) => this.setState({studyTimeId:parseInt(e.target.value)})}>
                                <option>-</option>
                                <option value={1}>Birinci Öğretim</option>
                                <option value={2}>İkinci Öğretim</option>
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="ogretmen">Lütfen Öğretmen Seçiniz</label>
                            <select  className="form-control" id="ogretmen"  onChange={(e) => this.setState({advisorTeacherId:e.target.value})}>
                            <option>-</option>
                            {Object.values(this.state.teachers).map((teacher) =>
                                <option value={teacher.id}>{teacher.firstName} {teacher.lastName}</option>
                            )}
                            </select>
                         </div>
                        <div class="form-group">
                            <label for="fakulte">Lütfen Fakülte Seçiniz</label>
                            <select  className="form-control" id="fakulte"  onChange={(e) => this.setState({facultyId:parseInt(e.target.value)})}>
                            <option>-</option>
                            {Object.values(this.state.faculties).map((faculty) =>
                                <option value={faculty.id}>{faculty.facultyName}</option>
                            )}
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="program">Lütfen Öğrenim Programı Seçiniz</label>
                            <select  className="form-control" id="program"  onChange={(e) => this.setState({studyProgramId:parseInt(e.target.value)})}>
                                <option>-</option>
                            {Object.values(this.state.studyPrograms).map((study) =>
                                <option value={study.id}>{study.programName}</option>
                            )}
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="recordType">Lütfen Kayıt Tipini Seçiniz</label>
                            <select  className="form-control" id="recordType"  onChange={(e) => this.setState({recordType:parseInt(e.target.value)})}>
                                <option>-</option>
                                <option value={0}>DGS</option>
                                <option value={1}>LYS</option>
                                <option value={2}>Yatay Geçiş</option>
                            </select>
                         </div>
                         <div class="form-group">
                            <label for="gradeAverage">Lütfen Genel Ortalama Giriniz</label>
                            <input type="number" className="form-control" id="gradeAverage" placeholder="Genel Ortalama"  onChange={(e) => this.setState({gradeAverage :parseFloat(e.target.value)})}></input>
                         </div>
                         <div class="form-group">
                            <label for="comeFromUniversity">Lütfen Geldiği Üniversiteyi Giriniz</label>
                            <input type="text" className="form-control" id="comeFromUniversity" placeholder="Geldiği Universite"  onChange={(e) => this.setState({comeFromUniversity :e.target.value})}></input>
                         </div>
                         <div class="form-group">
                            <label for="comeFromFaculty">Lütfen Geldiği Fakülteyi Giriniz</label>
                            <input type="text" className="form-control" id="comeFromFaculty" placeholder="Geldiği Fakülte"  onChange={(e) => this.setState({comeFromFaculty :e.target.value})}></input>
                         </div>
                         <div class="form-group">
                            <label for="comeFromBranch">Lütfen Geldiği Bölümü Giriniz</label>
                            <input type="text" className="form-control" id="comeFromBranch" placeholder="Geldiği Bölüm"  onChange={(e) => this.setState({comeFromBranch :e.target.value})}></input>
                         </div>
                         <div class="form-group">
                            <label for="graduationYear">Lütfen Mezun Olma Tarihi Giriniz</label>
                            <input type="date" className="form-control" id="graduationYear" placeholder="Mezun Olma Tarihi"  onChange={(e) => this.setState({graduationYear :e.target.value})}></input>
                         </div>
                        <br/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleUpdate()} >Güncelle</button>
                </main>
            </div>
        )
    }
}
