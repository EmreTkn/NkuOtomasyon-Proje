import React, { Component } from 'react'
import logo from "../../../images/logo.png"

export default class OzlukBilgileri extends Component {
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'student/get-personal-information',requestOptions);
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
                <h2>Özlük Bilgileri</h2>
                </div>
                <div className="d-flex align-items-center justift-content-center">
                <ul className="list-group mb-3">
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Adı Soyadı:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">TC No:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Doğum Yeri:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Doğum Tarihi:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Uyruk:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Askerlik Durumu:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Anne Adı:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Baba Adı:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Cinsiyet:</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 className="my-0">Medeni Hal:</h6>    
                            </div>   
                        </li>
                    </ul>   
                    <ul className="list-group mb-3">
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.firstName} {this.state.userData.lastName}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.tcNumber}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.birthCity}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.birthday}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.nationality}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.militaryStatus ? 'Yaptı' : 'Yapmadı'}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.motherName}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.fatherName}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.gender === "Male" ? 'Erkek' : 'Kadın'}</h6>    
                            </div>   
                        </li>
                        <li className="list-group-item d-flex justify-content-between lh-sm font-weight-bold">
                            <div>
                                <h6 className="my-0 text-secondary">{this.state.userData.maritalStatus}</h6>    
                            </div>   
                        </li>                       
                    </ul>
               
                </div>
            </div>
        )
    }
}
