using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwoomController.Models
{
    public class Stock : BindableBase
    {
        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private Market _market;
        public Market Market
        {
            get => _market;
            set => SetProperty(ref _market, value);
        }

        private long _volume;
        public long Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        private int _presentPrice;
        public int PresentPrice
        {
            get => _presentPrice;
            set => SetProperty(ref _presentPrice, value);
        }


        private int _openPrice;
        public int OpenPrice
        {
            get => _openPrice;
            set => SetProperty(ref _openPrice, value);
        }

        private int _closePrice;
        public int ClosePrice
        {
            get => _closePrice;
            set => SetProperty(ref _closePrice, value);
        }

        private int _highPrice;
        public int HighPrice
        {
            get => _highPrice;
            set => SetProperty(ref _highPrice, value);
        }

        private int _lowPrice;
        public int LowPrice
        {
            get => _lowPrice;
            set => SetProperty(ref _lowPrice, value);
        }
    }
}
