﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwoomController.Models
{
    public enum ResultCode
    {
        정상처리 = 0,
        실패 = -10,
        조건번호_없음 = -11,
        조건번호와_조건식_불일치 = -12,
        조건검색_조회요청_초과 = -13,
        사용자정보교환_실패 = -100,
        서버_접속_실패 = -101,
        버전처리_실패 = -102,
        개인방화벽_실패 = -103,
        메모리_보호실패 = -104,
        함수입력값_오류 = -105,
        통신연결_종료 = -106,
        보안모듈_오류 = -107,
        공인인증_로그인_필요 = -108,
            
        시세조회_과부하 = -200,
        전문작성_초기화_실패 = -201,
        전문작성_입력값_오류 = -202,
        데이터_없음 = -203,
        조회가능한_종목수_초과_한번에_조회_가능한_종목개수는_최대_100종목 = -204,
        데이터_수신_실패 = -205,
        조회가능한_FID수_초과_한번에_조회_가능한_FID개수는_최대_100개 = -206,
        실시간_해제오류 = -207,
        시세조회제한 = -209,

        입력값_오류 = -300,
        계좌비밀번호_없음 = -301,
        타인계좌_사용오류 = -302,
        주문가격이_주문착오_금액기준_초과1 = -303,
        주문가격이_주문착오_금액기준_초과2 = -304,
        주문수량이_총발행주수의_1pro_초과오류 = -305,
        주문수량은_총발행주수의_3pro_초과오류 = -306,
        주문전송_실패 = -307,
        주문전송_과부하 = -308,
        주문수량_300계약_초과 = -309,
        주문수량_500계약_초과 = -310,
        주문전송제한_과부하 = -311,
        계좌정보_없음 = -340,
        종목코드_없음 = -350
       
    }
}
