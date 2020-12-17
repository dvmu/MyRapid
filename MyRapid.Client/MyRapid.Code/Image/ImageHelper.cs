/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
namespace MyRapid.Code
{
    public static class ImageHelper
    {
        /// <summary>
        /// 颜色取反
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color Invert(Color color)
        {
            return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
        }
        /// <summary>
        /// 优化Graphics
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Graphics SmoothGraphics(this Graphics g)
        {
            try
            {
                //设置质量
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                //InterpolationMode不能使用High或者HighQualityBicubic,如果是灰色或者部分浅色的图像是会在边缘处出一白色透明的线
                //用HighQualityBilinear却会使图片比其他两种模式模糊（需要肉眼仔细对比才可以看出）
                g.InterpolationMode = InterpolationMode.Default;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                return g;
            }
            catch (Exception)
            {
                return g;
            }
        }
        /// <summary>
        /// 绘制圆形文字图标
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="str"></param>
        /// <param name="font"></param>
        /// <param name="fcolor"></param>
        /// <returns></returns>
        public static Image DrawIcon(int size, Color color, string str, Font font, Color fcolor)
        {
            try
            {
                Image img = new Bitmap(size, size);
                var g = Graphics.FromImage(img);
                g = SmoothGraphics(g);
                g.FillEllipse(new SolidBrush(color), 0, 0, size - 1, size - 1);
                Image smg = DrawString(str, font, fcolor);
                g.DrawImage(smg, (size - smg.Width) / 2, (size - smg.Height) / 2);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 绘制方形文字图标
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="str"></param>
        /// <param name="font"></param>
        /// <param name="fcolor"></param>
        /// <returns></returns>
        public static Image DrawIconRectangle(int size, Color color, string str, Font font, Color fcolor)
        {
            try
            {
                Image img = new Bitmap(size, size);
                var g = Graphics.FromImage(img);
                g = SmoothGraphics(g);
                g.FillRectangle(new SolidBrush(color), 0, 0, size - 1, size - 1);
                Image smg = DrawString(str, font, fcolor);
                g.DrawImage(smg, (size - smg.Width) / 2, (size - smg.Height) / 2);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="font"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Image DrawString(string str, Font font, Color color)
        {
            try
            {
                Image img = new Bitmap(999, 999);
                var g = Graphics.FromImage(img);
                g = SmoothGraphics(g);
                SizeF size = g.MeasureString(str, font);
                img = new Bitmap((int)size.Width, (int)size.Height);
                g = Graphics.FromImage(img);
                g = SmoothGraphics(g);
                g.DrawString(str, font, new SolidBrush(color), 0, 0);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// base64 字符串转 Image
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static Image ToImage(this string base64)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64);
                //读入MemoryStream对象  
                MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                //转成图片  
                Image image = Image.FromStream(memoryStream);
                return image;
            }
            catch (Exception)
            {
                Image image = null;
                return image;
            }
        }
        /// <summary>
        /// Image 转base64字符串 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string ToBase64(this Image image)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                string pic = Convert.ToBase64String(arr);
                return pic;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 为图片生成缩略图  
        /// </summary>
        /// <param name="phyPath">原图片的路径</param>
        /// <param name="width">缩略图宽</param>
        /// <param name="height">缩略图高</param>
        /// <returns></returns>
        public static Image GetThumbnail(Image image, int max)
        {
            double width, height;
            if (image.Width > image.Height)
            {
                width = max;
                height = max / image.Width * image.Height;
            }
            else
            {
                height = max;
                width = max / image.Height * image.Width;
            }
            Bitmap bmp = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height));
            //从Bitmap创建一个System.Drawing.Graphics
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            //设置 
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            //下面这个也设成高质量
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            //下面这个设成High
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            //把原始图像绘制成上面所设置宽高的缩小图
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, Convert.ToInt32(width), Convert.ToInt32(height));
            gr.DrawImage(image, rectDestination, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            return bmp;

        }
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="sourceImage">源图像</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="imageQualityValue">质量百分比</param>
        /// <returns></returns>
        public static bool SaveImageForSpecifiedQuality(System.Drawing.Image sourceImage, string savePath, int imageQualityValue)
        {
            //以下代码为保存图片时，设置压缩质量
            EncoderParameters encoderParameters = new EncoderParameters();
            EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQualityValue);
            encoderParameters.Param[0] = encoderParameter;
            try
            {
                ImageCodecInfo[] ImageCodecInfoArray = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegImageCodecInfo = null;
                for (int i = 0; i < ImageCodecInfoArray.Length; i++)
                {
                    if (ImageCodecInfoArray[i].FormatDescription.Equals("JPEG"))
                    {
                        jpegImageCodecInfo = ImageCodecInfoArray[i];
                        break;
                    }
                }
                sourceImage.Save(savePath, jpegImageCodecInfo, encoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ImageFingerPrint(Image img, int Img_Precision, byte color)
        {
            Image thumbnailImage = img.GetThumbnailImage(Img_Precision, Img_Precision, null, IntPtr.Zero);
            Bitmap bitmap = new Bitmap(thumbnailImage);
            byte[] array = new byte[thumbnailImage.Width * thumbnailImage.Height + 1];
            int num = thumbnailImage.Width - 1;
            for (int i = 0; i <= num; i++)
            {
                int num2 = thumbnailImage.Height - 1;
                for (int j = 0; j <= num2; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    //byte b = (byte)Math.Round((double)(pixel.R * 30 + pixel.G * 59 + pixel.B * 11) / 100.0);
                    byte b = pixel.R;
                    array[i * thumbnailImage.Width + j] = b;
                }
            }
            return System.Text.Encoding.Default.GetString(array);
        }
    }
}