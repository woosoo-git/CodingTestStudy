using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 스킬 체크 테스트 Level.1
    // https://programmers.co.kr/skill_checks/353053?challenge_id=7063
    // 솔루션
    public class Programmers_Q12
    {
        public static int Solution(int[] a, int[] b) // 나의 풀이
        {
            int answer = 0;
            int n = a.Length;
            
            for (int i = 0; i < n; i++)
            {
                int result = a[i] * b[i];
                answer += result;
            }

            return answer;
        }
    }
}
