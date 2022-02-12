using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTestStudy
{
    public class Programmers_Q9
    {
        //프로그래머스 로또의 최고 순위와 취저 순위
        //https://programmers.co.kr/learn/courses/30/lessons/77484
        //솔루션
        public static int[] Solution(int[] lottos, int[] win_nums) // 나의 풀이
        {
            Dictionary<int, int> lottoDic = new Dictionary<int, int>();
            lottoDic.Add(6, 1);
            lottoDic.Add(5, 2);
            lottoDic.Add(4, 3);
            lottoDic.Add(3, 4);
            lottoDic.Add(2, 5);
            lottoDic.Add(1, 6);
            lottoDic.Add(0, 6);

            
            int removedCount = 0;
            int matchedCount = 0;

            List<int> winNumList = new List<int>(win_nums);
            for (int i = 0; i < lottos.Length; i++)
            {
                if (lottos[i] == 0)
                {
                    removedCount++;
                }
                else
                {
                    if (winNumList.Contains(lottos[i]))
                    {
                        matchedCount++;
                    }
                }
            }

            int topCount = matchedCount + removedCount;
            int bottomCount = matchedCount;

            List<int> result = new List<int>();
            result.Add(lottoDic[topCount]);
            result.Add(lottoDic[bottomCount]);

            return result.ToArray();
        }

        public static int[] Solution1(int[] lottos, int[] win_nums) //참고할 풀이
        {
            int winCount = lottos.Intersect(win_nums).Count(); // 두 배열의 교집합 항목만 뽑아내서 갯수를 센다.
            int loseCount = lottos.Where((number) => number != 0).Count() - winCount; // 0이 아닌 숫자 중 틀린 숫자의 갯수

            int[] answer = new int[] { WinCountToRank(6 - loseCount), WinCountToRank(winCount) };
            return answer;
        }

        public static int WinCountToRank(int count)
        {
            if (count <= 1)
            {
                return 6;
            }

            return 7 - count;
        }
    }
}
