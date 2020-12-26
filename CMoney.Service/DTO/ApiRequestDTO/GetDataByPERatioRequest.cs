using System;
using System.ComponentModel.DataAnnotations;

namespace CMoney.Service.Lib.DTO.ApiRequestDTO
{
    /// <summary>
    /// 指定特定日期 顯示當天本益比前 N 名 request
    /// </summary>
    public class GetDataByPeRatioRequest
    {
        /// <summary>
        /// 特定日期
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// 前幾名
        /// </summary>
        [Required]
        public int TopN { get; set; }
    }
}
