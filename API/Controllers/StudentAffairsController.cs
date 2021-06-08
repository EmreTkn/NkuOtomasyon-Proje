using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.ResponseDto;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification.StudentSpecs;
using Core.Specification.UpdateSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UpdateStudentDto = API.Dtos.UpdateStudentDto;

namespace API.Controllers
{

    public class StudentAffairsController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinary;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
       

        public StudentAffairsController(UserManager<User> userManager,IUnitOfWork unitOfWork,ICloudinaryService cloudinary, IStudentService studentService, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _cloudinary = cloudinary;
            _studentService = studentService;
            _mapper = mapper;
        }



        [HttpPost("upload-photo")]
        public async Task<ActionResult> UploadPhotoForStudentAsync([FromForm]string studentNumber,[FromForm]IFormFile fileToCome)
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
            return Ok();
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

        [HttpGet("get-all-students")]
        public async Task<ActionResult<IReadOnlyList<StudentBasicDto>>> GetAllStudentAsync()
        {
            var spec = new StudentListSpecification();
            return (await _unitOfWork.Repository<Student>().ListAsync(spec))
                .Select(_mapper.Map<StudentBasicDto>)
                .ToList();
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
