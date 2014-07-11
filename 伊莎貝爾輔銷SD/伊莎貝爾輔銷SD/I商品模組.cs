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
        /// 查詢區間內要維護的商品資訊[含區間停用的商品] 
        /// (if 區間==null 查詢所有[非停用]資料)
        /// 停用: 下架日期[BSDT5], 停用日期[BSDT6]
        /// 修改時間: 修改日[EDDAT]       
        /// </summary>         
		/// <param name="區間">時間區間</param>		
        /// <returns>維護商品's</returns>        
		IEnumerable<商品> 查詢維護商品(TimeSpan 區間);
        // TODO : 志冠 共同平台程式,將此資訊填回EDDAT
        // TODO : 士雅 商品圖檔需request圖檔站台，1. 由pad request 2. 由API request

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
