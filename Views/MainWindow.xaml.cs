using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using WpfApp2.Database;
using WpfApp2.Database.DTO;
using WpfApp2.Models;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        ObservableCollection<Class1> class1s = new ObservableCollection<Class1>();
        ObservableCollection<Class2> class2s = new ObservableCollection<Class2>();
        #endregion

        #region Attributs
        #endregion

        #region Properties
        public ObservableCollection<Class1> Class1s { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            BindListviews();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void BindListviews()
        {
            this.class1List.ItemsSource = class1s;
            this.class2List.ItemsSource = class2s;
        }
        #endregion

        #region Events
        private void BtnCreateClass1_Click(object sender, RoutedEventArgs e)
        {
            Class1 class1 = new Class1(this.txtBDataClass1.Text);

            System.Console.WriteLine(class1.Data);
            System.Console.WriteLine((class1 as MotherClass1).Data);
            System.Console.WriteLine((class1 as Interface1).MyProperty);

            Interface1 i1 = new Class1();
            (i1 as Class1).Lastname = "";

            class1s.Add(class1);
            System.Console.WriteLine(class1.Data);
        }

        private void BtnCreateClass2_Click(object sender, RoutedEventArgs e)
        {
            Class2 class2 = new Class2(this.txtBDataClass2.Text);
            class2s.Add(class2);
            System.Console.WriteLine(class2.Data);
        }
        #endregion

        private void DbBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                Class1Dto myDto = new Class1Dto();
                myDto.Data = "bonjour";
                myDto.IntArray = new int[]{1,20,30,7};
                Class2Dto subDto = new Class2Dto();
                subDto.Data = "sub data";
                myDto.Class2Dtos.Add(subDto);

                db.Class1DtoDbSet.Add(myDto);

                db.SaveChanges();

                System.Console.WriteLine("--------------------------");
                System.Console.WriteLine("Class1Dto");

                foreach (var item in db.Class1DtoDbSet.Include(c => c.Class2Dtos))
                {
                    System.Console.WriteLine(item.ToString());
                }

                System.Console.WriteLine("--------------------------");
                System.Console.WriteLine("Class2Dto");

                foreach (var item in db.Class2DtoDbSet)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }

        private void GoTN_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
        }
    }
}
