using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestStudy
{
    public class ReportInfo
    {
        public List<string> reportList = new List<string>();
        public int reportedCount = 0;
    }

    // 프로그래머스 신고 결과 받기
    // https://programmers.co.kr/learn/courses/30/lessons/92334
    // 솔루션
    public class Programmers_Q7
    {
        public static int[] Solution(string[] id_list, string[] report, int k) // 나의 풀이
        {
            Dictionary<string, ReportInfo> userDic = new Dictionary<string, ReportInfo>();

            for (int i = 0; i < id_list.Length; i++)
            {
                ReportInfo userInfo = new ReportInfo();
                userDic.Add(id_list[i], userInfo);
            }

            List<string> vanList = new List<string>();
            for (int i = 0; i < report.Length; i++)
            {
                string reportValue = report[i];
                string[] reportArray = reportValue.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string reporter = reportArray[0];
                string reported = reportArray[1];

                ReportInfo reportInfo = userDic[reporter];
                if (!reportInfo.reportList.Contains(reported))
                {
                    reportInfo.reportList.Add(reported);

                    reportInfo = userDic[reported];
                    reportInfo.reportedCount++;
                    if (reportInfo.reportedCount >= k)
                        vanList.Add(reported);
                }
            }

            List<int> mailCount = new List<int>();
            foreach (KeyValuePair<string, ReportInfo> user in userDic)
            {
                int count = user.Value.reportList.Intersect(vanList).Count();
                mailCount.Add(count);
            }

            return mailCount.ToArray();
        }


    }
}
