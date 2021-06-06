import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class OgrenimBilgileri extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            selectedLessons: {},
            takeLessons: {},
        }
    }
    async componentDidMount() {
       this.getLessons();
     }
     async getLessons(){
        const requestOptions = {
            method: 'GET',
            headers: {
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': `application/json`,
            }
        };
        const responseSelectedLessons = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-selected-lesson',requestOptions);
        if(responseSelectedLessons.ok){
            const res = await responseSelectedLessons.json();
            this.setState({selectedLessons: res});
        }
        else{
            const res = await responseSelectedLessons.json();
            alert(res.message)
        }

        const responseTakeLessons = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-semester-lesson',requestOptions);
        if(responseTakeLessons.ok){
            const res = await responseTakeLessons.json();
            this.setState({takeLessons: res});
        }
        else{
            const res = await responseTakeLessons.json();
            alert(res.message)
        }
     }

     async handleDeleteSelected(lessonCode){
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': `application/json`,
            }
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/delete?lessonCode='+lessonCode, requestOptions);
        if(response.ok){
            this.getLessons();
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }

    async handleTakeLesson(lessonCode){
        const requestOptions = {
            method: 'POST',
            headers: { 
                'Authorization': `Bearer `+this.state.token,
                'Content-Type': `application/json`,
            }
        };
        
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/add?lessonCode='+lessonCode, requestOptions);
        if(response.ok){
            this.getLessons();
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
    }
    render() {
        return (
            <div className="h-100 bg-dark text-white d-flex">
                <div className="col-6">
                    <div className="py-5 text-center">
                        <h2>Seçilmiş Dersler</h2>
                    </div>
                    <div className="d-flex align-items-center justify-content-center">
                        <ul className="list-group mb-3">
                            {Object.values(this.state.selectedLessons).map((selected) =>
                                <li className="list-group-item d-flex justify-content-between lh-sm">
                                <div>
                                    <h6 className="my-0">Ders Adı: {selected.lessonName}</h6> 
                                    <h6 className="my-0">Ders Kodu: {selected.lessonCode}</h6>   
                                    <h6 className="my-0">Dersi Veren: {selected.teacherName}</h6>  
                                </div>
                                <If condition={selected.repetition == false}>
                                <Then>
                                <div>
                                    <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit" onClick={(e) => this.handleDeleteSelected(selected.lessonCode)} >Sil</button>
                                </div>
                                </Then>
                                </If>   
                                </li>
                            )}
                        </ul>   
                    </div>
                </div>
                <div className="col-6">
                    <div className="py-5 text-center">
                        <h2>Alınabilecek Dersler</h2>
                    </div>
                    <div className="d-flex align-items-center justify-content-center">
                        <ul className="list-group mb-3">
                            {Object.values(this.state.takeLessons).map((take) =>
                                    <li className="list-group-item d-flex justify-content-between lh-sm">
                                    <div>
                                        <h6 className="my-0">Ders Adı: {take.lessonName}</h6> 
                                        <h6 className="my-0">Ders Kodu: {take.lessonCode}</h6>   
                                        <h6 className="my-0">Dersi Veren: {take.teacherName}</h6>  
                                    </div>
                                    <If condition={take.repetition == false}>
                                    <Then>
                                    <div>
                                        <button className="btn btn-lg btn-secondary fw-bold border-white bg-white" type="submit" onClick={(e) => this.handleTakeLesson(take.lessonCode)} >Ekle</button>
                                    </div>
                                    </Then>
                                    </If>   
                                    </li>
                                )}
                            </ul>   
                    </div>
                </div>
          </div>
        )
    }
}
