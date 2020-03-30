using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    public class Program
    {
        static List<Coche> listado = new List<Coche>();
        static void Main(string[] args)
        {

        }

        static List<Coche> Ejer1()
        {
            using (StreamReader lector = new StreamReader("Cars.json"))
            {
                string json = lector.ReadToEnd();
                listado = JsonConvert.DeserializeObject<List<Coche>>(json);
                return listado;
            }
        }



        static void Ejer2()
        {
            var fabri = listado.GroupBy(x => x.Maker).Select(y => y.First());

            foreach (var i in fabri)
            {

                Console.WriteLine($"Maker: {i.Maker}");

            }
        }



        static void Ejer3(List<Coche> listado)
        {
            var colors = listado.GroupBy(x => x.Color).Select(y => y.First());
            foreach (var i in colors)
            {
                Console.WriteLine("Color: " + i.Color + " Fabricante: " + i.Maker + " Modelo: " + i.Model);
            }
        }



        static void Ejer4(List<Coche> listado)
        {
            var list = listado.Where(x => x.Color == "Green");
            foreach (var i in list)
            {
                Console.WriteLine("Maker : {i.Maker} Model : {i.Model}");
            }
        }
        static void Ejer5(double latitud, double longitud, List<Coche> listado) 
        {
            var buscar = listado.Where(x => x.Location.Latitude == latitud && x.Location.Longitude == longitud);
            foreach (var i in buscar)
            {
                if (i.Year == 1992)
                {
                    Console.WriteLine("No hay coche en latitud :"+latitud+"y longitud "+ longitud +"en el año 1992");
                }
                else
                {
                    Console.WriteLine("Hay coche en latitud :" + latitud + "y longitud " + longitud + "en el año 1992");
                }
            }

        }
        static void Ejer6(List<Coche> listado) 
        {
            var anios = listado.Where(x => x.Year >= 2001);

            foreach (var i in anios)
            {

                Console.WriteLine(i.Maker + "" + i.Model);

            }
        }
        static void Ejer7(List<Coche> listado)
        {
            var searchnull = listado.Where(x => x.Location.Latitude != null && x.Location.Longitude != null);
            

            foreach (var i in searchnull)
            {

                Console.WriteLine("Modelo: " + i.Model + " Fabricante: " + i.Maker);

            }

        }



        static void Ejer8(List<Coche> Listado)
        {
            var searchblue = Listado.Where(x => x.Year >= 1999 && x.Color == "Blue");
            foreach (var i in searchblue)
            {
                Console.WriteLine(i);
            }

        }



        static void Ejer9(List<Coche> listado)
        {
            var fabris = listado.OrderBy(x => x.Year).GroupBy(x => x.Maker);
            foreach (var i in fabris)
            {
                Console.WriteLine(i.Key);
            }

        }



        static void Ejer10(List<Coche> listado)
        {
            var modCoches = listado.GroupBy(x => x.Model).Select(y => y.First());
            foreach (var i in modCoches)
            {
                Console.WriteLine(i.Maker + " - " + i.Color);
            }

        }



        static void Ejer11(List<Coche> listado)
        {
            for (int i = 0; i < listado.Count; i += 10)
            {
                var pags = listado.Skip(0 + i).Take(10);
                foreach (var x in pags)
                {
                    Console.WriteLine(x.ToString());
                }
                Console.ReadKey();

            }

        }



        static void Ejer12(List<Coche> listado)
        {
            var zuzukis = listado.Where(x => x.Maker == "Suzuki" && x.Year > 2001).Take(1);
            foreach (var i in zuzukis)
            {
                Console.WriteLine(i);
            }

        }



        static void Ejer13(List<Coche> listado)
        {
            var cochesanios = listado.Where(x => x.Year != null);
            foreach (var i in cochesanios)
            {
                Console.WriteLine(i);
            }

        }



        static void Ejer14(List<Coche> listado)
        {
            var rosas = listado.Where(x => x.Color == "Pink").GroupBy(y => y.Year);
            foreach (var i in rosas)
            {
                Console.WriteLine(i);
            }
 
        }


        static void Ejer15(List<Coche> listado)
        {
            var bar = listado.Where(x => x.Maker == "BMW" && x.Year == null && string.IsNullOrEmpty(x.Color));
            foreach (var i in bar)
            {
                Console.WriteLine(i);
            }

        }

        public static void Ejer16(List<Coche> listado, string colors, string model)
        {
            var colmod = listado.Where(x => x.Color != colors && x.Model != model);

            foreach (var i in colmod)
            {
                Console.WriteLine(i);
            }

        }

    }
}

