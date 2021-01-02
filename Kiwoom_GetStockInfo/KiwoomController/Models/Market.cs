using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwoomController.Models
{
    /// <summary>
    /// 시장 구분을 위한 enum이다.
    /// API문서 (https://www3.kiwoom.com/nkw.templateFrameSet.do?m=m1408010600) 를 참고하였다.
    /// sMarket – 0:장내, 3:ELW, 4:뮤추얼펀드, 5:신주인수권, 6:리츠,8:ETF, 9:하이일드펀드, 10:코스닥, 30:제3시장
    /// </summary>
    public enum Market
    {
        // 장내
        Kospi = 0,

        // ELW
        Elw = 3,
        
        // 뮤추얼펀드
        MutualFund = 4,
        
        // 리츠
        Reits = 6,

        // ETF
        ETF = 8,

        // 하이일드펀드
        HighYieldFund = 9,
        
        // 코스닥
        Kosdaq = 10

    }
}
