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
    public partial class GamePage : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GamePage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        //public void ResizeMap()
        //{
        //    this.gameGrid.Children.Clear();
        //    this.gameGrid.ColumnDefinitions.Clear();
        //    this.gameGrid.RowDefinitions.Clear();

        //    for (int i = 0; i < this.Uc2.MapHeight; i++)
        //    {
        //        ColumnDefinition col = new ColumnDefinition();
        //        this.gameGrid.ColumnDefinitions.Add(col);
        //    }

        //    for (int i = 0; i < this.Uc2.MapWidth; i++)
        //    {
        //        RowDefinition row = new RowDefinition();
        //        this.gameGrid.RowDefinitions.Add(row);
        //    }

        //    Task.Factory.StartNew(() =>
        //    {
        //        for (int i = 0; i < this.Uc2.MapHeight; i++)
        //        {
        //            for (int j = 0; j < this.Uc2.MapWidth; j++)
        //            {
        //                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
        //                {
        //                    CellUserControl uc1 = new CellUserControl();
        //                    uc1.X = i;
        //                    uc1.Y = j;
                            
        //                    Grid.SetColumn(uc1, i);
        //                    Grid.SetRow(uc1, j);

        //                    this.gameGrid.Children.Add(uc1);
        //                }));
        //            }
        //        }
        //    });
        //}
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
