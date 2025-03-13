// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let boton = document.querySelector('.boton');
let titulo = document.querySelector('.text-center')
boton.addEventListener('click', () => {
    titulo.style.color = "red";

});