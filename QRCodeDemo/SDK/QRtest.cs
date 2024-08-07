using SkiaSharp;
using SkiaSharp.QrCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeDemo.SDK
{
    public static class QRtest
    {
        public static void GenerateQRCode(string test,int width,int height)
        {
            var qrCodeContent = test;
            string  desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, @"二维码.png");
            using (var generator = new QRCodeGenerator())
            {
                // 创建二维码（并设置纠错能力最高级）
                var createQrCode = generator.CreateQrCode(qrCodeContent, ECCLevel.H);

                var skImageInfo = new SKImageInfo(width, height);

                // 创建SkiaSharp画布
                using (var surface = SKSurface.Create(skImageInfo))
                {
                    var canvas = surface.Canvas;

                    // 渲染二维码到画布
                  canvas.Render(createQrCode, skImageInfo.Width, skImageInfo.Height);

                    using (var image = surface.Snapshot())// 获取画布快照
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))// 编码画布快照为PNG格式的数据
                       
                    using (var stream = File.OpenWrite(filePath))
                    {
                      
                      data.SaveTo(stream);// 将数据保存到文件流中，生成二维码图片
                        
                    }
                }
            }
        }
    }
}
