using System.Collections.Generic;
using System.Threading.Tasks;
using CMoney.DataAccess.Lib.Models;
using CMoney.Service.Lib.DTO.ApiRequestDTO;

namespace CMoney.Service.Lib.CrawlServices
{
    /// <summary>
    /// 爬資料 Service
    /// </summary>
    public interface ICrawlService
    {
        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
         Task<IEnumerable<SingleStock>> GetData(ImportDataByDateRequest request);
    }
}
