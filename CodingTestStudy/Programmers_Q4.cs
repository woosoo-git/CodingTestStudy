using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 소수찾기
    // https://programmers.co.kr/learn/courses/30/lessons/42839?language=csharp
    // 솔루션
    public class Programmers_Q4
    {
        public static int Solution(string numbers) // 나의 풀이
        {
            List<int> makeNumList = new List<int>();
            List<int> numList = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                string strNum = numbers[i].ToString();
                numList.Add(Convert.ToInt32(strNum));
            }

            Combination(numList, string.Empty, makeNumList);

            List<int> sosuList = new List<int>();
            makeNumList = makeNumList.Distinct().ToList();
            for (int i = 0; i < makeNumList.Count; i++)
            {
                bool isSosu = true;
                for (int j = 2; j < makeNumList[i]; j++)
                {
                    if (makeNumList[i] % j == 0)
                    {
                        isSosu = false;
                        break;
                    }
                }

                if (isSosu && makeNumList[i] != 0 && makeNumList[i] != 1)
                {
                    sosuList.Add(makeNumList[i]);
                }
            }

            return sosuList.Count;


        }

        public static void Combination(List<int> list, string value, List<int> makeNumList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string copyValue = (string)value.Clone();
                copyValue += list[i].ToString();
                int numValue = Convert.ToInt32(copyValue);
                makeNumList.Add(numValue);

                List<int> newList = list.Where((x, index) => index != i).ToList();
                if (newList.Count > 0)
                    Combination(newList, numValue.ToString(), makeNumList);

            }
        }
    }
}
