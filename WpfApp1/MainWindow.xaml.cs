using HelixToolkit.Wpf;
using System.Drawing;
using System.IO;
using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EllipsoidVisual3D utolsoMinimalis;
            foreach (string item in File.ReadAllLines("gyongyok.txt").Skip(1).ToList())
            {
                string[] bontott = item.Split(';');
                Gyongy gyongy = new(int.Parse(bontott[0]) * 3, int.Parse(bontott[1]) * 3, int.Parse(bontott[2]) * 3, int.Parse(bontott[3]));
                EllipsoidVisual3D idk = new EllipsoidVisual3D();
                idk.RadiusX = gyongy.E;
                idk.RadiusY = gyongy.E;
                idk.RadiusZ = gyongy.E;
                idk.Center = new Point3D(gyongy.X, gyongy.Y, gyongy.Z);
                idk.Fill = new SolidColorBrush(Colors.Red);
                ter.Children.Add(idk);
                
            }

        }
    }
}