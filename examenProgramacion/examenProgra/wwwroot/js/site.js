// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const form = document.querySelector("#formulario");

form.addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("username").value;

    const clave = document.getElementById("password").value;

    const mensaje = document.getElementById("mensaje");

    const titulo = document.querySelector(".loginClass");

    if (usuario == "ADMIN" && clave == "Adm1n!") {
        window.location.href = "/Home/ofertas";

        //no pude quitarle el titulo o modificarlo porque cuando entra recarga la paginay lo que hago se pierde
        //titulo.textContent= "ingresado";

    } else {
        mensaje.textContent = "Usuario o contraseña mal";
        //window.location.href = "/Home/Productos";
        //mensaje.textContent = "Usuario o contraseña mal";
    }

});
