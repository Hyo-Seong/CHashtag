using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwoomController.Models
{
    /// <summary>
    /// 주식기본정보요청
    /// </summary>
    public enum OPT10001
    {
        [Description("종목코드")]
        종목코드,
        [Description("종목명")]
        종목명,
        [Description("결산월")]
        결산월,
        [Description("액면가")]
        액면가,
        [Description("자본금")]
        자본금,
        [Description("상장주식")]
        상장주식,
        [Description("신용비율")]
        신용비율,
        [Description("연중최고")]
        연중최고,
        [Description("연중최저")]
        연중최저,
        [Description("시가총액")]
        시가총액,
        [Description("시가총액비중")]
        시가총액비중,
        [Description("외인소진률")]
        외인소진률,
        [Description("대용가")]
        대용가,
        [Description("PER")]
        PER,
        [Description("EPS")]
        EPS,
        [Description("ROE")]
        ROE,
        [Description("EV")]
        EV,
        [Description("BPS")]
        BPS,
        [Description("매출액")]
        매출액,
        [Description("영업이익")]
        영업이익,
        [Description("당기순이익")]
        당기순이익,
        [Description("250최고")]
        _250최고,
        [Description("250최저")]
        _250최저,
        [Description("시가")]
        시가,
        [Description("고가")]
        고가,
        [Description("저가")]
        저가,
        [Description("상한가")]
        상한가,
        [Description("하한가")]
        하한가,
        [Description("기준가")]
        기준가,
        [Description("예상체결가")]
        예상체결가,
        [Description("250최고가일")]
        _250최고가일,
        [Description("250최고가대비율")]
        _250최고가대비율,
        [Description("250최저가일")]
        _250최저가일,
        [Description("250최저가대비율")]
        _250최저가대비율,
        [Description("현재가")]
        현재가,
        [Description("대비기호")]
        대비기호,
        [Description("전일대비")]
        전일대비,
        [Description("등락율")]
        등락율,
        [Description("거래량")]
        거래량,
        [Description("거래대비")]
        거래대비,
        [Description("액면가단위")]
        액면가단위,
        [Description("유통주식")]
        유통주식,
        [Description("유통비율")]
        유통비율,
    }
}
