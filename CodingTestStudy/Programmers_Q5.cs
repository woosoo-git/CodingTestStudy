using System.Collections.Generic;
using System.Linq;

namespace CodingTestStudy
{
    public class Programmers_Q5
    {
        // 프로그래머스 카펫
        // https://programmers.co.kr/learn/courses/30/lessons/42842?language=csharp
        // 솔루션
        public static int[] Solution(int brown, int yellow) // 나의 풀이
        {
            int totalTileCount = brown + yellow;

            List<int> list = new List<int>();
            for (int i = 3; i <= totalTileCount / 3; i++)
            {
                if (totalTileCount % i == 0)
                {
                    int side1 = i;
                    int side2 = totalTileCount / i;

                    int calcBrown = (side1 * 2) + ((side2 - 2) * 2);
                    int calcYellow = (side1 * side2) - calcBrown;

                    if (calcBrown == brown && calcYellow == yellow)
                    {
                        list.Add(side1);
                        list.Add(side2);
                        break;
                    }
                }
            }

            list.Sort();
            list.Reverse();

            return list.ToArray();

        }
    }
}
