$(function () {
    
});

function bestill() {
    const kunde = {
        navn: $("#textNavn").val(),
        adresse: $("#textAdresse").val(),
        telefonnummer: $("#textTelefonnummer").val()
    };

    $.post("KundeBestilling/Lagre", kunde, function (OK) {
        if (OK) {
            console.log("OK")
            window.location.href = "index.html";
        }
        else {
            $("#error").html("Feil i db - prøv igjen senere");
        }
    });
}