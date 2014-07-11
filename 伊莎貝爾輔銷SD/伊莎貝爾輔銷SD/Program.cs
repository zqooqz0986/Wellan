using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
namespace 伊莎貝爾輔銷SD
{
    public class Program
    {
        private static void Main(string[] args)
        {         
            // Create image.
            //Image newImage = Image.FromFile("Wallpaper_NationalPark800x600.jpg");
            //newImage.
            //// Create Point for upper-left corner of image.
            //Point ulCorner = new Point(100, 100);

            //// Draw image to screen.

            //ZipFile.CreateFromDirectory(startPath, zipPath);

            //ZipFile.ExtractToDirectory(zipPath, extractPath);

        }

        private static void TestModifiedList()
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
                (entity) => entity.修改 = true,
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

            ml.RemoveAt(1);

            //ml.RemoveAt(2);

            ml[3].數量 = 2;
            ml[2].數量 = 2;

            ml.ForEach((x) => Console.WriteLine("商品編號:{0}, 停用:{1}, 修改:{2}", x.商品編號, x.停用, x.修改));

            Console.ReadKey();
        }

    }
}