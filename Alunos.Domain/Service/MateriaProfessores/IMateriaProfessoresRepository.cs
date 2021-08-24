﻿using System.Collections.Generic;

namespace Alunos.Domain.Service.MateriaProfessores
{
    public interface IMateriaProfessoresRepository
    {
        IEnumerable<MateriaProfessoresEntity> Get();
        MateriaProfessoresEntity GetById(int id);
        MateriaProfessoresEntity Post(MateriaProfessoresEntity materiaProfessores);
        IEnumerable<MateriaProfessoresEntity> GetByNameProfessor(string nomeProfessor);
        IEnumerable<MateriaProfessoresEntity> GetByNameMateria(string nomeMateria);
        bool Delete(MateriaProfessoresEntity materiaProfessores);
    }
}