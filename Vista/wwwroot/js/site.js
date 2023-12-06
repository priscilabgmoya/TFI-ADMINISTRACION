// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function filtroDinamico() {
    var input, filter, tBody, tr, td, i, txtValue;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    tBody = document.getElementById("myTBody");
    tr = tBody.getElementsByTagName('tr');

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}

function obtenereEmpleadoSeleccionado(x) {
    var table = document.getElementById("tablaEmpleados");
    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].style.backgroundColor = "white";
        table.rows[i].style.fontSize = "1em";
        table.rows[i].style.fontWeight = "Normal";
    }

    x.style.backgroundColor = "gray";
    x.style.fontSize = "1.2em";
    x.style.fontWeight = "bold";

    var legajo = table.rows[x.rowIndex].cells[0].innerHTML;
    document.getElementById("legajoSeleccionado").value = legajo;
}


function filtrarTabla() {
    var filter, tBody, tr, td, i, txtValue;
    filter = document.getElementById('selectTipoTarea').value;
    tBody = document.getElementById("tablaTareas");
    tr = tBody.getElementsByTagName('tr');

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[6];
        if (td) {
            txtValue = td.textContent || td.innerText;

            if (filter === "Todas") {
                tr[i].style.display = "";
            } else {
                if (txtValue.indexOf(filter) > -1) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
}

function validarFecha() {
    var fechaInput = document.getElementById('Tarea_FechaFinalEstimada').value;
    var fechaSeleccionada = new Date(fechaInput);
    var fechaActual = new Date();

    if (fechaSeleccionada <= fechaActual) {
        alert('Selecciona una fecha futura.');
        // Puedes tomar otras acciones, como deshabilitar el botón de envío o limpiar el campo.
        document.getElementById('Tarea_FechaFinalEstimada').value = ''; // Limpiar la fecha
    }
}


function obtenereTareaSeleccionada(x) {
    var table = document.getElementById("tablaTareas");
    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].style.backgroundColor = "white";
        table.rows[i].style.fontSize = "1em";
        table.rows[i].style.fontWeight = "Normal";
    }

    x.style.backgroundColor = "gray";
    x.style.fontSize = "1.2em";
    x.style.fontWeight = "bold";

    var numeroTarea = table.rows[x.rowIndex].cells[0].innerHTML;
    var elementos = document.getElementsByClassName("tareaElegida");
    for (var i = 0; i < elementos.length; i++) {
        elementos[i].value = numeroTarea;
    }
}
function limpiarViewEmpleado() {
    window.location.reload();
}
function ocultarNavBar() {
    console.log(window.location.pathname);
    if (window.location.pathname == "/Login/IniciarSesion"
        || window.location.pathname == "/"
        || window.location.pathname == "/Login/AccesoDenegado") {
        const navBar = document.querySelector(".containerNavBar");
        navBar.classList.remove("containerNavBar");
        navBar.classList.add("ocultarNavBar");        
    }
}

ocultarNavBar(); 
