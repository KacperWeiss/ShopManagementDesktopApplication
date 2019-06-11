using ShopAccessApp.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ShopAccessApp.UserControlers.Tabs
{
    /// <summary>
    /// Interaction logic for ProductTab.xaml
    /// </summary>
    public partial class ProductTab : UserControl, INotifyPropertyChanged
    {
        Button previousButton;

        public ProductTab()
        {
            InitializeComponent();
            DataContext = this; 
        }

        private List<motherboards> motherboardList = MotherBoardsAcessor.GetAll();
        private List<processors> processorList = ProcessorsAccessor.GetAll();
        private List<graphics_cards> graphicsCardList = GraphicsCardsAccessor.GetAll();
        private List<ram_memories> ramMemoryList = RamMemoriesAccessor.GetAll();
        private List<cases> caseList = CasesAccessor.GetAll();
        private List<services> serviceList = ServicesAccessor.GetAll();

        public List<motherboards> MotherboardList
        {
            get
            {
                return motherboardList;
            }
            set
            {
                if (motherboardList != value)
                {
                    motherboardList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<processors> ProcessorList
        {
            get
            {
                return processorList;
            }
            set
            {
                if (processorList != value)
                {
                    processorList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<graphics_cards> GraphicsCardList
        {
            get
            {
                return graphicsCardList;
            }
            set
            {
                if (graphicsCardList != value)
                {
                    graphicsCardList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<ram_memories> RamMemoryList
        {
            get
            {
                return ramMemoryList;
            }
            set
            {
                if (ramMemoryList != value)
                {
                    ramMemoryList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<cases> CaseList
        {
            get
            {
                return caseList;
            }
            set
            {
                if (caseList != value)
                {
                    caseList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<services> ServiceList
        {
            get
            {
                return serviceList;
            }
            set
            {
                if (serviceList != value)
                {
                    serviceList = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonTab_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab_Click(object sender, RoutedEventArgs e)
        {
            var currentButton = (Button)e.Source;
            int index = int.Parse(currentButton.Uid);
            TabPointer.Margin = new Thickness(10 + (index * 170),0,0,0);
            currentButton.Background = Brushes.White;

            if (previousButton != null && previousButton != currentButton)
            {
                previousButton.Background = null;
            }
            previousButton = (Button)e.Source;

            switch (index)
            {
                case 0:
                    MotherboardListView.Visibility = Visibility.Visible;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 1:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Visible;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 2:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Visible;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 3:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Visible;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 4:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Visible;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 5:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Visible;
                    OrderTab.Visibility = Visibility.Collapsed;
                    ProductScrollViewer.Visibility = Visibility.Visible;
                    break;

                case 6:
                    MotherboardListView.Visibility = Visibility.Collapsed;
                    ProcessorListView.Visibility = Visibility.Collapsed;
                    GraphicsCardListView.Visibility = Visibility.Collapsed;
                    RamMemoryListView.Visibility = Visibility.Collapsed;
                    CaseListView.Visibility = Visibility.Collapsed;
                    ServiceListView.Visibility = Visibility.Collapsed;
                    OrderTab.Visibility = Visibility.Visible;
                    ProductScrollViewer.Visibility = Visibility.Collapsed;
                    break;

                default:
                    break;
            }
        }

        private void ProductScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 2);
            e.Handled = true;
        }
    }
}
