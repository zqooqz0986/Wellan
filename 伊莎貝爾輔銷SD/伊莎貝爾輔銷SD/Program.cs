using System;
using System.Collections.Generic;

namespace 伊莎貝爾輔銷SD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<興趣商品>()
            {
                new 興趣商品() { 編號 = "興趣商品編號1", 商品編號 = "商品編號1" },
                new 興趣商品() { 編號 = "興趣商品編號2", 商品編號 = "商品編號2" },
                new 興趣商品() { 編號 = string.Empty, 商品編號 = "商品編號3" },
                new 興趣商品() { 編號 = null, 商品編號 = "商品編號4" },
            };

            var ml = new ModifiedList<興趣商品>(
                list,
                (collection, entity) => entity.修改 = true,
                (collection, entity) =>
                {
                    if (string.IsNullOrEmpty(entity.編號))
                    {
                        collection.Remove(entity);
                    }
                    else
                    {
                        entity.停用 = true;
                    }
                });
           
            //ml.RemoveAt(1);

            //ml.RemoveAt(2);

            ml[3].訂購 = true;

            //ml.ModifyAt(3);

            ml.ForEach((x) => Console.WriteLine("商品編號:{0}, 停用:{1}, 修改:{2}", x.商品編號, x.停用, x.修改));

            Console.ReadKey();
        }
    }
}