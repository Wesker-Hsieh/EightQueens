using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueens
{
    public class EightQueens
    {
        // 16777215
        static int solutionsQty = 0;

        static List<string> str = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7" };

        static int[] Chessboard = new int[8];

        static int OneOfChessboard = 0;

        public static void Execute()
        {
            while (OneOfChessboard <= 16777215)
            {
                Calculus();
                OneOfChessboard++;
            }
            System.Console.Write($"一共有 {solutionsQty} 種解法");
        }
        private static void Calculus()
        {
            string octal = Convert.ToString(OneOfChessboard, 8);

            if (7 > octal.Length)
            {
                //表示第一列會有最少兩個皇后
                return;
            }
            octal = octal.PadLeft(8, '0');

            if (!str.All(x => octal.Contains(x)))
            {
                //表示某一列有超過一個皇后
                return;
            }

            //將每一行的皇后位置放入Chessboard之中
            for (int i = 0; i < 8; i++)
            {
                Chessboard[i] = Convert.ToInt32(octal.Substring(i, 1));
            }

            if (!CrossJudge())
            {
                return;
            }

            Print();

            System.Console.WriteLine();
            System.Console.WriteLine();
            solutionsQty++;
        }

        /// <summary>
        /// 判斷X方向是否有皇后
        /// </summary>
        /// <returns></returns>
        private static bool CrossJudge()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (i + j > 7) break;
                    if (Chessboard[i] + j == Chessboard[i + j] || Chessboard[i] - j == Chessboard[i + j])
                    {
                        //X路線有皇后
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 印出棋盤
        /// </summary>
        private static void Print()
        {
            //for (int i = 0; i < Chessboard.Length; i++)
            //{
            //    System.Console.Write(Chessboard[i] + " ");
            //}
            System.Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Chessboard[j] == i)
                        System.Console.Write("Q");
                    else
                        System.Console.Write(".");
                }
                System.Console.WriteLine();
            }
        }
    }
}
