using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTestStudy
{
    // 프로그래머스 위장
    // https://programmers.co.kr/learn/courses/30/lessons/42578?language=csharp
    // 솔루션
    public class Programmers_Q1
    {
        public static int Solution(string[,] array) // 나의 풀이
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            int result = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (dic.ContainsKey(array[i, 1]))
                {
                    dic[array[i, 1]]++;
                }
                else
                {
                    dic.Add(array[i, 1], 1);
                }
            }

            foreach (KeyValuePair<string, int> item in dic)
            {
                result *= (item.Value + 1); 
            }

            result -= 1; 

            return result;
        }

        public static int Solution1(string[,] clothes) // 참고할 풀이
        {
            return Enumerable.Range(0, clothes.GetLength(0)).Select(i => clothes[i, 1]).GroupBy(p => p).Select(g => g.Count() + 1).Aggregate(1, (p, q) => p * q) - 1;
            // 0부터 clothes의 0번째 로우 len까지 연속된 데이터에서 clothes의 분류 항목만 셀렉트해서 분류항목으로 그룹을 짓는다.
            // 그룹마다 몇개가 항목이 몇개가 들어 있는지 카운트를 세고 +1 (그룹마다 선택되지 않을 수 있는 경우의 수)
            // 1과 그룹마다의 카운트를 더하면서 누적한다.
            // 아무것도 선택하지 않는 경우는 없으므로 -1 
        }

        public static int Solution2(string[,] array) // 참고할 풀이
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            int result = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (dic.TryAdd(array[i,1], 1) == false) // 딕셔너리의 tryadd 함수를 이용한다. key가 이미 존재하는 경우 false 반환
                {
                    dic[array[i, 1]]++;
                }
            }

            foreach (KeyValuePair<string, int> item in dic)
            {
                result *= (item.Value + 1);
            }

            result -= 1;

            return result;
        }
    }
}
