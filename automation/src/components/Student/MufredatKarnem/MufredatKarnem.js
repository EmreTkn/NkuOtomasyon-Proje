import React, { Component } from 'react'
import _ from "lodash";
import MufredatKarnemElement from '../MufredatKarnem/MufredatKarnemElement'

function groupArrayOfObjects(list, key) {
    return list.reduce(function(rv, x) {
      (rv[x[key]] = rv[x[key]] || []).push(x);
      return rv;
    }, {});
  };
export default class MufredatKarnem extends Component {
    constructor(props){
        super(props);
        this.state = {
            token : this.props.user,
            userLessonData:[]
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-curriculum-card',requestOptions);
        if(response.ok){
            const res = await response.json();
            this.setState({
                userLessonData: groupArrayOfObjects(res,"semester")
            },()=>{}
           );
        }
        else{
            const res = await response.json();
            alert(res.message)
        }
      }   
    render() {  
        // const count = Object.keys(groupLesson).length;
        console.log(this.state.userLessonData)
        return (
            <div className="h-100 bg-dark text-white">
                {Object.values(this.state.userLessonData).map((semester) =>
                <MufredatKarnemElement key={semester[0].semester+semester[0].lessonCode} element={semester}></MufredatKarnemElement>
                )}
            </div>     
        )
    }
}
