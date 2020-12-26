using System;
using System.ComponentModel.DataAnnotations;

namespace CMoney.Service.Lib.DTO.ApiRequestDTO
{
    /// <summary>
    /// 指定特定日期 顯示當天本益比前 N 名 request
    /// </summary>
    public class GetDataByPeRatioRequest : ICustomValidator
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

        public bool CustomValidator()
        {
            if (this.Date > DateTime.Today)
                throw new Exception("特定日期不能是未來日期");

            if (TopN == 0 || TopN < 0)
                throw new Exception("排名不能是 0 或是負數");

            return true;
        }
    }
}
