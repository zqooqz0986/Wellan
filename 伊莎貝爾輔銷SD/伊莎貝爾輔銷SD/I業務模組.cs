﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I業務模組
    {
        /// <summary>
        /// 查詢顧客(洽談記錄.進度日期在時間範圍內的來客資訊)
        /// </summary>
        /// <param name="名字">顧客名字</param>
        /// <param name="範圍">時間範圍</param>
        /// <returns>顧客's</returns>
        IEnumerable<顧客> 查詢顧客(string 名字, DateTime 範圍);

        /// <summary>
        /// 更新購物車
        /// </summary>
        /// <param name="購物車清單">愈更新購物車清單</param>        
        void 更新購物車(params 興趣商品[] 購物車清單);

        /// <summary>
        /// 新增洽談紀錄
        /// </summary>
        /// <param name="紀錄">洽談紀錄</param>
        void 新增洽談紀錄(params 洽談紀錄[] 紀錄);

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="訂單">訂單資訊</param>
        void 新增訂單(params 主單[] 訂單);
    }
}
