# Take Home Engineering Challenge
題目連結[點擊這裡](http://joinme.cmoney.com.tw:10080/interview/take-home-engineering-challenge)

## 專案架構
* CMoney.DataAccess.Lib 資料處理層

* CMoney.Service.Lib 商業邏輯層

* CMoney.Service.Lib.Test 單元測試

* CMoney.WebApi Api 專案

## API 使用範例

* **api/TaiwanStockExchange/ImportDataByDate (依據指定日期匯入資料)**

```
curl -X POST \
  https://{Domain}/api/TaiwanStockExchange/ImportDataByDate \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -d '{
	"Date":"2020-12-25"
}'

Request
{
  "Date":"2020-12-05"
}

Response
{
  "code": 201,
  "data": null,
  "message": "資料匯入成功"
}
```

* **api/TaiwanStockExchange/GetDataBySecuritiesCode (依照證券代號 搜尋最近 n 天的資料)**

```
curl -X POST \
  https://{Domain}/api/TaiwanStockExchange/GetDataBySecuritiesCode \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -d '{
	"code":"1447",
	"days":2
}'

Request
{
  "code":"1447",
  "days":2
}

Response
{
  "code": 200,
  "data": [
    {
      "code": "1447",
      "name": "力鵬",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": null,
      "priceRatio": 0.82,
      "financialYear": "109/3",
      "date": "2020-12-24T00:00:00"
    },
    {
      "code": "1447",
      "name": "力鵬",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": null,
      "priceRatio": 0.84,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    }
  ],
  "message": "查詢成功"
}
```

* **api/TaiwanStockExchange/GetDataByPeRatio (指定特定日期 顯示當天本益比前 n 名)**

```
curl -X POST \
  https://{Domain}/api/TaiwanStockExchange/GetDataByPeRatio \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -d '{
	"Date":"2020-12-25",
	"TopN":10
}'

Request
{
  "Date":"2020-12-25",
  "TopN":10
}

Response
{
  "code": 200,
  "data": [
    {
      "code": "2009",
      "name": "第一銅",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": 860,
      "priceRatio": 2.55,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "2906",
      "name": "高林",
      "yieldRate": 1.95,
      "dividendYear": 108,
      "peratio": 770,
      "priceRatio": 1.14,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "5907",
      "name": "大洋-KY",
      "yieldRate": 10.4,
      "dividendYear": 108,
      "peratio": 528.75,
      "priceRatio": 0.51,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "2302",
      "name": "麗正",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": 490,
      "priceRatio": 2.48,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "6133",
      "name": "金橋",
      "yieldRate": 2.73,
      "dividendYear": 108,
      "peratio": 458,
      "priceRatio": 0.77,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "2024",
      "name": "志聯",
      "yieldRate": 2.25,
      "dividendYear": 108,
      "peratio": 388.75,
      "priceRatio": 1.36,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "8011",
      "name": "台通",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": 386.67,
      "priceRatio": 1.05,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "1446",
      "name": "宏和",
      "yieldRate": 0.99,
      "dividendYear": 108,
      "peratio": 379.38,
      "priceRatio": 2.77,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "1464",
      "name": "得力",
      "yieldRate": 8.06,
      "dividendYear": 108,
      "peratio": 372,
      "priceRatio": 1.49,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    },
    {
      "code": "4540",
      "name": "全球傳動",
      "yieldRate": 0,
      "dividendYear": 108,
      "peratio": 370.67,
      "priceRatio": 1.74,
      "financialYear": "109/3",
      "date": "2020-12-25T00:00:00"
    }
  ],
  "message": "查詢成功"
}
```

* **api/TaiwanStockExchange/GetDataByYieldRate (指定日期範圍、證券代號 顯示這段時間內殖利率 為嚴格遞增的最長天數並顯示開始、結束日期)**

```
curl -X POST \
  https://{Domain}:44343/api/TaiwanStockExchange/GetDataByYieldRate \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -d '{
	"SecuritiesCode":"2330",
	"StartDate":"2020-12-15",
	"EndDate":"2020-12-25"
}'

Request
{
  "SecuritiesCode": "2330",
  "StartDate": "2020-12-15",
  "EndDate": "2020-12-25"
}

Response
{
  "code": 200,
  "data": {
    "securitiesCode": "2330",
    "startDay": "2020-12-16T00:00:00",
    "endDay": "2020-12-17T00:00:00",
    "continueDays": 2
  },
  "message": "查詢成功"
}
```

## 總結

* 缺失的部分
  * 嚴格遞增的演算法不是我自己寫的，是抄別人的，至於一開始看到題目不理解所謂的嚴格遞增是什麼，所以跑去看了[影片](https://www.youtube.com/watch?v=wnSECgAZ-x0)了解大概的意思。
  * Api 專案有使用 Nswag，但由於使用了 Api Response Patten，其中的 Data 採用泛型，所以導致 Nswag 無法完美反射出所謂的強行別 model，導致 Nswag 不夠詳細完整，當然硬要的話，也是可以把 swagger.Json copy 出來之後手動編修後，再到 [Swagger Editor](https://editor.swagger.io/) 產生程式碼範例，以便後續加速開發。
  * 版控部分並沒有特別走 branch 亦或是 GitFlow，Commit 的部分也沒有特別使用 commit template 來撰寫，所以未來要翻紀錄可能比較辛苦一點。
  * 沒有特別去裝 StyleCop。
  
* 設計技巧
  * 採用基本的三層式架構
  * 使用 DotNet Core 基本 DI
  * 針對 HttpClinet 使用 HttpClientFactory 避免 HttpClinet 散落在各地
  * 匯入資料的部分，想了一下，最後還是做成 api 接口，就不用讓 user 下載 csv 然後再匯入，直接去爬回來塞進 db 比較快，如果未來要做成 Console 類型的 Job 也只需要呼叫 Service 層即可
  
* 心得
> 題目有挑戰性，也算是強迫自己回頭複習以前學過的技術，雖然有去上過課，但工作上很少用其實很快就會忘記，這次幫我複習了 EF Code First mapping、DotNet Core、單元測試，總之很開心能夠接受這個挑戰。
