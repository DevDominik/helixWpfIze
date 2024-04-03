using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WpfApp1;

namespace Bolygok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<EllipsoidVisual3D> kijelolt = new();
        public static Dictionary<EllipsoidVisual3D, Bolygo> osszes = new();
        public static List<EllipsoidVisual3D> eddigBejart = new();
        public MainWindow()
        {
            InitializeComponent();
            foreach (string item in File.ReadAllLines("3D-G200-P865-ÉlSűrű.txt").Skip(1).ToList())
            {
                string[] bontott = item.Split(';');
                Bolygo bolygo = new(double.Parse(bontott[0]) * 3, double.Parse(bontott[1]) * 3, double.Parse(bontott[2]) * 3);
                EllipsoidVisual3D terElem = new EllipsoidVisual3D();
                terElem.RadiusX = 5;
                terElem.RadiusY = 5;
                terElem.RadiusZ = 5;
                terElem.Center = new Point3D(bolygo.X, bolygo.Y, bolygo.Z);
                terElem.Fill = new SolidColorBrush(Colors.Red);
                ter.Children.Add(terElem);
                osszes[terElem] = bolygo;
            }

            
        }

        

        private List<Bolygo> EltavolitBejart()
        {
            List<Bolygo> vissza = new();
            foreach (var item in osszes)
            {
                if (!eddigBejart.Contains(item.Key))
                {
                    vissza.Add(item.Value);
                }
            }
            return vissza;
        }
        
        private List<EllipsoidVisual3D> UtvonalGenerator(Bolygo kezdo, Bolygo vegso)
        {
            List<Bolygo> bolygokLista = kezdo.VisszadobKoronBelul(EltavolitBejart());
            Bolygo legkozelebbi = kezdo;
            foreach (Bolygo bolygo in bolygokLista)
            {
                if (Bolygo.Tavolsag(vegso, legkozelebbi) < Bolygo.Tavolsag(vegso, kezdo))
                {
                    legkozelebbi = bolygo;
                }
            }
            List<EllipsoidVisual3D> vissza = UtvonalGenerator(legkozelebbi, vegso);
            
            return vissza;
        }

        private void ter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult htr = VisualTreeHelper.HitTest(ter, e.GetPosition(ter));
            if (htr != null && htr.VisualHit is EllipsoidVisual3D) {
                EllipsoidVisual3D clicked = (EllipsoidVisual3D)htr.VisualHit;
                if (kijelolt.Count < 2)
                {
                    clicked.Fill = new SolidColorBrush(Colors.Blue);
                    kijelolt.Add(clicked);
                    return;
                }
                clicked.Fill = new SolidColorBrush(Colors.Red);
                kijelolt.Remove(clicked);
            }
        }

        private void btnRajzol_Click(object sender, RoutedEventArgs e)
        {
            if (kijelolt.Count == 2)
            {
                
                LinesVisual3D vonalazas = new();
                
                foreach (var item in UtvonalGenerator(osszes[kijelolt[0]], osszes[kijelolt[1]]))
                {

                }
                ter.Children.Add(vonalazas);

            }
        }
    }
}
