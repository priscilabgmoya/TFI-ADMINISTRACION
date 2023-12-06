function filtroDinamicoProyecto(input_view, body_view) {
    var input, filter, tBody, tr, td, i, txtValue;
    input = document.getElementById(`${input_view}`);
    filter = input.value.toUpperCase();
    tBody = document.getElementById(`${body_view}`);
    tr = tBody.getElementsByTagName('tr');

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}

function limpiarView() {
    window.location.reload(); 
}

function obtenereEmpleadoSeleccionado(x) {
    var table = document.getElementById("myTBodyEmpleados");
    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].style.backgroundColor = "white";
        table.rows[i].style.fontSize = "1em";
        table.rows[i].style.fontWeight = "Normal";
    }

    x.style.backgroundColor = "gray";
    x.style.fontSize = "1.1em";
    x.style.fontWeight = "bold";

    var legajo = table.rows[x.rowIndex].cells[0].innerHTML;
    document.getElementById("legajoSeleccionado").value = legajo;
}

function filtrarEquipo() {
    var selectedEquipo = document.getElementById('NumeroDeEquipo').value;
    var rows = document.getElementById('myTBodytablaEquipos').getElementsByTagName('tr');
    for (var i = 0; i < rows.length; i++) {
        var equipoCellValue = rows[i].getElementsByTagName('td')[4].innerText;
        if (selectedEquipo === "" || equipoCellValue === selectedEquipo) {
            rows[i].style.display = ""; 
        } else {
            rows[i].style.display = "none"; 
        }
    }
}