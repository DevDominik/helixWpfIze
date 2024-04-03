using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WpfApp1
{

    public interface IBolygo
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }


        public bool Szabad { get; set; }
    }
    public class Bolygo : IBolygo
    {

        public Bolygo(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public bool Szabad { get; set; }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public static double Tavolsag(Bolygo egyik, Bolygo masik)
        {
            return Math.Sqrt(Math.Pow(masik.X - egyik.X, 2) + Math.Pow(masik.Y - egyik.Y, 2) + Math.Pow(masik.Z - egyik.Z, 2));
        }

        public List<Bolygo> VisszadobKoronBelul(List<Bolygo> bolygok)
        {
            List<Bolygo> vissza = new();
            foreach (Bolygo bolygo in bolygok)
            {
                if (bolygo != this && Szabad == true && Tavolsag(bolygo, this) <= 900)
                {
                    vissza.Add(bolygo);
                }
            }
            return vissza;
        }
    }
}
