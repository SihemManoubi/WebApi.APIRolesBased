using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.ServiceInfrastructure.DTO;
using WebApp.ServiceInfrastructure.IService;
using WebApp.ServiceInfrastructure.Service;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentService> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentService> logger) 
        {
            this._studentService = studentService;
            this._logger = logger;
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var lstCustomers = await _studentService.GetStudents().ConfigureAwait(false);
                if (lstCustomers != null)
                {
                    _logger.LogInformation("Appel à GetCustomers réussi.");
                    return new OkObjectResult(lstCustomers);
                }
                else
                {
                    var showmessage = "Pas d'element dans la liste";
                    dict.Add("Message", showmessage);
                    return Ok(dict);
                }
            }
            catch (Exception ex)
            {
                var showmessage = "Erreur" + ex.ToString();

                dict.Add("Message", showmessage);
                _logger.LogError(ex, "Une erreur s'est produite lors de l'appel à GetAllGrades.");
                return BadRequest(dict);
            }
        }
    }
}
