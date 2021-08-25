using Alunos.Domain.Service.Alunos.Dto;
using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Domain.Service.MateriaAlunos.Dto;
using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.MateriaProfessores.Dto;
using Alunos.Domain.Service.Materias.Dto;
using Alunos.Domain.Service.Materias.Entities;
using Alunos.Domain.Service.Professores.Dto;
using Alunos.Domain.Service.Professores.Entities;
using AutoMapper;

namespace Alunos.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlunosEntity, AlunosDto>();
            CreateMap<AlunosDto, AlunosEntity>();

            CreateMap<MateriaAlunosEntity, MateriaAlunosDto>();
            CreateMap<MateriaAlunosDto, MateriaAlunosEntity>();

            CreateMap<MateriaProfessoresEntity, MateriaProfessoresDto>();
            CreateMap<MateriaProfessoresDto, MateriaProfessoresEntity>();

            CreateMap<MateriasEntity, MateriasDto>();
            CreateMap<MateriasDto, MateriasEntity>();

            CreateMap<ProfessoresEntity, ProfessoresDto>();
            CreateMap<ProfessoresDto, ProfessoresEntity>();
        }
    }
}
