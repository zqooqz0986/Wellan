using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface ICodeType
    {
        /// <summary>
        /// 查詢所有類別代碼
        /// </summary>              
        /// <returns>類別代碼's</returns>    
        IEnumerable<CodeType> 查詢類別代碼();
		
		/// <summary>
        /// 更新所有類別代碼(if exist 更正 else 新增)
        /// </summary>              
        /// <param name="類別代碼">類別代碼</param> 
		void 更新類別代碼(params CodeType[] 類別代碼);
	}
}