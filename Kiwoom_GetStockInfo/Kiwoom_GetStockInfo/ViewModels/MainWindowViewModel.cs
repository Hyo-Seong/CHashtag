using KiwoomController;
using KiwoomController.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiwoom_GetStockInfo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private APIWrapper api;

        private ObservableCollection<Stock> _stockList = new ObservableCollection<Stock>();
        public ObservableCollection<Stock> StockList
        {
            get => _stockList;
            set => SetProperty(ref _stockList, value);
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

        public MainWindowViewModel()
        {
            api = new APIWrapper();

            AddEvent();

            api.Connect();
        }

        private void AddEvent()
        {
            api.OnEventConnect += Api_OnEventConnect;
            api.OnReceiveTrData += Api_OnReceiveTrData;
        }

        private void Api_OnReceiveTrData(object sender, OnReceiveTrData e)
        {

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
            string result = api.GetStockCodeListByMarket(Market.Kospi);
            string[] stockCodeArray = result.Split(';');
            foreach(string code in stockCodeArray)
            {
                string stockName = api.GetStockNameByCode(code);
                StockList.Add(new Stock
                {
                    Code = code,
                    Name = stockName,
                });
            }
        }
    }
}
