// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using atributosBanco;
//using Azure.Core;
using servicios.serviciosBanco;
using conexion;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Proceso
{
    public async Task menu()
    {
        Console.WriteLine("MENÚ PRINCIPAL");
        await Task.Delay(3000); //1000 milisegundos= 1 segundo
        Console.WriteLine("1.Registrarse");
        Console.WriteLine("2. Iniciar Sesion");
        Console.ReadLine();
        //Console.WriteLine("3. Ver Saldo");
    }



    public void registrar()
    {
        //esto es igual a un insertae de los otros CRUDs que he hecho

        //cedula
        int cedulaBien;
        Console.WriteLine("Ingrese su cedula sin guiones o espacios");
        bool cedula = int.TryParse(Console.ReadLine(), out cedulaBien);

        //nombre
        Console.WriteLine("Ingrese su nombre y apellido");
        string nombre= Console.ReadLine();

        //contraseña
        Console.WriteLine("Ingrese una contraseña segura");
        string contraseña= Console.ReadLine();

        //Console.WriteLine(cedulaBien);
        if (cedula)
        {
            Console.WriteLine("Ingrese cedula valida");

            
        }
        else if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Igrese bien el nombre y el apellido");
        } else if (string.IsNullOrWhiteSpace(contraseña))
        { 
            Console.WriteLine("Contraseña no valida");
        }
        //var negocio = new servicios.serviciosBanco.serviciosBancoSimulador();
        //var tabla = new tabla
        //{
            

        //}
    }

}
public class Progra
{
    static async Task Main()
    {
        var abrir = new Proceso();
        //await abrir.menu();

        abrir.registrar();
    }



}