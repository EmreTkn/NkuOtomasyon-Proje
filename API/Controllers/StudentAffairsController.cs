using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.RequestDto;
using API.Dtos.ResponseDto;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.LessonSpecs;
using Core.Specification.StudentSpecs;
using Core.Specification.UpdateSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LessonDto = API.Dtos.LessonDto;
using UpdateStudentDto = API.Dtos.UpdateStudentDto;

namespace API.Controllers
{

    public class StudentAffairsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinary;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
       

        public StudentAffairsController(IUnitOfWork unitOfWork,ICloudinaryService cloudinary, IStudentService studentService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cloudinary = cloudinary;
            _studentService = studentService;
            _mapper = mapper;
        }



        [HttpPost("upload-photo")]
        public async Task<ActionResult> UploadPhotoForStudentAsync(string studentNumber,[FromForm]IFormFile fileToCome)
        {
            var student = await _studentService.GetStudentInformationByStudentNumber(studentNumber);

            var photoSpec = new StudentPhotoSpecification(student.StudentId);
            var photo = await _unitOfWork.Repository<Photo>().GetWithSpec(photoSpec);

            if (photo == null)
            {
                return await PhotoRepository(fileToCome, student.Student);
            }
            else
            {
                _unitOfWork.Repository<Photo>().Delete(photo);
                await _unitOfWork.Complete();
                return await PhotoRepository(fileToCome, student.Student);
            }
        }

        [HttpGet("get-update-params")]
        public async Task<Dtos.ResponseDto.UpdateStudentDto> GetUpdateParamsAsync()
        {
            return new Dtos.ResponseDto.UpdateStudentDto
            {
                Faculties = (await _unitOfWork.Repository<Faculty>().ListAllAsync()).Select(_mapper.Map<FacultiesDto>).ToList(),
                StudyPrograms = (await _unitOfWork.Repository<StudyProgram>().ListAllAsync()).Select(_mapper.Map<StudyProgramDto>).ToList(),
                Teachers = (await _unitOfWork.Repository<Teacher>().ListAllAsync()).Select(_mapper.Map<TeacherBasicDto>).ToList()
            };
        }

        [HttpPost("update-education")]
        public async Task<ActionResult> UpdateStudentEducationInformationAsync(UpdateStudentDto information)
        {
            var studentInformation = await _studentService.GetStudentInformationByStudentNumber(information.StudentNumber);
            if (studentInformation == null)
            {
                var student = await _studentService.GetStudentByNumber(information.StudentNumber);
                _unitOfWork.Repository<StudentInformation>().Add(new StudentInformation()
              {
                  Student = student,
                  StudentId = student.Id,
                  Semester = await _unitOfWork.Repository<Semester>().GetByIntIdAsync(information.SemesterId),
                  AdvisorTeacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(information.AdvisorTeacherId),
                  RecordType = information.RecordType,
                  EducationType = information.EducationType,
                  ComeFromBranch = information.ComeFromBranch,
                  ComeFromFaculty = information.ComeFromFaculty,
                  ComeFromUniversity = information.ComeFromUniversity,
                  Faculty = await _unitOfWork.Repository<Faculty>().GetByIntIdAsync(information.FacultyId),
                  GradeAverage = information.GradeAverage,
                  GraduationYear = information.GraduationYear,
                  StudyProgram = await _unitOfWork.Repository<StudyProgram>().GetByIntIdAsync(information.StudyProgramId),
                  StudyTime = await _unitOfWork.Repository<StudyTime>().GetByIntIdAsync(information.StudyTimeId)
              });
            }
            else
            {
                studentInformation.Semester =
                    await _unitOfWork.Repository<Semester>().GetByIntIdAsync(information.SemesterId);
                studentInformation.AdvisorTeacher =
                    await _unitOfWork.Repository<Teacher>().GetByIdAsync(information.AdvisorTeacherId);
                studentInformation.RecordType = information.RecordType;
                studentInformation.EducationType = information.EducationType;
                studentInformation.ComeFromBranch = information.ComeFromBranch;
                studentInformation.ComeFromFaculty = information.ComeFromFaculty;
                studentInformation.ComeFromUniversity = information.ComeFromUniversity;
                studentInformation.Faculty =
                    await _unitOfWork.Repository<Faculty>().GetByIntIdAsync(information.FacultyId);
                studentInformation.GradeAverage = information.GradeAverage;
                studentInformation.GraduationYear = information.GraduationYear;
                studentInformation.StudyProgram = await _unitOfWork.Repository<StudyProgram>()
                    .GetByIntIdAsync(information.StudyProgramId);
                studentInformation.StudyTime =
                    await _unitOfWork.Repository<StudyTime>().GetByIntIdAsync(information.StudyTimeId);

               _unitOfWork.Repository<StudentInformation>().Update(studentInformation);
            }

            await _unitOfWork.Complete();
            return Ok(new ApiResponse(200,"Güncelleme Başarılı."));
        }

        [HttpGet("get-all-students")]
        public async Task<ActionResult<IReadOnlyList<StudentBasicDto>>> GetAllStudentAsync()
        {
            var spec = new StudentListSpecification();
            return (await _unitOfWork.Repository<Student>().ListAsync(spec))
                .Select(_mapper.Map<StudentBasicDto>)
                .ToList();
        }

        [HttpGet("get-lessons")]
        public async Task<ActionResult<IReadOnlyList<LessonDto>>> GetAllLessonsAsync()
        {
            var spec = new LessonsBySemesterIdSpecification();
            return (await _unitOfWork.Repository<Lesson>().ListAsync(spec))
                .Select(_mapper.Map<LessonDto>).ToList();
        }

        [HttpPost("add-lesson")]
        public async Task<ActionResult<ApiResponse>> AddLessonAsync(LessonAddDto model)
        {
            var mapped = _mapper.Map<Lesson>(model);
            mapped.Semester = await _unitOfWork.Repository<Semester>().GetByIntIdAsync(model.SemesterId);
            mapped.LessonClassRoom = await _unitOfWork.Repository<Classroom>().GetByIntIdAsync(model.LessonClassRoomId);
            mapped.StudyProgram = await _unitOfWork.Repository<StudyProgram>().GetByIntIdAsync(model.StudyProgramId);
            _unitOfWork.Repository<Lesson>().Add(mapped);
            await _unitOfWork.Complete();
            return Ok(new ApiResponse(200, "Ders başarı ile eklendi."));
        }

        [HttpGet("lesson-params")]
        public async Task<LessonParamsDto> GetLessonParamsAsync()
        {
            return new LessonParamsDto()
            {
                ClassRooms = (await _unitOfWork.Repository<Classroom>()
                    .ListAllAsync()).Select(_mapper.Map<ClassRoomDto>).ToList(),
                Semesters = (await _unitOfWork.Repository<Semester>()
                    .ListAllAsync()).Select(_mapper.Map<SemesterDto>).ToList(),
                StudyPrograms = (await _unitOfWork.Repository<StudyProgram>()
                    .ListAllAsync()).Select(_mapper.Map<StudyProgramDto>).ToList()
            };
        }

        [HttpPost("update-exam-date")]
        public async Task<ActionResult<ApiResponse>> UpdateLessonExamDateAsync(Dtos.RequestDto.ExamDateDto examModel)
        {
            var lesson = await _unitOfWork.Repository<Lesson>().GetByIdAsync(examModel.LessonCode);
            if (lesson != null)
            {
                if (examModel.FinalExamDate != null) lesson.FinalExamTime = (DateTime) examModel.FinalExamDate;
                if (examModel.MidExamDate != null) lesson.MidTermTime = (DateTime) examModel.MidExamDate;
                if (examModel.LastExamDate != null) lesson.MakeUpExamTime = (DateTime) examModel.LastExamDate;
                if (examModel.ExamClassId != null)
                    lesson.ExamClassRoom = await _unitOfWork.Repository<Classroom>()
                        .GetByIntIdAsync((int) examModel.ExamClassId);


                _unitOfWork.Repository<Lesson>().Update(lesson);
                await _unitOfWork.Complete();
                return Ok(new ApiResponse(200, "Güncelleme başarı ile tamamlandı."));
            }

            return BadRequest(new ApiResponse(404, "Ders bulunamadı."));
        }

        [HttpGet("get-class")]
        public async Task<ActionResult<IReadOnlyList<ClassRoomDto>>> GetAllClassAsync()
        {
            return (await _unitOfWork.Repository<Classroom>().ListAllAsync())
                .Select(_mapper.Map<ClassRoomDto>)
                .ToList();
        }

        [HttpGet("get-teachers")]
        public async Task<ActionResult<IReadOnlyList<TeacherBasicDto>>> GetAllTeachersAsync()
        {
            return (await _unitOfWork.Repository<Teacher>().ListAllAsync())
                .Select(_mapper.Map<TeacherBasicDto>)
                .ToList();
        }

        [HttpPost("update-lesson-teacher")]
        public async Task<ActionResult<ApiResponse>> UpdateLessonTeacherAsync(LessonsTeacherDto model)
        {
            var lesson = await _unitOfWork.Repository<Lesson>().GetByIdAsync(model.LessonCode);
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(model.TeacherCode);
            if (lesson == null || teacher == null)
            {
                return BadRequest(new ApiResponse(404));
            }
            lesson.Teacher = teacher;
            try
            {
                _unitOfWork.Repository<Lesson>().Update(lesson);
                await _unitOfWork.Complete();
                return Ok(new ApiResponse(200,"Güncelleme başarı ile yapıldı."));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500, e.Message));
            }
        }

        [HttpPost("update-personal-information")]
        public async Task<ActionResult<ApiResponse>> UpdateStudentPersonalInformationAsync(
            Dtos.RequestDto.PersonalInformationDto model)
        {
            var spec = new StudentListSpecification(model.StudentNumber);
            var student = await _unitOfWork.Repository<Student>().GetWithSpec(spec);
           
            if (student != null)
            {
                var information = await _unitOfWork.Repository<StudentPersonalityInformation>()
                    .GetByIntIdAsync(student.PersonalityInformation.Id);
                var mapped = _mapper.Map<StudentPersonalityInformation>(model);

                information.Gender = mapped.Gender;
                information.MaritalStatus = mapped.MaritalStatus;
                information.Address = mapped.Address;
                information.BirthCity = mapped.BirthCity;
                information.Birthday = mapped.Birthday;
                information.FatherName = mapped.FatherName;
                information.MotherName = mapped.MotherName;
                information.MilitaryStatus = mapped.MilitaryStatus;
                information.TcNumber = mapped.TcNumber;
                information.Nationality = mapped.Nationality;

                if (model.FirstName != null ) student.FirstName = model.FirstName;
                if(model.LastName != null ) student.LastName = model.LastName;
                _unitOfWork.Repository<StudentPersonalityInformation>().Update(information);
                _unitOfWork.Repository<Student>().Update(student);
                await _unitOfWork.Complete();
                return Ok(new ApiResponse(200, "Güncelleme başarı ile yapıldı."));
            }
            return BadRequest(new ApiResponse(404, "Öğrenci bulunumadı."));
        }

        [HttpGet("get-personal-information")]
        public async Task<ActionResult<Dtos.ResponseDto.PersonalInformationDto>> GetPersonalInformationAsync(string studentNumber)
        {
            var spec = new StudentPersonalityInformationSpecification(studentNumber);
            var result = _mapper.Map<Dtos.ResponseDto.PersonalInformationDto>(await _unitOfWork
                .Repository<StudentPersonalityInformation>()
                .GetWithSpec(spec));

            if (result == null)
            {
                return BadRequest(new ApiResponse(404, "Kullanıcıya ait bir kayıt bulunamadı"));
            }
            return result;
        }

        [HttpGet("get-education-information")]
        public async Task<ActionResult<EducationInformationDto>> GetEducationInformationAsync(string studentNumber)
        {
            var spec = new StudentInformationSpecification(studentNumber);

            var result =
                _mapper.Map<EducationInformationDto>(await _unitOfWork.Repository<StudentInformation>().GetWithSpec(spec));
            if (result == null)
            {
                return Ok(new ApiResponse(404, "Kullanıcıya ait bir kayıt bulunamadı."));
            }

            return result;
        }

        private async Task<ActionResult> PhotoRepository(IFormFile fileToCome, Student student)
        {
            var result = await _cloudinary.UploadPhoto(student.Id, fileToCome);
            if (result != null)
            {
                _unitOfWork.Repository<Photo>().Add(result);
                await _unitOfWork.Complete();
                return Ok(new ApiObjectResponse<string>(200, result.Url,"Fotoğraf başarı ile yüklendi."));
            }
            return BadRequest(new ApiResponse(500, "Yükleme işleme sırasında bir hata oluştu."));
        }
    }
}
