import React, { Component } from 'react'

export default class DonemDersKarnemElement extends Component {
    render() {
        return (
            <div>
                <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
                    {this.props.element[0].lessonYear} {this.props.element[0].semester % 2 === 1 ? '1. Dönem' : '2. Dönem'}
                </div>
                <div className="table-responsive">
                            <table className="table table-striped table-sm text-white">
                            <thead>
                                <tr className="text-white" >
                                <th>Ders Kodu</th>
                                <th>Ders Adı</th>
                                <th>Dersi Veren</th>
                                <th>AKTS</th>
                                <th>T</th>
                                <th>U</th>
                                <th>GN</th>
                                <th>HN</th>
                                <th>KS</th>
                                </tr>
                            </thead>
                            <tbody>
                        {Object.values(this.props.element).map((donem) =>
                                <tr className="text-white" >
                                <td>{donem.lessonCode}</td>
                                <td>{donem.lessonName}</td>
                                <td>{donem.teacherName}</td>
                                <td>{donem.akts}</td>
                                <td>{donem.theoryTime}</td>
                                <td>{donem.practiceTime}</td>
                                <td>{donem.gradesAverage}</td>
                                <td>{donem.letter}</td>
                                <td>{donem.letterGrade}</td>
                                </tr>
                        )}
                </tbody>
                <tfoot>
                <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>Puan: {this.props.element[0].semesterGrade === null ? '0,00' : this.props.element[0].semesterGrade }</td>                   
                 </tr>
                </tfoot>
                </table>
                </div>
            </div>
        )
    }
}
