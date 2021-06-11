import React, { Component } from 'react'
import logo from "../../../images/logo.png"
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";


export default class Teachers extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            teachers: {},
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'studentaffairs/get-teachers',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({teachers: res});
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
                   Öğrenciler
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Öğretmen Id</th>
                                <th>Öğretmen Adı - Soyadı</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.state.teachers).map((teacher) =>
                                <tr key={teacher.id} className="text-white" >
                                <td>{teacher.id}</td>
                                <td>{teacher.firstName} {teacher.lastName}</td>
                                 </tr>
                        )}
                </tbody>
                </table>
                </div>
            </div>
        )
    }
}
