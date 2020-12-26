using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMoney.DataAccess.Lib.UnitOfWork;
using CMoney.Service.Lib.CrawlServices;
using CMoney.Service.Lib.DTO.ApiRequestDTO;
using CMoney.Service.Lib.SingleStockServices;
using CMoney.WebApi.Infrastructure.CustomResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMoney.WebApi.Controllers
{
    /// <summary>
    /// 臺灣證券交易所 Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaiwanStockExchangeController : ControllerBase
    {
        private readonly ICrawlService _crawlService;
        private readonly ISingleStockService _singleStockService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TaiwanStockExchangeController> _logger;

        /// <summary>
        /// 建構式
        /// </summary>
        public TaiwanStockExchangeController(ICrawlService crawlService,
            ISingleStockService singleStockService,
            IUnitOfWork unitOfWork,
            ILogger<TaiwanStockExchangeController> logger)
        {
            _crawlService = crawlService;
            _singleStockService = singleStockService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 匯入資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ImportDataByDate")]
        public async Task<ApiResult> ImportDataByDate(ImportDataByDateRequest request)
        {
            var apiResult = new ApiResult();
            if (!ModelState.IsValid || !request.Validator())
            {
                apiResult.Code = ApiResultCode.BadRequest;
                apiResult.Message = "日期格式有誤，請確認";
                return apiResult;
            }

            try
            {
                if (_singleStockService.IsExist(request))
                {
                    apiResult.Code = ApiResultCode.Success;
                    apiResult.Message = "今日資料已存在，無須匯入";
                    return apiResult;
                }

                var data = await _crawlService.GetData(request);
                _singleStockService.Create(data);
                _unitOfWork.SaveChange();
            }
            catch (Exception exception)
            {
                apiResult.Code = ApiResultCode.InternalServerError;
                apiResult.Message = "服務異常";
                _logger.LogError(exception, exception.Message);
                return apiResult;
            }

            apiResult.Code = ApiResultCode.Created;
            apiResult.Message = "資料匯入成功";
            return apiResult;
        }
    }
}
