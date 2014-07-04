using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I分店模組
    {
        /// <summary>
        /// 查詢所有分店
        /// </summary>        
        /// <returns>商品's</returns>
        IEnumerable<分店> 查詢分店();
    }
}
