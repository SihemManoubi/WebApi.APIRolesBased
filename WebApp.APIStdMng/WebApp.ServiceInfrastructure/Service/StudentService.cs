using AutoMapper;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.CoreDomain.Entities;
using WebApp.CoreDomain.STUDENTMNG_dbContext;
using WebApp.DALApplication.IRepository;
using WebApp.ServiceInfrastructure.DTO;
using WebApp.ServiceInfrastructure.IService;

namespace WebApp.ServiceInfrastructure.Service
{
    public class StudentService : ServiceAsync<Student, StudentDto>, IStudentService
    {
        private readonly IRepositoryAsync<Student> _studentRepository;
        private readonly IMapper _mapper;
        protected ILogger<StudentService> _logger;
        private readonly IDbContextFactory _dbContextFactory;

        public StudentService(IRepositoryAsync<Student> studentRepository, IMapper mapper,
            ILogger<StudentService> logger, IDbContextFactory dbContextFactory) : base(studentRepository, mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
            this._logger = logger;
            this._dbContextFactory = dbContextFactory;
        }

        protected StudentmngContext Context => _dbContextFactory?.DbContext;

        public async Task<List<StudentDto>> GetStudents()
        {
            try
            {
                var entity = _studentRepository.GetAll();
                var result = _mapper.Map<List<StudentDto>>(entity);

                return result;
            }
            catch (Exception ex)
            {

                //Logger.Error("Erreur dans GetCustomers <::> " + ex.ToString());
                return null;
            }
        }
    }
}
