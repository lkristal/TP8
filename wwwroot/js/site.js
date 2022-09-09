// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetTemporadas(idserie,tituloSerie)
{
    $.ajax({  
        url: '/Home/VerTemporadas',
        data: { IdSerie: idserie }, 
        type : 'GET',
        dataType : 'json',
        success : function(response) {
            $("#ModalTitle").text("Temporadas de la serie " + tituloSerie);
            let body="";
            response.forEach(item => {
                body += item.numeroTemporada + " " + item.tituloTemporada + "<br>";
            }); 
            $("#ModalBody").html(body);
        }
    });
}

function GetActores(idserie,tituloSerie)
{
    $.ajax({  
        url: '/Home/VerActores',
        data: { IdSerie: idserie }, 
        type : 'GET',
        dataType : 'json',
        success : function(response) {
            $("#ModalTitle").text("Actores de la serie " + tituloSerie);
            let body="";
            response.forEach(item => {
                body += item.nombre + "<br>";
            }); 
            $("#ModalBody").html(body);
        }
    });
}

function GetInfo(idserie)
{
    $.ajax({  
        url: '/Home/VerInfo',
        data: { IdSerie: idserie }, 
        type : 'GET',
        dataType : 'json',
        success : function(response) {
            $("#ModalTitle").text("Serie " + response.nombre);
            const body = response.añoInicio + "<br>" + response.sinopsis;
            $("#ModalBody").html(body);       
        }
    });
}