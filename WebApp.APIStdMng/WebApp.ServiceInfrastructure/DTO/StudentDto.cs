using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.CoreDomain.Entities;
using WebApp.ServiceInfrastructure.Common.Mappings;

namespace WebApp.ServiceInfrastructure.DTO
{
    public class StudentDto : IMapFrom<Student>
    {
        public string Matricule { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public DateTime Registerdate { get; set; }

        public string Faculty { get; set; } = null!;

        public string? Average { get; set; }

        public string Section { get; set; } = null!;

        public string? Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>().ReverseMap();
        }

    }
}
