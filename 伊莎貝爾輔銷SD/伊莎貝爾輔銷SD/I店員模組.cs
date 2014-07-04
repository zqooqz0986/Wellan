using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I店員模組
    {
        /// <summary>
        /// 店員登入身分驗證
        /// </summary>
        /// <param name="id">店員帳號</param>
        /// <param name="password">店員密碼</param>
        /// <returns>身分驗證結果</returns>
        身份認證 登入(string id, string password);
		
		/// <summary>
        /// 查詢該分店所有店員(排除停用)，包含支援的店員
        /// </summary>
        /// <param name="分店編號">分店編號</param>       
        /// <returns>店員's</returns>
		IEnumerable<店員> 查詢店員(params string[] 分店編號);
		
		/// <summary>
        /// 新增店員		
        /// </summary>
        /// <param name="店員">店員</param>             
		void 新增店員(IEnumerable<店員> 店員);
    }
}
