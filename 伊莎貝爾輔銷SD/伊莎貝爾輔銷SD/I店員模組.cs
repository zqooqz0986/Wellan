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
        /// 店員登入身分驗證，含支援分店
        /// </summary>
        /// <param name="編號">員工編號</param>
        /// <param name="密碼">員工密碼</param>
        /// <param name="服務地點">服務分店</param>
        /// <returns>身分驗證結果</returns>
        身份認證 登入(string 編號, string 密碼, string 服務地點);
		
		/// <summary>
        /// 查詢該分店所有店員(排除停用)，包含支援的店員
        /// </summary>
        /// <param name="分店編號">分店編號</param>       
        /// <returns>店員's</returns>
        // TODO : 離線
		// IEnumerable<店員> 查詢店員(params string[] 分店編號);
		
        /// <summary>
        /// 刪除該店所有店員
        /// </summary>
        /// <param name="分店編號">分店</param>
        // TODO : 離線 
        // void 刪除店員(params string[] 分店編號);

		/// <summary>
        /// 新增店員		
        /// </summary>
        /// <param name="店員">店員</param>    
        // TODO : 離線
        // void 新增店員(params 店員[] 店員);
    }
}
