using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 K번째수
    // https://programmers.co.kr/learn/courses/30/lessons/42748/solution_groups?language=csharp
    // 솔루션
    class Programmers_Q2
    {
        public static int[] Solution(int[] array, int[,] commands) // 나의 풀이
        {
            List<int> list = new List<int>(array);
            List<int> results = new List<int>();

            for (int i = 0; i < commands.GetLength(0); i++)
            {
                List<int> ranges = list.GetRange(commands[i, 0] - 1, commands[i, 1] - commands[i, 0] + 1);
                ranges = ranges.OrderBy(n => n).ToList();
                int value = ranges[(commands[i, 2] - 1)];
                results.Add(value);
            }

            return results.ToArray();
        }

        public static int[] Solution1(int[] array, int[,] commands) // 참고할 풀이
        {
            List<int> list = new List<int>(array);
            List<int> results = new List<int>();

            for (int i = 0; i < commands.GetLength(0); i++)
            {
                int start = commands[i, 0];
                int end = commands[i, 1];
                int findIndex = commands[i, 2] - 1;
                
                List<int> ranges = list.Where((x, index) => index >= start -1 && index < end).OrderBy(n => n).ToList();
                int value = ranges[(commands[i, 2] - 1)];
                results.Add(value);
            }

            return results.ToArray();
        }
    }
}
