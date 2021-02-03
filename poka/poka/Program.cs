using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
★入力例★　実行して、コンソールウインドウから以下のように入力して動作確認しましょう。（行末でEnterキー）
0 01
3 06
3 10
3 01
1 01

★出力例★　上記のテストデータでは、以下の結果が出たら正解です。
SA H6 H10 HA CA
スリーカード
*/

namespace Kadai2_1
{
    class Program
    {
        static String[] SUIT_STRING = { "S", "C", "D", "H" };
        static String[] NUMBER_STRING = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        static private int[] suit = new int[5];
        static private int[] number = new int[5];

        static private int[] suitCount = { 0, 0, 0, 0 };
        static private int[] numberCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        static void Main(string[] args)
        {
            CardYomu();        // カード情報をコンソールから読み、
            CardStringKaku();  // カードの絵柄と番号を書いて、
            HanteiJunbi();     // 役判定のために準備して、
            Yakuhantei();      // 役を判定する。
            Console.ReadLine();  // ★改行入力を待っている（コンソール表示を一時停止）
        }

        static void CardYomu()
        {
            for (int i = 0; i < 5; ++i)
            {
                string[] str = Console.ReadLine().Trim().Split(' ');  // 1行を読み込んで配列に代入
                suit[i] = int.Parse(str[0]);    // スート（スペードなら0、クラブなら1、…）
                number[i] = int.Parse(str[1]);  // 番号（01～13）
            }
        }

        static void CardStringKaku()
        {
            for (int i = 0; i < 4; ++i)
            {
                Console.Write(SUIT_STRING[suit[i]]);
                Console.Write(NUMBER_STRING[number[i] - 1]);
                Console.Write(" ");
            }
            Console.Write(SUIT_STRING[suit[4]]);
            Console.WriteLine(NUMBER_STRING[number[4] - 1]);
        }

        static void HanteiJunbi()
        {
            for (int i = 0; i < 5; ++i)
            {
                suitCount[suit[i]] += 1;　　//同じスーツの個数を数える
                numberCount[number[i] - 1] += 1; // 同じ数字の個数を数える
            }


        }

        static void Yakuhantei()
        {
            // ロイヤル(ストレート)フラッシュ！！！
            if ((suit[0] == suit[1] && suit[0] == suit[2] && suit[0] == suit[3] && suit[0] == suit[4])
                  && ((number[0] + number[1] + number[2] + number[3] + number[4]) == 47)
                  && (number[0] == 1 || number[1] == 1 || number[2] == 1 || number[3] == 1 || number[4] == 1))
            {
                Console.WriteLine("ロイヤルフラッシュ");
            }

            // フラッシュ　※同じスーツが5枚かを判定している
            else if (suitCount[0] == 5 || suitCount[1] == 5 || suitCount[2] == 5 || suitCount[3] == 5)
            {
                Console.WriteLine("フラッシュ");
            }

            // スリーカード
            else if (suitCount[0] == 3 || suitCount[1] == 3 || suitCount[2] == 3 || suitCount[3] == 3)
            {
                Console.WriteLine("スリーカード");
            }

            else if (suitCount[0] == 4 || suitCount[1] == 4 || suitCount[2] == 4 || suitCount[3] == 4)
            {
                Console.WriteLine("フォーカード");
            }

            else if (suit[0] == suit[1] && suit[0] == suit[2] && suit[0] == suit[3] && suit[0] == suit[4])
            {
                Console.WriteLine("フラッシュ");
            }
            else if (number[0] == number[1]-1 & number[1] == number[2]-1 & number[2] == number[3]-1 & number[3] == number[4] - 1)
            {
                Console.WriteLine("ストレートフラッシュ");
            }
            else if (suitCount[0] == 2 || suitCount[1] == 2 || suitCount[2] == 2 || suitCount[3] == 2)
            {
                Console.WriteLine("ワンペア");
            }
        }
    }
}