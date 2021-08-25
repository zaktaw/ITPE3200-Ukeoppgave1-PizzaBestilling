$(function () {
    $.get("KundeBestilling/HentAlle", function (kunder) {
        console.log(kunder);
    });
});