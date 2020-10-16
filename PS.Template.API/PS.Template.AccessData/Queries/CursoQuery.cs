using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PS.Template.AccessData.Queries
{
    public class CursoQuery : ICursoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public CursoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllCursoDto> GetAllCursos(string apellido)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Cursos")
                .Select("Cursos.CursoId",
                "Cursos.Materia",
                "Profesores.ProfesorId",
                "Profesores.Nombre AS ProfesorNombre",
                "Profesores.Apellido AS ProfesorApellido")
                .Join("Profesores", "Profesores.ProfesorId", "Cursos.ProfesorId")
                .When(!string.IsNullOrWhiteSpace(apellido), q => q.WhereLike("Profesores.Apellido", $"%{apellido}%"));

            var result = query.Get<ResponseGetAllCursoDto>();

            return result.ToList();
        }

        public ResponseGetCursoById GetById(string cursoId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var curso = db.Query("Cursos")
                .Select("CursoId", "Materia", "ProfesorId")
                .Where("CursoId", "=", cursoId)
                .FirstOrDefault<ResponseGetAllCursoDto>();

            var profesor = db.Query("Profesores")
                .Select("ProfesorId", "Nombre", "Apellido")
                .Where("ProfesorId", "=", curso.ProfesorId)
                .FirstOrDefault<ResponseGetCursoByIdProfesor>();

            var alumnos = db.Query("Alumnos")
                .Select("AlumnoId", "Nombre", "Apellido", "Legajo")
                .Where("CursoId", "=", cursoId)
                .Get<ResponseGetCursoByIdAlumno>()
                .ToList();

            return new ResponseGetCursoById
            {
                CursoId = curso.CursoId,
                Materia = curso.Materia,
                Profesor = profesor,
                Alumnos = alumnos
            };
        }
    }
}
