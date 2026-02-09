using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ServiceInfrastructure.DTO;

namespace WebApp.ServiceInfrastructure.IService
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetStudents();
    }
}
