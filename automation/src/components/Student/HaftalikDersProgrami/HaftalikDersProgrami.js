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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-lessons-dates',requestOptions);
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
            <div className="h-100 bg-dark text-white">
            <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
              Haftalık Ders Programı
            </div>
            <div className="table-responsive">
              <table className="table table-striped table-sm text-white">
                <tr>
                    <th></th>
                    <th>1.Ders</th>
                    <th>2.Ders</th>
                    <th>3.Ders</th>
                    <th>4.Ders</th>
                    <th>5.Ders</th>
                    <th>6.Ders</th>
                    <th>7.Ders</th>
                    <th>8.Ders</th>
                </tr>
                <tr>
                    <th>Pazartesi</th>
                    <td>DİL ANLATIM</td>
                    <td>DİL ANLATIM</td>
                    <td>FELSEFE</td>
                    <td>FELSEFE</td>
                    <td>TÜRK EDEBİYATI</td>
                    <td>TÜRK EDEBİYATI</td>
                    <td>BEDEN</td>
                    <td>COĞRAFYA</td>
                </tr>
                <tr>
                    <th>Salı</th> 
                    <td>BİLGİSAYAR</td>
                    <td>BİLGİSAYAR</td>
                    <td>BİLGİSAYAR</td>
                    <td>BİLGİSAYAR</td>
                    <td>YABANCI DİL</td>
                    <td>YABANCI DİL</td>
                    <td>MATEMATİK</td>
                    <td>DİN KÜLTÜRÜ</td>
                </tr>
                <tr>
                    <th>Çarşamba</th>
                    <td>TÜRK EDEBİYATI</td>
                    <td>TÜRK EDEBİYATI</td>
                    <td>VERİ TABANI</td>
                    <td>VERİ TABANI</td>
                    <td>TARİH</td>
                    <td>AĞ TEMELLERİ</td>
                    <td>AĞ TEMELLERİ</td>
                    <td>AĞ TEMELLERİ</td>
                </tr>
                <tr>
                    <th>Perşembe</th>
                    <td>COĞRAFYA</td>
                    <td>COĞRAFYA</td>
                    <td>DİN KÜLTÜRÜ</td>            			
                    <td>GRAFİK TASARIM</td>
                    <td>GRAFİK TASARIM</td>
                    <td>GRAFİK TASARIM</td>
                    <td>GRAFİK TASARIM</td>
                    <td>GRAFİK TASARIM</td>
                </tr>
                <tr>
                    <th>Cuma</th>
                    <td>WEB TASARIMI</td>
                    <td>WEB TASARIMI</td>
                    <td>WEB TASARIMI</td>
                    <td>WEB TASARIMI</td>
                    <td>WEB TASARIMI</td>
                    <td>WEB TASARIMI</td>
                    <td>VERİ TABANI</td>
                    <td>VERİ TABANI</td>
                </tr>   
              </table>
            </div>
          </div>
        )
    }
}
