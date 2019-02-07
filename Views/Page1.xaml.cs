using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using WpfApp2.Models;
using WpfApp2.UserControls;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public UserControl2 Uc2
        {
            get { return this.uc2; }
            set
            {
                this.uc2 = value;
                OnPropertyChanged("Uc2");
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Page1()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Uc2.DataContext = this.Uc2;
            this.Uc2.Account = new Account();
            this.Uc2.Account.Firstname = "toto";
            this.Uc2.Account.Lastname = "test";
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void ResizeMap()
        {
            this.gameGrid.Children.Clear();
            this.gameGrid.ColumnDefinitions.Clear();
            this.gameGrid.RowDefinitions.Clear();

            for (int i = 0; i < this.Uc2.MapHeight; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                this.gameGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < this.Uc2.MapWidth; i++)
            {
                RowDefinition row = new RowDefinition();
                this.gameGrid.RowDefinitions.Add(row);
            }

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.Uc2.MapHeight; i++)
                {
                    for (int j = 0; j < this.Uc2.MapWidth; j++)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            UserControl1 uc1 = new UserControl1();
                            uc1.X = i;
                            uc1.Y = j;
                            
                            Grid.SetColumn(uc1, i);
                            Grid.SetRow(uc1, j);

                            this.gameGrid.Children.Add(uc1);
                        }));
                    }
                }
            });
        }
        #endregion

        #region Events
        #endregion

        #region Property changed implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
