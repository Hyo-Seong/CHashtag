using AxKHOpenAPILib;
using KiwoomController.Models;
using KiwoomController.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiwoomController
{
    public class KiwoomController
    {
        private AxKHOpenAPI api;

        public delegate void OnEventConnectDelegate(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e);
        public event OnEventConnectDelegate OnEventConnect;

        public delegate void OnReceiveTrDataDelegate(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e);
        public event OnReceiveTrDataDelegate OnReceiveTrData;

        public KiwoomController()
        {
            api = new Form1().GetAPI();

            ConnectEvent();
        }

        private void ConnectEvent()
        {
            api.OnEventConnect += Api_OnEventConnect;
            api.OnReceiveChejanData += Api_OnReceiveChejanData;
            api.OnReceiveConditionVer += Api_OnReceiveConditionVer;
            api.OnReceiveInvestRealData += Api_OnReceiveInvestRealData;
            api.OnReceiveMsg += Api_OnReceiveMsg;
            api.OnReceiveRealCondition += Api_OnReceiveRealCondition;
            api.OnReceiveRealData += Api_OnReceiveRealData;
            api.OnReceiveTrCondition += Api_OnReceiveTrCondition;
            api.OnReceiveTrData += Api_OnReceiveTrData;
        }

        public int Connect()
        {
            return api.CommConnect();
        }

        public string GetMarketByMarket(Market market)
        {
            return api.GetCodeListByMarket(((int)market).ToString());
        }

        public string GetCommData(string rqName, Enum @enum)
        {
            return api.GetCommData(@enum.GetType().Name, rqName, 0, @enum.GetDescription());
        }

        private void Api_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            OnReceiveTrData?.Invoke(sender, e);
        }

        private void Api_OnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
        }

        private void Api_OnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            // here to code.
        }

        private void Api_OnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
        }

        private void Api_OnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
        }

        private void Api_OnReceiveInvestRealData(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e)
        {
        }

        private void Api_OnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
        }

        private void Api_OnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
        }

        private void Api_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            OnEventConnect?.Invoke(sender, e);
        }
    }
}
