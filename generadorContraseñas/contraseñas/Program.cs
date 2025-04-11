//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

namespace contraseñas // Note: actual namespace depends on the project name.
{
    public class Generar
    {


        public void Contraseña()
        {
            //las listas
            List<char> chars = new List<char>();
            List<char> caracteresRandom = new List<char>();

            //listas de alguns caracteres especiales para hacer la contraseña mas segura
            char[] especiales= { '$', '#', '%','!','&','/','(',')','='};
            char[] numeros = {'1','2','3','4','5','6','7','8','9'};

            //es un bucle donde añade uno por uno un caracter especial y un numero a la lista, 
            //lo que dice el error si ejecuto la linea comentada dentro del for: Argumento 1: no se puede convertir de 'char[]' a 'char'
            for (int añadir = 0; añadir < especiales.Length; añadir++)
            {
                chars.Add(especiales[añadir]);
                chars.Add(numeros[añadir]);
                //chars.Add(especiales);
            }


            //teniendo los caracteres especiales y numeros en el array procedí a meter las letras,no iba a tener un array con 26 letras 
            //entonces hice un bucle para que se agreguen una por una a la lista 

            //los numeros random es para agregar minusculas, si numeroRndom1 es igual numeroRndom2 la hace minusculas y si no entra mayuscula
            Random random = new Random();
            for (char letra = 'A'; letra <= 'Z'; letra++)
            {
                int numeroRandom1 = random.Next(0, 2);
                int numeroRndom2 = random.Next(0, 2);

                if (numeroRandom1 == numeroRndom2)
                {
                    char minuscula = char.ToLower(letra);
                    chars.Add(minuscula);
                }
                else
                {
                    chars.Add(letra);
                }
                    
            }

            //la longitud de la contraseña será de 9, este for agrega a otra lista caracteres random de la lista donde estan todos los otros caracteres
            //con el random los elige random entonces queda una mezcla de caracteres que nos deja una contraseña
            for (int numero = 0; numero <= 8; numero++)
            {

                int letrarandom = random.Next(0, chars.Count);

                caracteresRandom.Add(chars[letrarandom]);

            }
            //genera solo el array de 9
            Console.WriteLine("Contraseña generada: " + string.Join("", caracteresRandom));
        }


    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Creando contraseña.");
            Console.WriteLine("Creando contraseña..");
            Console.WriteLine("Creando contraseña...");

            var imprimir = new Generar();
            imprimir.Contraseña();

            Console.WriteLine("Si quieres otra contraseña digita S");
            string respuesta = Console.ReadLine();
            string respuestados = "";
            //string s ="S";
            while (respuesta == "S" || respuestados=="S")
            {
                respuesta = "";

                var imprimirA= new Generar();
                imprimirA.Contraseña();

                Console.WriteLine("Si quieres otra contraseña digita S");
                string respuesta2 = Console.ReadLine();
                respuestados=respuesta2;
            }
            Console.WriteLine("Gracias,Adios");
        }



    }
}