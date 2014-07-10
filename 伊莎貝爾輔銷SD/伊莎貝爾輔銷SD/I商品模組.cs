using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public interface I商品模組
    {
		/// <summary>
        /// 查詢區間內要維護的商品資訊
        /// </summary>         
		/// <param name="區間">時間區間</param>		
        /// <returns>維護商品's</returns>
		IEnumerable<商品> 查詢維護商品(TimeSpan 區間);
		
		/// <summary>
        /// 更新商品
        /// </summary>     
		/// <param name="商品">要更新的商品</param>		
        /// <returns>商品's</returns>
		IEnumerable<商品> 更新商品(params 商品[] 商品);
		
        /// <summary>
        /// 查詢商品
        /// </summary>        
        /// <param name="品牌編號">限定品牌</param>
        /// <returns>商品's</returns>
        IEnumerable<商品> 查詢商品(params string[] 品牌編號);

        /// <summary>
        /// 查詢新的商品(最新旗標=true)
        /// </summary>        
        /// <param name="品牌編號">限定品牌</param>
        /// <returns>商品's</returns>
        IEnumerable<商品> 查詢新商品(params string[] 品牌編號);

        /// <summary>
        /// 查詢商品排行榜(排行旗標=true)
        /// </summary>
        /// <param name="品牌編號">限定品牌</param>
        /// <returns>商品排行榜</returns>       
        IEnumerable<商品> 查詢排行榜(string 品牌編號);       
    }
}
