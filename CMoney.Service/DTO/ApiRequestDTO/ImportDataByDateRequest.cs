using System;
using System.ComponentModel.DataAnnotations;

namespace CMoney.Service.Lib.DTO.ApiRequestDTO
{
    /// <summary>
    /// 匯入資料 Request
    /// </summary>
    public class ImportDataByDateRequest
    {
        /// <summary>
        /// 需要匯入資料的日期
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// 驗證日期不能大於今天
        /// </summary>
        /// <returns></returns>
        public bool CustomValidator()
        {
            if (this.Date.Date > DateTime.Today) return false;
            return true;
        }
    }
}
