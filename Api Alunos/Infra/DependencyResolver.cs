using Alunos.Domain.Mapper;
using Alunos.Domain.Service.Alunos;
using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.Materias;
using Alunos.Domain.Service.Professores;
using Alunos.Infra.Data;
using Alunos.Infra.Repositories.Alunos;
using Alunos.Infra.Repositories.MateriaAlunos;
using Alunos.Infra.Repositories.MateriaProfessores;
using Alunos.Infra.Repositories.Materias;
using Alunos.Infra.Repositories.Professores;
using Alunos.SharedKernel.Notification;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Alunos.Infra
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AutoMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<INotification, Notification>();
            services.AddDbContext<ApplicationContext>();

            Repositories(services);
            Services(services);
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();
            services.AddScoped<IAlunosRepository, AlunosRepository>();
            services.AddScoped<IMateriaAlunosRepository, MateriaAlunosRepository>();
            services.AddScoped<IMateriaProfessoresRepository, MateriaProfessoresRepository>();
            services.AddScoped<IMateriasRepository, MateriasRepository>();
            services.AddScoped<IProfessoresRepository, ProfessoresRepository>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IAlunosService, AlunosService>();
            services.AddScoped<IMateriaAlunosService, MateriaAlunosService>();
            services.AddScoped<IMateriaProfessoresService, MateriaProfessoresService>();
            services.AddScoped<IMateriasService, MateriasService>();
            services.AddScoped<IProfessoresService, ProfessoresService>();
        }
    }
}
