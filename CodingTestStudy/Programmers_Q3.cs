using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 모의고사
    // https://programmers.co.kr/learn/courses/30/lessons/42840?language=csharp
    // 솔루션
    class Programmers_Q3
    {
        public static int[] Solution(int[] answer) // 나의 풀이
        {
            List<int> answer_count = new List<int>();

            List<List<int>> patterns = new List<List<int>>();
            patterns.Add(new List<int>() { 1, 2, 3, 4, 5 });
            patterns.Add(new List<int>() { 2, 1, 2, 3, 2, 4, 2, 5 });
            patterns.Add(new List<int>() { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 });

            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < answer.Length; j++)
                {
                    int patternIndex =  j % patterns[i].Count;
                    if (patterns[i][patternIndex] == answer[j])
                    {
                        count++;
                    }
                }
                answer_count.Add(count);
            }

            int max = answer_count.Max();
            List<int> list = new List<int>();
            for (int i = 0; i < answer_count.Count; i++)
            {
                if (answer_count[i] == max)
                {
                    list.Add(i + 1);
                }
            }

            return list.ToArray();
        }

    }
}
