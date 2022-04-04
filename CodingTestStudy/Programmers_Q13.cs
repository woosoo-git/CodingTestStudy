using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 스킬 체크 테스트 Level.2
    // https://programmers.co.kr/learn/courses/30/lessons/42748/solution_groups?language=csharp
    // 솔루션
    public class Programmers_Q13
    {
        public static int Solution(int[] citations)
        {
            int max = 0;

            for (int i = 1; i < citations.Length; i++)
            {
                int count = citations.Where(x => x >= i).Count();
                max = count >= i ? i : max;
            }
            return max;

        }
    }
}
