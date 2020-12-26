using System;
using System.ComponentModel.DataAnnotations;

namespace CMoney.Service.Lib.DTO.ApiRequestDTO
{
    /// <summary>
    /// 指定日期範圍、證券代號 顯示這段時間內殖利率 為嚴格遞增的最長天數並顯示開始、結束日期 Request
    /// </summary>
    public class GetDataByYieldRateRequest
    {
        /// <summary>
        /// 證券代號
        /// </summary>
        [Required]
        public string SecuritiesCode { get; set; }

        /// <summary>
        /// 起始日
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 結束日
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
    }
}
