﻿using EscuelaEtapa1.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //La ESCUELA debe utilizar la estructura (atributos y metodos) de la interfaz.
    public class Escuela : ObjetoEscuelaBase, Ilugar
    {
       

        //Crear una variable + su propiedad de acceso de forma automatica con el atajo PROP:
        //PROP (presionar: 2 veces "Tab"): atajo para crear una propiedad
        //PROP FULL: crea la variable que encapsula ademas de la propiedad para acceder a ella.
        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        /*En caso de utilizar array:
        public Curso[] Cursos { get; set; }*/

        //En caso de utilizar colecciones, en este caso "lista generica" de cursos
        public List<Curso> Cursos { get; set; }

        //MECANISMOS PARA INICIALIZAR LA ESCUELA
        //Constructor: metodo que ayuda a crear una instancia de este objeto
        //La escuela se crea con un nombre y un año
        //Hay muchas formas de escribir un CONTRUCTOR
        /*public Escuela(string nombreEntrada, int año)
        {
            this.nombre = nombreEntrada;
            AñoDeCreacion = año;
        }*/

        //Manera corta de escribir un metodo: IGUALACION POR TUPLAS
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        //Otra manera de escribir un constructor
        public Escuela(string nombre,
            int año, 
            TiposEscuela tipo,
            string pais="",
            string ciudad="")
        {
            //Asignacion por duplas
            (Nombre, AñoDeCreacion) = (nombre, año);
            Pais = pais;
            this.Ciudad = ciudad;
        }

        //LA SOBRECARGA se evidencia en los metodos constructores anteriores. Tienen el mismo nombre pero parametros diferentes.

        //Sobre-escribir un metodo:Cambiar funcionalidad
        //El signo dolar antes de la cadena de texto nos permite utilizar variables especificadas
        //Aqui: string pais=""  es un metodo opcional
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} \nPaís: {Pais}, Ciudad: {Ciudad}";
        }
        //Caracteres especiales. Por ejemplo en caso de tener que imprimir comillas: \"{Nombre}\"
        //Salto de linea: \n o {System.Environment.NewLine} que es posible de utilizar en todos los sistemas operativos

        //Implementación del metodo LimpiarLugar
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando la escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} limpia.");
            Printer.Beep(1000, cantidad:3);
        }
    }
}
