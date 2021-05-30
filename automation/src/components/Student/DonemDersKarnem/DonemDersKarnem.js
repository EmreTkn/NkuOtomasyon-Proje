import React, { Component } from 'react'
import _ from "lodash";
import DonemDersKarnemElement from '../DonemDersKarnem/DonemDersKarnemElement'

function groupArrayOfObjects(list, key) {
    return list.reduce(function(rv, x) {
      (rv[x[key]] = rv[x[key]] || []).push(x);
      return rv;
    }, {});
  };
export default class DonemDersKarnem extends Component {
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
        const response = await fetch(process.env.REACT_APP_BASE_URL+'lesson/get-grade-cards',requestOptions);
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
                <DonemDersKarnemElement element={semester}></DonemDersKarnemElement>
                )}
            </div>     
        )
    }
}
