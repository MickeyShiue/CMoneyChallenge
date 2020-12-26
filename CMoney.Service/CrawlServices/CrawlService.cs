using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CMoney.DataAccess.Lib.Models;
using CMoney.Service.Lib.DTO.ApiRequestDTO;
using CMoney.Service.Lib.Extension;

namespace CMoney.Service.Lib.CrawlServices
{
    public class CrawlService : ICrawlService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CrawlService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// 取得來自臺灣證券交易所的資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SingleStock>> GetData(ImportDataByDateRequest request)
        {
            var cline = _clientFactory.CreateClient();
            var uri = $"https://www.twse.com.tw/exchangeReport/BWIBBU_d?response=csv&date={request.Date.ToShortDate()}selectType=ALL";
            var response = await cline.GetAsync(uri);
            var contentType = response.Content.Headers.ContentType;
            contentType.CharSet = "BIG5";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var responseBody = await response.Content.ReadAsStringAsync();

            var result = this.ConvertData(responseBody, request.Date);
            return result;
        }

        /// <summary>
        /// 解析從臺灣證券交易所爬回來的csv字串，並轉回 db model
        /// </summary>
        /// <param name="responseBody"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private IEnumerable<SingleStock> ConvertData(string responseBody, DateTime date)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            var responseBodySplitResult = responseBody.Split(stringSeparators, StringSplitOptions.None);

            List<SingleStock> result = new List<SingleStock>();
            foreach (var target in responseBodySplitResult.Skip(2))
            {
                string[] rowData = target.CustomSplit();
                if (!int.TryParse(rowData[0], out var code)) break;
                result.Add(GetSingleStock(rowData, date));
            }

            return result;
        }

        private SingleStock GetSingleStock(string[] rowData, DateTime date)
        {
            var singleStock = new SingleStock
            {
                Id = Guid.NewGuid(),
                SecuritiesCode = rowData[0],
                SecuritiesName = rowData[1],
                YieldRate = Convert.ToDecimal(rowData[2]),
                DividendYear = Convert.ToInt16(rowData[3]),
                Peratio = Decimal.TryParse(rowData[4], out var peratio) ? peratio : default(decimal?),
                PriceRatio = Convert.ToDecimal(rowData[5]),
                FinancialYear = rowData[6],
                ByDate = date.Date
            };

            return singleStock;
        }
    }
}
