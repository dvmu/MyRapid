/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public class WaveImage
    {
        Timer Effect = new Timer();
        Control Target;
        public WaveImage(Control TargetControl, Bitmap TargetImage)
        {
            Target = TargetControl;
            BmpImage = TargetImage;
            this.Effect.Tick += new EventHandler(Effect_Tick);
            Target.Paint += new PaintEventHandler(WavesControl_Paint);
            Target.MouseMove += new MouseEventHandler(WavesControl_MouseMove);
            this.Effect.Enabled = true;
            this.Effect.Interval = 50;
        }
        #region Fields or Properties
        private int scale = 1;
        /// <summary>
        /// The scale of the wave matrix compared to the size of the image.
        /// Use it for large images to reduce processor load.
        /// 
        /// 0 : wave resolution is the same than image resolution
        /// 1 : wave resolution is half the image resolution
        /// ...and so on
        /// </summary>
        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        private Bitmap bmpImage;
        /// <summary>
        /// Background image
        /// </summary>
        public Bitmap BmpImage
        {
            get { return bmpImage; }
            set
            {
                if (value ==null)
                    return;
                bmpImage = value;
                bmpHeight = bmpImage.Height;
                bmpWidth = bmpImage.Width;
                waveHeight = bmpHeight >> scale;
                waveWidth = bmpWidth >> scale;
                waves = new short[waveWidth, waveHeight, 2];
                bmpBytes = new byte[bmpWidth * bmpHeight * 4];
                bmpBitmapData = bmpImage.LockBits(new Rectangle(0, 0, bmpWidth, bmpHeight),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Marshal.Copy(bmpBitmapData.Scan0, bmpBytes, 0, bmpWidth * bmpHeight * 4);
            }
        }
        private int bmpHeight { get; set; }
        private int bmpWidth { get; set; }
        private int waveWidth { get; set; }
        private int waveHeight { get; set; }
        private short[,,] waves { get; set; }
        private byte[] bmpBytes { get; set; }
        private System.Drawing.Imaging.BitmapData bmpBitmapData { get; set; }
        private bool IsWaves = false;
        private int activedBuf = 0;
        #endregion
        void WavesControl_MouseMove(object sender, MouseEventArgs e)
        {
            int realX = (int)((e.X / (double)Target.ClientRectangle.Width) * waveWidth);
            int realY = (int)((e.Y / (double)Target.ClientRectangle.Height) * waveHeight);
            this.PutDrop(realX, realY, 200);
        }
        /// <summary>
        /// This function is used to start a wave by simulating a round drop
        /// </summary>
        /// <param name="realX">x position of the drop</param>
        /// <param name="realY">y position of the drop</param>
        /// <param name="height">Height position of the drop</param>
        private void PutDrop(int realX, int realY, int height)
        {
            this.IsWaves = true;
            int radius = 5;
            double dist;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (((realX + i >= 0) && (realX + i < waveWidth - 1)) && ((realY + j >= 0) && (realY + j < waveHeight - 1)))
                    {
                        dist = Math.Sqrt(i * i + j * j);
                        if (dist < radius)
                            waves[realX + i, realY + j, activedBuf] = (short)(Math.Cos(dist * Math.PI / radius) * height);
                    }
                }
            }
        }
        /// <summary>
        /// Paint handler
        /// Calculates the final effect-image out of
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WavesControl_Paint(object sender, PaintEventArgs e)
        {
            if (bmpImage ==null) return;
            using (Bitmap tmpBmp = bmpImage.Clone() as Bitmap)
            {
                int xOffset, yOffset;
                byte alpha;
                if (IsWaves)
                {
                    BitmapData tmpBitmapData = tmpBmp.LockBits(new Rectangle(0, 0, bmpWidth, bmpHeight),
                        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    byte[] tmpBytes = new byte[bmpWidth * bmpHeight * 4];
                    Marshal.Copy(tmpBitmapData.Scan0, tmpBytes, 0, bmpWidth * bmpHeight * 4);
                    for (int x = 1; x < bmpWidth - 1; x++)
                    {
                        for (int y = 1; y < bmpHeight - 1; y++)
                        {
                            int waveX = (int)x >> scale;
                            int waveY = (int)y >> scale;
                            ///check bounds
                            waveX = waveX <= 0 ? 1 : waveX;
                            waveY = waveY <= 0 ? 1 : waveY;
                            waveX = waveX >= waveWidth - 1 ? waveWidth - 2 : waveX;
                            waveY = waveY >= waveHeight - 1 ? waveHeight - 2 : waveY;
                            ///this gives us the effect of water breaking the light
                            xOffset = (waves[waveX - 1, waveY, activedBuf] - waves[waveX + 1, waveY, activedBuf]) >> 3;
                            yOffset = (waves[waveX, waveY - 1, activedBuf] - waves[waveX, waveY + 1, activedBuf]) >> 3;
                            if ((xOffset != 0) || (yOffset != 0))
                            {
                                ///check bounds
                                if (x + xOffset >= bmpWidth - 1)
                                    xOffset = bmpWidth - x - 1;
                                if (y + yOffset >= bmpHeight - 1)
                                    yOffset = bmpHeight - y - 1;
                                if (x + xOffset < 0) xOffset = -x;
                                if (y + yOffset < 0) yOffset = -y;
                                ///generate alpha
                                alpha = (byte)(200 - xOffset);
                                if (alpha < 0) alpha = 0;
                                if (alpha > 255) alpha = 254;
                                ///set colors
                                tmpBytes[4 * (x + y * bmpWidth)] = bmpBytes[4 * (x + xOffset + (y + yOffset) * bmpWidth)];
                                tmpBytes[4 * (x + y * bmpWidth) + 1] = bmpBytes[4 * (x + xOffset + (y + yOffset) * bmpWidth) + 1];
                                tmpBytes[4 * (x + y * bmpWidth) + 2] = bmpBytes[4 * (x + xOffset + (y + yOffset) * bmpWidth) + 2];
                                tmpBytes[4 * (x + y * bmpWidth) + 3] = alpha;
                            }
                        }
                    }
                    ///copy data back
                    Marshal.Copy(tmpBytes, 0, tmpBitmapData.Scan0, bmpWidth * bmpHeight * 4);
                    tmpBmp.UnlockBits(tmpBitmapData);
                }
                e.Graphics.DrawImage(tmpBmp, 0, 0, Target.ClientRectangle.Width, Target.ClientRectangle.Height);
            }
        }
        //X0’=（X1+X2+X3+X4）/ 2- X0
        //好了，有了上面这个近似公式，你就可以推广到下面这个一般结论：
        //已知某一时刻水面上任意一点的波幅，那么，在下一时刻，任意一点的波幅就等于与该点紧邻的前、后、左、右四点的波幅的和除以2、再减去该点的波幅。
        //应该注意到，水在实际中是存在阻尼的，否则，用上面这个公式，一旦你在水中增加一个波源，水面将永不停止的震荡下去。
        //所以，还需要对波幅数据进行衰减处理，让每一个点在经过一次计算后，波幅都比理想值按一定的比例降低。这个衰减率经过测试，用1/32比较合适，也就是1/2^5。可以通过移位运算很快的获得。
        private void Waves()
        {
            int newBuf = this.activedBuf.Equals( 0) ? 1 : 0;
            bool wavesFound = false;
            //波能扩散
            for (int x = 1; x < waveWidth - 1; x++)
            {
                for (int y = 1; y < waveHeight - 1; y++)
                {
                    waves[x, y, newBuf] = (short)(((
                        waves[x - 1, y - 1, activedBuf] +
                        waves[x - 1, y, activedBuf] +
                        waves[x - 1, y + 1, activedBuf] +
                        waves[x, y - 1, activedBuf] +
                        waves[x, y + 1, activedBuf] +
                        waves[x + 1, y - 1, activedBuf] +
                        waves[x + 1, y, activedBuf] +
                        waves[x + 1, y + 1, activedBuf]) >> 2) - waves[x, y, newBuf]);
                    ///damping//波能衰减
                    if (waves[x, y, newBuf] != 0)
                    {
                        waves[x, y, newBuf] -= (short)(waves[x, y, newBuf] >> 4);
                        wavesFound = true;
                    }
                }
            }
            IsWaves = wavesFound;
            activedBuf = newBuf;
        }
        void Effect_Tick(object sender, EventArgs e)
        {
            if (IsWaves)
            {
                Target.Invalidate();
                Waves();
            }
        }
    }
}