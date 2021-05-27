import React, { Component } from 'react'
import logo from "../../../images/logo.png"

export default class OgrenimBilgileri extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            userData: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'student/get-information',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({userData: res});
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
     }
    render() {
        return (
            <div className="col-12 h-100 flex-column d-flex align-items-center justift-content-center bg-dark text-white">
            <div className="py-5 text-center">
            <img src={logo} style={{"width" : "100px"}} alt={"logo"}></img>
            <h2>Öğrenim Bilgileri</h2>
            </div>
            <div className="d-flex align-items-center justift-content-center">
            <ul className="list-group mb-3">
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Öğrenci No:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Danışmanı:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Okuduğu Fakülte:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Okuduğu Bölüm:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Sınıf:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Öğretim Türü:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Öğretim Düzeyi:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Eğitim Yılı/ Dönemi:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Genel Ortalama:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Yerleşme Tipi:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Kayıt Tarihi:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Geldiği Üniversite:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Fakülte/YO/MYO:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Bölüm:</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm">
                        <div>
                            <h6 className="my-0">Mezuniyet Yılı:</h6>    
                        </div>   
                    </li>
                </ul>   
                <ul className="list-group mb-3">
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.schoolNumber === null ? 'Boş' : this.state.userData.schoolNumber }</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.advisorTeacher  === null ? 'Boş' : this.state.userData.advisorTeacher }</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.faculty  === null ? 'Boş' : this.state.userData.faculty}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.studyProgram === null ? 'Boş' : this.state.userData.studyProgram}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.currentClass === null ? 'Boş' : this.state.userData.currentClass}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.studyTime === null ? 'Boş' : this.state.userData.studyTime}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.educationType === null ? 'Boş' : this.state.userData.educationType}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.semester === null ? 'Boş' : this.state.userData.semester}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.gradeAverage === null ? 'Boş' : this.state.userData.gradeAverage}</h6>    
                        </div>   
                    </li>    
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.recordType === null ? 'Boş' : this.state.userData.recordType}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.registerTime === null ? 'Boş' : this.state.userData.registerTime}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.comeFromUniversity === null ? 'Boş' : this.state.userData.comeFromUniversity}</h6>    
                        </div>   
                    </li>
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.comeFromFaculty === null ? 'Boş' : this.state.userData.comeFromFaculty}</h6>    
                        </div>   
                    </li>   
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.comeFromBranch === null ? 'Boş' : this.state.userData.comeFromBranch}</h6>    
                        </div>   
                    </li> 
                    <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                        <div>
                            <h6 className="my-0 text-secondary">{this.state.userData.graduationYear === null ? 'Boş' : this.state.userData.graduationYear}</h6>    
                        </div>   
                    </li>                   
                </ul>
           
            </div>
        </div>
        )
    }
}
