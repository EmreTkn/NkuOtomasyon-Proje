using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace API.Helpers
{
    public class UpdateValueResolver :  IValueResolver<UpdateStudentDto, StudentInformation, object>
    {
        private readonly IStudentService _service;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateValueResolver(IStudentService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public object Resolve(UpdateStudentDto source, StudentInformation destination, object destMember, ResolutionContext context)
        {
            var student = _service.GetStudentByNumber(source.StudentNumber).Result;

            return new StudentInformation()
            {
                Student = student,
                StudentId = student.Id,
                Semester = _unitOfWork.Repository<Semester>().GetByIntIdAsync(source.SemesterId).Result,
                AdvisorTeacher = _unitOfWork.Repository<Teacher>().GetByIdAsync(source.AdvisorTeacherId).Result,
                RecordType = destination.RecordType,
                EducationType = destination.EducationType,
                ComeFromBranch = destination.ComeFromBranch,
                ComeFromFaculty = destination.ComeFromFaculty,
                ComeFromUniversity = destination.ComeFromUniversity,
                Faculty = _unitOfWork.Repository<Faculty>().GetByIntIdAsync(source.FacultyId).Result,
                GradeAverage = destination.GradeAverage,
                GraduationYear = destination.GraduationYear,
                StudyProgram = _unitOfWork.Repository<StudyProgram>().GetByIntIdAsync(source.StudyProgramId).Result,
                StudyTime = _unitOfWork.Repository<StudyTime>().GetByIntIdAsync(source.StudyTimeId).Result
            };
        }
    }
}
