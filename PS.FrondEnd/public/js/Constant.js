const URLBASETEMPLATE = "https://localhost:44377/api";
const URLBASEAUTH = "http://localhost:50864/api";

let GETCURSOBYID = URLBASETEMPLATE + "/Curso/";

export default GETCURSOBYID;

export class ResponseGetCursoById {
    constructor(id, materia, profesor, alumnos){
        this.cursoId = id,
        this.materia = materia,
        this.profesor = profesor,
        this.alumnos = alumnos
    }
}
export class Profesor{
    constructor(id, nombre, apellido){
        this.profesorId = id,
        this.nombre = nombre,
        this.apellido = apellido
    }
}
export class Alumno{
    constructor(id, nombre, apellido, legajo){
        this.alumnoId = id,
        this.nombre = nombre,
        this.apellido = apellido,
        this.legajo = legajo
    }
}