import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class DonemDersNotlari extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            gradeCards: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'grade/get-grades',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({gradeCards: res});
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
                   Dönem Ders Notları
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Ders Kodu</th>
                                <th>Ders Adı</th>
                                <th>Dersi Veren</th>
                                <th>AKTS</th>
                                <th>Devamsızlık Durumu</th>
                                <th>GN</th>
                                <th>HN</th>
                                <th>Başarı Durumu</th>
                                <th>Ara Sınav</th>
                                <th>Final Sınavı</th>
                                <th>Bütünleme Sınavı</th>
                                <th>Not Ortalaması</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.state.gradeCards).map((grade) =>
                                <tr className="text-white" >
                                <td>{grade.lessonCode}</td>
                                <td>{grade.lessonName}</td>
                                <td>{grade.teacherName}</td>
                                <td>{grade.akts}</td>
                                <td>{grade.statusAbsenteeism == true ? 'Kaldı' : 'Geçti'}</td>
                                <td>{grade.letter}</td>
                                <td>{grade.letterGrade}</td>
                                <td>
                                <If condition={grade.successStatus == 0}>
                                    <Then>
                                        Geçti
                                    </Then>
                                    <ElseIf condition={grade.successStatus == 1}>
                                        Alıyor
                                    </ElseIf>
                                    <ElseIf condition={grade.successStatus == 2}>
                                        Kaldı
                                    </ElseIf>
                                    <ElseIf condition={grade.successStatus == 3}>
                                        Almadı
                                </ElseIf>
                                </If>
                                </td>
                                <td>{grade.midExam}</td>
                                <td>{grade.finalExam}</td>
                                <td>{grade.lastExam}</td>
                                <td>{grade.gradeAverage}</td>
                                </tr>
                        )}
                </tbody>
                </table>
                </div>
          </div>
        )
    }
}
