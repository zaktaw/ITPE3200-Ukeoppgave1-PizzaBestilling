$(function () {
});

function bestill() {
    const kundeBestilling = {
        type: $("#selectType").val(),
        tykkelse: $("input[name='tykkelse']:checked").val(),
        antall: $("#textAntall").val(),
        navn: $("#textNavn").val(),
        adresse: $("#textAdresse").val(),
        telefonnummer: $("#textTelefonnummer").val()
    };

    $.post("KundeBestilling/Lagre", kundeBestilling, function (OK) {
        if (OK) {
            window.location.href = "index.html";
        }
        else {
            $("#error").html("Feil i db - prøv igjen senere");
        }
    });
}