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
    public class APIWrapper
    {
        private AxKHOpenAPI api;

        public delegate void OnEventConnectDelegate(object sender, ResultCode resultCode);
        public event OnEventConnectDelegate OnEventConnect;

        public delegate void OnReceiveTrDataDelegate(object sender, OnReceiveTrData e);
        public event OnReceiveTrDataDelegate OnReceiveTrData;

        public APIWrapper()
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

        public string GetStockNameByCode(string stockCode)
        {
            return api.GetMasterCodeName(stockCode);
        }

        public string GetStockCodeListByMarket(Market market)
        {
            return api.GetCodeListByMarket(((int)market).ToString());
        }

        public string GetCommData(string rqName, Enum @enum)
        {
            return api.GetCommData(@enum.GetType().Name, rqName, 0, @enum.GetDescription());
        }

        private void Api_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            OnReceiveTrData?.Invoke(sender, new OnReceiveTrData 
            { 
                nDataLength = e.nDataLength,
                sErrorCode = e.sErrorCode,
                sMessage = e.sMessage,
                sPrevNext = e.sPrevNext,
                sRecordName = e.sRecordName,
                sRQName = e.sRQName,
                sScrNo = e.sScrNo,
                sSplmMsg = e.sSplmMsg,
                sTrCode = e.sTrCode
            });
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
            OnEventConnect?.Invoke(sender, (ResultCode)e.nErrCode);
        }
    }
}
