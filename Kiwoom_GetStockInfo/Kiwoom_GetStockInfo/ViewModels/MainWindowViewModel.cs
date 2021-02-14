using KiwoomController;
using KiwoomController.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kiwoom_GetStockInfo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Properties

        private APIWrapper api;

        private ObservableCollection<Stock> _stockList = new ObservableCollection<Stock>();
        public ObservableCollection<Stock> StockList
        {
            get => _stockList;
            set => SetProperty(ref _stockList, value);
        }

        private ObservableCollection<Market> _marketFilter = new ObservableCollection<Market>();
        public ObservableCollection<Market> MarketFilter
        {
            get => _marketFilter;
            set => SetProperty(ref _marketFilter, value);
        }

        private DateTime _currentTime;
        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        private bool _apiConnected;
        public bool ApiConnected
        {
            get => _apiConnected;
            set => SetProperty(ref _apiConnected, value);
        }

        private string _filter;
        public string Filter
        {
            get => _filter;
            set
            {
                SetProperty(ref _filter, value);
                OnFilterChanged();
            }
        }

        private Market _selectedMarket;
        public Market SelectedMarket
        {
            get => _selectedMarket;
            set => SetProperty(ref _selectedMarket, value);
        }

        #endregion

        #region Commands

        public DelegateCommand MarketFilterSelectedItemChangedCommand { get; private set; }

        #endregion

        private CollectionViewSource StockCollectionViewSource { get; set; }

        public ICollectionView StockCollection
        {
            get { return StockCollectionViewSource.View; }
        }

        private void OnFilterChanged()
        {
            StockCollectionViewSource.View.Refresh();
        }


        public MainWindowViewModel()
        {
            Init();
        }

        private void Init()
        {
            InitFilter();

            InitAPI();
        }

        private void InitFilter()
        {
            StockList = new ObservableCollection<Stock>();

            StockCollectionViewSource = new CollectionViewSource();
            StockCollectionViewSource.Source = this.StockList;
            StockCollectionViewSource.Filter += ApplyStockFilter;

            MarketFilterSelectedItemChangedCommand = new DelegateCommand(MarketFilterSelectedItemChangedCommandMethod);
        }

        private void MarketFilterSelectedItemChangedCommandMethod()
        {
            OnFilterChanged();
        }

        private void InitAPI()
        {
            api = new APIWrapper();

            RegisterAPIEvents();

            foreach (Market market in ((Market[])Enum.GetValues(typeof(Market))).OrderBy(x => x))
            {
                MarketFilter.Add(market);
            }

            api.Connect();
        }

        private void RegisterAPIEvents()
        {
            api.OnEventConnect += Api_OnEventConnect;
            api.OnReceiveTrData += Api_OnReceiveTrData;
        }

        private void Api_OnReceiveTrData(object sender, OnReceiveTrData e)
        {
            //Stock stock = StockList.FirstOrDefault(x => x.Code == e.sRQName);
            //if(stock != null)
            //{
            //    string name = api.GetCommData(e.sRQName, OPT10001.종목명).Trim();

                    
            //    stock.Name = api.GetCommData(e.sRQName, OPT10001.종목명).Trim();
            //    stock.Volume = long.Parse(api.GetCommData(e.sRQName, OPT10001.거래량).Trim());
            //    stock.LowPrice = long.Parse(api.GetCommData(e.sRQName, OPT10001.저가).Trim());
            //    stock.HighPrice = long.Parse(api.GetCommData(e.sRQName, OPT10001.고가).Trim());
            //    stock.OpenPrice = long.Parse(api.GetCommData(e.sRQName, OPT10001.시가).Trim());
            //    stock.PresentPrice = long.Parse(api.GetCommData(e.sRQName, OPT10001.현재가).Trim());
            //    stock.UpDownRatio = double.Parse(api.GetCommData(e.sRQName, OPT10001.등락률).Trim());
            //}
        }

        private void Api_OnEventConnect(object sender, ResultCode resultCode)
        {
            if(resultCode == ResultCode.정상처리)
            {
                GetStockList();
            }
            else
            {
                // Error
            }
        }

        private void GetStockList()
        {
            foreach(var market in MarketFilter)
            {
                // All 은 키움에서 제공하는 것이 아닌 내가 만든 것이므로 요청 보내지 않는다.
                if(market == Market.All)
                {
                    continue;
                }

                string result = api.GetStockCodeListByMarket(market);
                string[] stockCodeArray = result.Split(';');

                foreach(string code in stockCodeArray)
                {
                    StockList.Add(new Stock
                    {
                        Name = api.GetStockNameByCode(code),
                        Code = code,
                        Market = market
                    });
                }
            }
        }
        void ApplyStockFilter(object sender, FilterEventArgs e)
        {
            Stock stock = (Stock)e.Item;


            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = stock.Name.ToLower().Contains(Filter.ToLower());
            }

            if(SelectedMarket != Market.All && SelectedMarket != stock.Market)
            {
                e.Accepted = false;
            }
        }
    }
}
