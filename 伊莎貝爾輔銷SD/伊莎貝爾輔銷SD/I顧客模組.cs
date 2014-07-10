using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I顧客模組
    {
        /// <summary>
        /// 查詢顧客
        /// </summary>
        /// <param name="名字">顧客名字</param>
        /// <param name="市話">顧客市話</param>
        /// <param name="手機">顧客手機</param>
        /// <returns>顧客's</returns>
        IEnumerable<顧客> 查詢顧客(string 名字, string 市話, string 手機);

        /// <summary>
        /// 更新顧客資訊(if 編號 is Empty 新增 else 更正), 範圍: 顧客資料, 業務往來
        /// </summary>
        /// <param name="顧客">顧客資料</param>
        void 更新顧客(顧客 顧客);
    }
}
