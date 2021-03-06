using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I類別模組
    {
        /// <summary>
        /// 查詢所有要維護的類別代碼
        /// </summary>              
        /// <returns>類別代碼's</returns>    
        IEnumerable<類別代碼> 查詢維護類別代碼();
		
		/// <summary>
        /// 更新所有類別代碼(if exist 更正 else 新增)
        /// </summary>              
        /// <param name="類別代碼">類別代碼</param> 
		void 更新類別代碼(params 類別代碼[] 類別代碼);

        /// <summary>
        /// 查詢類別代碼(排除停用)
        /// </summary>              
        /// <param name="類別">類別型態</param>
        /// <returns>類別代碼's</returns>    
        IEnumerable<類別代碼> 查詢類別代碼(string 類別);		
	}
}