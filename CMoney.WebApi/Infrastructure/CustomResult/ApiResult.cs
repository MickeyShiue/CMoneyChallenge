namespace CMoney.WebApi.Infrastructure.CustomResult
{
    /// <summary>
    /// WebApi回覆前端呼叫時，乘載回傳資訊的類別
    /// </summary>
    public class ApiResult : ApiResult<object>
    {

    }

    /// <summary>
    /// WebApi回覆前端呼叫時，乘載回傳資訊的類別
    /// </summary>
    public class ApiResult<T> where T : new()
    {
        /// <summary>
        /// 回傳的結果
        /// </summary>
        public ApiResultCode Code { get; set; }
        /// <summary>
        /// 回傳資料主體
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 回傳的訊息
        /// </summary>
        public string Message { get; set; }
        
        public ApiResult()
        {
            Code = ApiResultCode.Success;
            Data = default(T);
            Message = string.Empty;
        }
    }

    /// <summary>
    /// 參照 HTTP Stats Code 為主，如果有需要客制，請於 600 後開始擴充
    /// </summary>
    public enum ApiResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,

        /// <summary>
        /// 已新增
        /// </summary>
        Created = 201,

        /// <summary>
        /// 無法理解請求
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// 未驗證
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// 未授權
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// 找不到資源
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// 伺服器端發生未知或無法處理的錯誤，程式爆錯
        /// </summary>
        InternalServerError = 500
    }
}
