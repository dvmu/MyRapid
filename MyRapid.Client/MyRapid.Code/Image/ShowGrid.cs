/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public static class ShowGrid
    {
        //高度
        public static int BlockHeight = 50;
        //宽度
        public static int BlockWidth = 50;
        //宽度
        public static int BlockOffset = 5;
        //行数
        public static int GridRowCount = 5;
        //列数
        public static int GridColumnCount = 10;
        //边框
        public static int BorderSize = 5;
        //边框颜色
        public static Color BorderColor = Color.Gray;
        //背景颜色
        public static Color BackgroundColor = Color.GhostWhite;
        //字体
        public static Font BlockFont = new Font("微软雅黑", 12);
        //颜色
        public static Color BlockColor = Color.Black;
        //横向方向
        //public static bool GridColumnFirst = true;
        //画板控件
        public static Control GridBoard { get; set; }
        //Graphics
        private static Graphics GridGraphics { get; set; }
        static int index = 0;
        public static void InitializeGrid(Control gridBoard)
        {
            index = 0;
            GridBoard = gridBoard;
            if (GridBoard ==null) return;
            GridGraphics = GridBoard.CreateGraphics();
            GridGraphics.Clear(BackgroundColor);
            for (int i = 0; i < GridColumnCount; i++)
            {
                for (int j = 0; j < GridRowCount; j++)
                {
                    GridBlock gridBlock = new GridBlock();
                    gridBlock.BlockIndex = index;
                    index += 1;
                    gridBlock.BlockColor = BlockColor;
                    gridBlock.BlockText = "";//gridBlock.BlockIndex.ToString();
                    PaintBlock(gridBlock);
                }
            }
        }
        public static void PaintBlock(GridBlock gridBlock)
        {
            if (GridBoard ==null) return;
            if (GridGraphics ==null) return;
            int x = BlockOffset;
            int y = BlockOffset;
            //根据序号取得当前Index所对应位置
            //if (GridColumnFirst)
            //{
            x += (gridBlock.BlockColumnIndex.Equals( 0) ? (gridBlock.BlockIndex % GridColumnCount) : gridBlock.BlockColumnIndex) * (BlockWidth + BlockOffset);
            y += (gridBlock.BlockRowIndex.Equals( 0) ? (gridBlock.BlockIndex / GridColumnCount) : gridBlock.BlockRowIndex) * (BlockHeight + BlockOffset);
            //}
            //else
            //{
            //    x += (gridBlock.BlockIndex / GridRowCount) * (BlockWidth + BlockOffset);
            //    y += (gridBlock.BlockIndex % GridRowCount) * (BlockHeight + BlockOffset);
            //}
            //先画一个大的底块
            GridGraphics.FillRectangle(new SolidBrush(gridBlock.BorderColor), new Rectangle(x, y, BlockWidth, BlockHeight));
            x = x + BorderSize;
            y = y + BorderSize;
            int w = BlockWidth - (BorderSize * 2);
            int h = BlockHeight - (BorderSize * 2);
            //再画块
            gridBlock.BlockSize = new Size(w, h);
            gridBlock.BlockLocation = new Point(x, y);
            GridGraphics.FillRectangle(new SolidBrush(gridBlock.BlockColor), new Rectangle(x, y, w, h));
            //写入文字
            GridGraphics.DrawString(gridBlock.BlockText, BlockFont, Brushes.Black, new Rectangle(x, y, w, h));
            // GridBoard.Refresh();
        }
        public static void PaintBlock(int x, int y, Color color, Color borderColor, string text)
        {
            GridGraphics.FillRectangle(new SolidBrush(borderColor), new Rectangle(x, y, BlockWidth, BlockHeight));
            x = x + BorderSize;
            y = y + BorderSize;
            int w = BlockWidth - (BorderSize * 2);
            int h = BlockHeight - (BorderSize * 2);
            GridGraphics.FillRectangle(new SolidBrush(color), new Rectangle(x, y, w, h));
            //写入文字
            GridGraphics.DrawString(text, BlockFont, Brushes.Black, new Rectangle(x, y, w, h));
            // GridBoard.Refresh();
        }
        public static void PaintBlock(Rectangle rectangle, Color color)
        {
            GridGraphics.FillRectangle(new SolidBrush(color), rectangle);
        }
    }
    public class GridBlock
    {
        public int BlockIndex { get; set; }
        public Color BlockColor { get; set; }
        public Color BorderColor { get; set; }
        public string BlockText { get; set; }
        public int BlockRowIndex { get; set; }
        public int BlockColumnIndex { get; set; }
        public Point BlockLocation { get; set; }
        public Size BlockSize { get; set; }
    }

}