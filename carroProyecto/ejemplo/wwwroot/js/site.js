// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//  Método para procesar el formulario login
const form = document.querySelector("formulario");

form.addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("username").value;

    const clave = document.getElementById("password").value;

    const mensaje = document.getElementById("mensaje");

    if (usuario == "admin" && clave == "1234") {
        window.location.href = "/Home/Loggin";

    } else {
        mensaje.textContent = "Usuario o contraseña mal";
        //mensaje.textContent = "Usuario o contraseña mal";
    }

});