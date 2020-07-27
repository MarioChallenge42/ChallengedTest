var ctx = document.querySelector("canvas").getContext("2d"),
    dashLen = 120, dashOffset = dashLen, speed = 5,
    txt = '', x = 30, i = 0,Url='';
ctx.font = "50px Comic Sans MS, cursive, TSCu_Comic, sans-serif";
ctx.lineWidth = 5; ctx.lineJoin = "round"; ctx.globalAlpha = 2 / 3;
ctx.strokeStyle = ctx.fillStyle = "#1f2f90";

(function loop() {
    ctx.clearRect(x, 0, 60, 150);
    ctx.setLineDash([dashLen - dashOffset, dashOffset - speed]); // create a long dash mask
    dashOffset -= speed;                                         // reduce dash length
    ctx.strokeText(txt[i], x, 90);                               // stroke letter

    if (dashOffset > 0) requestAnimationFrame(loop);             // animate
    else {
        ctx.fillText(txt[i], x, 90);                               // fill final letter
        dashOffset = dashLen;                                      // prep next char
        x += ctx.measureText(txt[i++]).width + ctx.lineWidth * Math.random();
        ctx.setTransform(1, 0, 0, 1, 0, 3 * Math.random());        // random y-delta
        ctx.rotate(Math.random() * 0.005);                         // random rotation
        if (i < txt.length) requestAnimationFrame(loop);
    }
})();

$(function () {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });

   

    $.ajax({
        url: Url,
        type: 'GET',
        async: true,
        contentType: "application/json",
        success: function (result) {
            debugger;
            Toast.fire({
                icon: 'info',
                title: 'Emplo AJAX, Número de usuarios en la Base:' + result
            })

        }

    });

   


});

$(document).Toasts('create', {
    title: 'Infomación del Proyecto',
    position: 'topLeft',
    body: 'Se desarrollo una aplicación: MVC async controllers, IoC, AJAX, HTML5, Oauth. .'
})