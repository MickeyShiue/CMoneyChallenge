using System;
using System.ComponentModel.DataAnnotations;

namespace CMoney.Service.Lib.DTO.ApiRequestDTO
{
    /// <summary>
    /// 依照證券代號 搜尋最近 n 天的資料 Request
    /// </summary>
    public class GetDataBySecuritiesCodeRequest : ICustomValidator
    {
        /// <summary>
        /// 證券代號
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// 指定日期 n 天
        /// </summary>
        [Required]
        public int Days { get; set; }

        public bool CustomValidator()
        {
            if (this.Days == 0 || this.Days < 0)
                throw new Exception("連續日期不能等於0或是小於0");

            return true;
        }
    }
}
