$(function () {
    $.get("KundeBestilling/HentAlle", function (kundeBestillinger) {
        formaterTabell(kundeBestillinger);
    });
});

function formaterTabell(kundeBestillinger) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Pizza-type</th><th>Tykkelse</th><th>Antall</th><th>Navn</th><th>Adresse</th><th>Telefonnummer</th>" +
        "</tr>";

    for (let kundeBestilling of kundeBestillinger) {

        ut += "<tr>" +
            "<td>" + kundeBestilling.type + "</td>" +
            "<td>" + kundeBestilling.tykkelse + "</td>" +
            "<td>" + kundeBestilling.antall + "</td>" +
            "<td>" + kundeBestilling.navn + "</td>" +
            "<td>" + kundeBestilling.adresse + "</td>" +
            "<td>" + kundeBestilling.telefonnummer + "</td>" +
            "</tr>"
    }

    ut += "</table>";
    $("#tableBestillinger").html(ut);
}