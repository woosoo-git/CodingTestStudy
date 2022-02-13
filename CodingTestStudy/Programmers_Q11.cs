using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTestStudy
{
    public class Programmers_Q11
    {
        public static int[] Solution(int[] progresses, int[] speeds) // 나의 풀이
        {
            List<int> needDays = new List<int>();
            for (int i = 0; i < progresses.Length; i++)
            {
                int dayWork = speeds[i];
                int percentage = progresses[i];
                int needDay = 0;

                while(percentage < 100)
                {
                    percentage += dayWork;
                    needDay++;
                }

                needDays.Add(needDay);
            }

            List<int> deployCount = new List<int>();
            int count = 0;
            int day = needDays[0];
            for (int i = 0; i < needDays.Count; i++)
            {
                if (needDays[i] <= day)
                {
                    count++;
                }
                else
                {
                    deployCount.Add(count);
                    count = 1;
                    day = needDays[i];
                }
            }

            deployCount.Add(count);

            return deployCount.ToArray();
        }
    }
}
