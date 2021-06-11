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
            graduationYear : '',
            marialStatus: '',
            gender :'',fatherName:'',motherName:'',militaryStatus:'',nationality:'',birthCity:'',birthday:'',address:'',tcNumber:'',lastName:'',firstName:''
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

        const response2 = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-education-information?studentNumber='+this.state.studentNumber,requestOptions);
        if(response2.ok){
            const res = await response2.json();
            this.setState({educationType: res.educationType});
            this.setState({studyTimeId: res.studyTime});
            this.setState({advisorTeacherId: res.advisorTeacher});
            this.setState({gradeAverage: res.gradeAverage});
            this.setState({facultyId: res.faculty});
            this.setState({studyProgramId: res.studyProgram});
            this.setState({recordType: res.recordType});
            this.setState({comeFromUniversity: res.comeFromUniversity});
            this.setState({comeFromFaculty: res.comeFromFaculty});
            this.setState({comeFromBranch: res.comeFromBranch});
            this.setState({graduationYear: res.graduationYear});
            this.setState({semesterId: res.semester});
        }
        else{
            const res = await response2.json();
            alert(res.message)
        }

        const response3 = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-personal-information?studentNumber='+this.state.studentNumber,requestOptions);
        if(response3.ok){
            const res3 = await response3.json();
            this.setState({firstName: res3.firstName});
            this.setState({lastName: res3.lastName});
            this.setState({tcNumber: res3.tcNumber});
            this.setState({address: res3.address});
            this.setState({birthday: res3.birthday});
            this.setState({birthCity: res3.birthCity});
            this.setState({nationality: res3.nationality});
            this.setState({militaryStatus: res3.militaryStatus});
            this.setState({motherName: res3.motherName});
            this.setState({fatherName: res3.fatherName});
            this.setState({gender: res3.gender});
            this.setState({marialStatus: res3.marialStatus});
        }
        else{
            const res3 = await response3.json();
            alert(res3.message)
        }
     }

     async handleUpdate(){
         const {formstudentNumber,educationType,studyTimeId,advisorTeacherId,gradeAverage,facultyId,studyProgramId,semesterId,recordType,comeFromUniversity,comeFromFaculty,comeFromBranch,graduationYear} = this.state;
         const requestOptions = {
             method: 'POST',
             headers: { 
                 'Authorization': `Bearer `+this.state.token,
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


    async handleUpdatePersonel(){
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ 
                studentNumber  : this.state.studentNumber,
                firstName : this.state.firstName,
                lastName : this.state.lastName,
                tcNumber  : this.state.tcNumber,
                address  : this.state.address,
                birthday  : this.state.birthday,
                birthCity  : this.state.birthCity,
                nationality  : this.state.nationality,
                militaryStatus  : this.state.militaryStatus,
                motherName  : this.state.motherName,
                fatherName  : this.state.fatherName,
                gender   : this.state.gender,
                marialStatus   : this.state.marialStatus, 
            })
        };
   
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/update-personal-information', requestOptions);
        
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

        var formdata = new FormData();    
        formdata.append("fileToCome", photoUrl);

      const requestOptions = {
          method: 'POST',
          headers: { 
              'Authorization': `Bearer `+this.state.token,
          },
          body: formdata
      };
   
      const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/upload-photo?studentNumber='+this.state.studentNumber, requestOptions);

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
                   {this.state.studentNumber} Numaralı Öğrenci İçin Öğretim Bilgiler Güncelle 
                </div>
                 <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <form enctype="multipart/form-data">
                            <div className="form-group">
                                <label htmlFor="updatePhoto">Profil Fotoğrafı Değiştirme</label>
                                <input type="file" className="form-control-file" id="updatePhoto"  onChange={(e) => this.updatePhoto(e.target.files[0])}></input>
                            </div>
                        </form>
                         <div className="form-group">
                            <label htmlFor="formstudentNumber">Lütfen Öğrenci No Giriniz</label>
                            <input type="text" className="form-control" id="formstudentNumber" value={this.state.studentNumber}  onChange={(e) => this.setState({formstudentNumber :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="egitimtipi">Lütfen Semester Seçiniz</label>
                            <select  className="form-control" id="egitimtipi"   onChange={(e) => this.setState({semesterId:parseInt(e.target.value)})}>
                            <option>{this.state.semesterId}</option>
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
                         <div className="form-group">
                            <label htmlFor="egitimtipi">Lütfen Eğitim Tipi Seçiniz</label>
                            <select  className="form-control" id="egitimtipi"  onChange={(e) => this.setState({educationType:parseInt(e.target.value)})}>
                            <option>{this.state.educationType}</option>
                            <option value={0}>AssociateDegree</option>
                            <option value={1}>Degree</option>
                            <option value={2}>Master</option>
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="studyTimeId">Lütfen Eğitim Zamanını Seçiniz</label>
                            <select  className="form-control" id="studyTimeId"  onChange={(e) => this.setState({studyTimeId:parseInt(e.target.value)})}>
                                <option>{this.state.studyTimeId}</option>
                                <option value={1}>Birinci Öğretim</option>
                                <option value={2}>İkinci Öğretim</option>
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="ogretmen">Lütfen Öğretmen Seçiniz</label>
                            <select  className="form-control" id="ogretmen"  onChange={(e) => this.setState({advisorTeacherId:e.target.value})}>
                            <option>{this.state.advisorTeacherId}</option>
                            {Object.values(this.state.teachers).map((teacher) =>
                                <option value={teacher.id}>{teacher.firstName} {teacher.lastName}</option>
                            )}
                            </select>
                         </div>
                        <div className="form-group">
                            <label htmlFor="fakulte">Lütfen Fakülte Seçiniz</label>
                            <select  className="form-control" id="fakulte"  onChange={(e) => this.setState({facultyId:parseInt(e.target.value)})}>
                            <option>{this.state.facultyId}</option>
                            {Object.values(this.state.faculties).map((faculty) =>
                                <option value={faculty.id}>{faculty.facultyName}</option>
                            )}
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="program">Lütfen Öğrenim Programı Seçiniz</label>
                            <select  className="form-control" id="program"  onChange={(e) => this.setState({studyProgramId:parseInt(e.target.value)})}>
                                <option>{this.state.studyProgramId}</option>
                            {Object.values(this.state.studyPrograms).map((study) =>
                                <option value={study.id}>{study.programName}</option>
                            )}
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="recordType">Lütfen Kayıt Tipini Seçiniz</label>
                            <select  className="form-control" id="recordType"  onChange={(e) => this.setState({recordType:parseInt(e.target.value)})}>
                                <option>{this.state.recordType}</option>
                                <option value={0}>DGS</option>
                                <option value={1}>LYS</option>
                                <option value={2}>Yatay Geçiş</option>
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="gradeAverage">Lütfen Genel Ortalama Giriniz</label>
                            <input type="number" className="form-control" id="gradeAverage"  value={this.state.gradeAverage} placeholder="Genel Ortalama"  onChange={(e) => this.setState({gradeAverage :parseFloat(e.target.value)})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="comeFromUniversity">Lütfen Geldiği Üniversiteyi Giriniz</label>
                            <input type="text" className="form-control" id="comeFromUniversity"  value={this.state.comeFromUniversity} placeholder="Geldiği Universite"  onChange={(e) => this.setState({comeFromUniversity :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="comeFromFaculty">Lütfen Geldiği Fakülteyi Giriniz</label>
                            <input type="text" className="form-control" id="comeFromFaculty"  value={this.state.comeFromFaculty} placeholder="Geldiği Fakülte"  onChange={(e) => this.setState({comeFromFaculty :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="comeFromBranch">Lütfen Geldiği Bölümü Giriniz</label>
                            <input type="text" className="form-control" id="comeFromBranch"  value={this.state.comeFromBranch} placeholder="Geldiği Bölüm"  onChange={(e) => this.setState({comeFromBranch :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="graduationYear">Lütfen Mezun Olma Tarihi Giriniz</label>
                            <input type="date" className="form-control" id="graduationYear"  value={this.state.graduationYear} placeholder="Mezun Olma Tarihi"  onChange={(e) => this.setState({graduationYear :e.target.value})}></input>
                         </div>
                        <br/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleUpdate()} >Güncelle</button>
                </main>

                <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                   {this.state.studentNumber} Numaralı Öğrenci İçin Personel Bilgileri Güncelle 
                </div>
                 <main className="form-signin">
                         <div className="w-100 d-flex justify-content-center align-items-center">
                             <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
                         </div>
                         <div className="form-group">
                            <label htmlFor="Adı">Adı</label>
                            <input type="text" className="form-control" id="Adı" value={this.state.firstName}  onChange={(e) => this.setState({firstName :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="Soyadı">Soyadı</label>
                            <input type="text" className="form-control" id="Soyadı" value={this.state.lastName}  onChange={(e) => this.setState({formstudentNumber :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="tc">TC Kimlik No</label>
                            <input type="number" className="form-control" id="tc" value={this.state.tcNumber}  onChange={(e) => this.setState({tcNumber :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="address">Adres</label>
                            <input type="text" className="form-control" id="address" value={this.state.address}  onChange={(e) => this.setState({address :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="birthday">Doğum Tarihi</label>
                            <input type="date" className="form-control" id="birthday"  value={this.state.birthday} placeholder="Mezun Olma Tarihi"  onChange={(e) => this.setState({birthday :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="birthCity">Doğum Yeri</label>
                            <input type="text" className="form-control" id="birthCity" value={this.state.birthCity}  onChange={(e) => this.setState({birthCity :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="nationality">Uyruk</label>
                            <input type="text" className="form-control" id="nationality" value={this.state.nationality}  onChange={(e) => this.setState({nationality :e.target.value})}></input>
                         </div>      
                         <div className="form-group">
                            <label htmlFor="militaryStatus">Askerlik Durumu</label>
                            <select  className="form-control" id="militaryStatus"   onChange={(e) => this.setState({militaryStatus:Boolean(e.target.value)})}>
                            <option>{this.state.militaryStatus}</option>
                            <option value={true}>Yaptı</option>
                            <option value={false}>Yapmadı</option>
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="motherName">Anne Adı</label>
                            <input type="text" className="form-control" id="motherName" value={this.state.motherName}  onChange={(e) => this.setState({motherName :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="fatherName">Baba Adı</label>
                            <input type="text" className="form-control" id="fatherName" value={this.state.fatherName}  onChange={(e) => this.setState({fatherName :e.target.value})}></input>
                         </div>
                         <div className="form-group">
                            <label htmlFor="gender">Cinsiyet</label>
                            <select  className="form-control" id="gender"   onChange={(e) => this.setState({gender:e.target.value})}>
                            <option>{this.state.gender}</option>
                            <option value="Male">Erkek</option>
                            <option value="Female">Bayan</option>
                            </select>
                         </div>
                         <div className="form-group">
                            <label htmlFor="marialStatus">Medeni Durum</label>
                            <select  className="form-control" id="marialStatus"   onChange={(e) => this.setState({marialStatus:e.target.value})}>
                            <option>{this.state.marialStatus}</option>
                            <option value="Married">Evli</option>
                            <option value="Single">Bekar</option>
                            </select>
                         </div>
                        <br/>
                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit"  onClick={(e) => this.handleUpdatePersonel()} >Güncelle</button>
                </main>
            </div>
        )
    }
}
