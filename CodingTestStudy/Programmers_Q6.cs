using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTestStudy
{
    // 프로그래머스 타겟넘버
    // https://programmers.co.kr/learn/courses/30/lessons/42842?language=csharp
    // 솔루션
    class Programmers_Q6
    {
        public static int count = 0;

        public static int Solution(int[] numbers, int target) // 나의 풀이
        {
            CommandCombination(numbers, string.Empty, target);
            return count;
        }

        public static void CommandCombination(int[] numbers, string value, int target)
        {
            string command = (string)value.Clone();
            if (command.Length == numbers.Length)
            {
                int sum = 0;
                for (int j = 0; j < command.Length; j++)
                {
                    if (command[j] == '+')
                    {
                        sum += numbers[j];
                    }
                    else
                    {
                        sum -= numbers[j];
                    }
                }

                if (sum == target)
                {
                    count++;
                }
                return;
            }

            CommandCombination(numbers, command + "+", target);
            CommandCombination(numbers, command + "-", target);
        }

        public static int solution(int[] numbers, int target) // 참고할 풀이
        {
            return Dfs(numbers, target, 0, 0);
        }

        public static int Dfs(int[] arr, int target, int idx, int num)
        {
            if (idx == arr.Length)
            {
                if (target == num) return 1;
                else return 0;
            }
            else
                return Dfs(arr, target, idx + 1, num + arr[idx]) + Dfs(arr, target, idx + 1, num - arr[idx]);
        }

        
    }
}
