using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTestStudy
{
    public class Programmers_Q8
    {
        //프로그래머스 숫자문자열과 영단어
        //https://programmers.co.kr/learn/courses/30/lessons/81301
        //솔루션
        public static int Solution(string s) // 나의 풀이
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "zero");
            dic.Add("1", "one");
            dic.Add("2", "two");
            dic.Add("3", "three");
            dic.Add("4", "four");
            dic.Add("5", "five");
            dic.Add("6", "six");
            dic.Add("7", "seven");
            dic.Add("8", "eight");
            dic.Add("9", "nine");

            foreach (KeyValuePair<string, string> item in dic)
            {
                s = s.Replace(item.Value, item.Key);
            }

            return Convert.ToInt32(s);
        }
    }
}
