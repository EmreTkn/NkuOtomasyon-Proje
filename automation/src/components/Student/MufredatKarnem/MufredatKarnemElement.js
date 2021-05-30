import React, { Component } from "react";
import { If, Then, ElseIf, Else } from "react-if-elseif-else-render";

export default class MufredatKarnemElement extends Component {
  render() {
    return (
      <div>
        <div className="navbar navbar-dark bg-dark shadow-sm w-100 text-white pt-8 align-items-center d-flex justify-content-center border-bottom  border-white">
          {this.props.element[0].semester}. Dönem
        </div>
        <div className="table-responsive">
          <table className="table table-striped table-sm text-white">
            <thead>
              <tr className="text-white">
                <th>Ders Kodu</th>
                <th>Ders Adı</th>
                <th>Ders Tipi</th>
                <th>Ders Alma Durumu</th>
                <th>DAS</th>
                <th>GN</th>
                <th>AKTS</th>
                <th>HN</th>
                <th>KS</th>
                <th>Devam Durumu</th>
                <th>Başarı Durumu</th>
              </tr>
            </thead>
            <tbody>
              {Object.values(this.props.element).map((donem) => (
                <tr
                  key={donem.semester + donem.lessonCode}
                  className="text-white"
                >
                  <td>{donem.lessonCode}</td>
                  <td>{donem.lessonName}</td>
                  <td>{donem.lessonType === false ? "Zorunlu" : "Seçmeli"}</td>
                  <td>
                    <If condition={donem.lessonStatus == 0}>
                      <Then>
                        Geçti
                      </Then>
                      <ElseIf condition={donem.lessonStatus == 1}>
                        Alıyor
                      </ElseIf>
                      <ElseIf condition={donem.lessonStatus == 2}>
                        Kaldı
                      </ElseIf>
                      <ElseIf condition={donem.lessonStatus == 3}>
                        Almadı
                      </ElseIf>
                    </If>
                  </td>
                  <td>{donem.numberOfLessonTaken}</td>
                  <td>{donem.gradesAverage}</td>
                  <td>{donem.akts}</td>
                  <td>{donem.letter}</td>
                  <td>{donem.letterGrade}</td>
                  <td>
                    {donem.statusAbsenteeism === false ? "Devamlı" : "Kaldı"}
                  </td>
                  <td>
                  <If condition={donem.successStatus == 0}>
                      <Then>
                        Geçti
                      </Then>
                      <ElseIf condition={donem.successStatus == 1}>
                        Alıyor
                      </ElseIf>
                      <ElseIf condition={donem.successStatus == 2}>
                        Kaldı
                      </ElseIf>
                      <ElseIf condition={donem.successStatus == 3}>
                        Almadı
                      </ElseIf>
                    </If>
                </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}
