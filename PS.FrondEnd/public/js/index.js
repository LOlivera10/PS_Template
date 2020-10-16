import { ResponseGetCursoById, Profesor, Alumno } from "./Constant.js";
import * as Service from "./CursoService.js";

window.onload = () =>{
    $("#buscar").on("click", CursoGetById);
    //LoadTable(CrearCurso());
}

function CrearCurso(){
    var prof = new Profesor("2F815CED-6769-458D-BC7E-E95FBFD8DF26", "Ciro", "Y los persas");
    var alumnos = [
        new Alumno("1", "nombre1", "apellido1", "legajo1"),
        new Alumno("2", "nombre2", "apellido2", "legajo2"),
    ];
    var curso = new ResponseGetCursoById("id","Proyecto", prof, alumnos);
    
    console.log(curso);
    return curso;

}

function LoadTable(Curso){
    //var informacion = $("#CursoInfo");
    var informacion = document.getElementById("CursoInfo");
    informacion.innerHTML += "<label>CursoId: <span>"+ Curso.cursoId +"</span></label>";
    informacion.innerHTML += "<label>Materia: <span>"+ Curso.materia +"</span></label>";
    informacion.innerHTML += "<label>Docente: <span>"+ Curso.profesor.nombre + " " + Curso.profesor.apellido  +"</span></label>";
    
    var table = document.getElementById("TableCursoInfo").getElementsByTagName("tbody")[0];
    Curso.alumnos.forEach(alumno => {
        var newRow = table.insertRow(table.rows.length);
        newRow.innerHTML = 
        "<tr>" 
            + "<td>"+alumno.alumnoId+"</td>"
            +"<td>"+alumno.nombre+"</td>"
            +"<td>"+alumno.apellido+"</td>"
            +"<td>"+alumno.legajo+"</td>"
        +"</tr>";
    });
}

function CursoGetById(){
    var id = document.getElementById("inputCurso").value;
    Service.default(id).then(x => LoadTable(x))
}
