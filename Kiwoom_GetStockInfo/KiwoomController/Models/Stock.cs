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

        private long _presentPrice;
        public long PresentPrice
        {
            get => _presentPrice;
            set => SetProperty(ref _presentPrice, value);
        }

        private double _upDownRatio;
        public double UpDownRatio
        {
            get => _upDownRatio;
            set => SetProperty(ref _upDownRatio, value);
        }

        private long _openPrice;
        public long OpenPrice
        {
            get => _openPrice;
            set => SetProperty(ref _openPrice, value);
        }

        private long _closePrice;
        public long ClosePrice
        {
            get => _closePrice;
            set => SetProperty(ref _closePrice, value);
        }

        private long _highPrice;
        public long HighPrice
        {
            get => _highPrice;
            set => SetProperty(ref _highPrice, value);
        }

        private long _lowPrice;
        public long LowPrice
        {
            get => _lowPrice;
            set => SetProperty(ref _lowPrice, value);
        }
    }
}
