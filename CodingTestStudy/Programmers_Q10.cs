using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTestStudy
{
    public class ParkingInfo
    {
        public string carNumber;
        public bool isOut = false;
        public TimeSpan parkingTimeSpan;
        public DateTime parkingInTime;
        public int fee;
    }

    // 프로그래머스 주차 요금 계싼
    // https://programmers.co.kr/learn/courses/30/lessons/92341
    // 솔루션
    public class Programmers_Q10
    {
        public static int[] Solution(int[] fees, string[] records) // 나의 풀이
        {
            Dictionary<string, ParkingInfo> parkingDic = new Dictionary<string, ParkingInfo>();

            for (int i = 0; i < records.Length; i++)
            {
                string[] values = records[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carNumber = values[1];
                string[] times = values[0].Split(":");
                int hour = Convert.ToInt32(times[0]);
                int min = Convert.ToInt32(times[1]);

                if (values[2] == "IN") // 입차 이면
                {
                    if (parkingDic.ContainsKey(carNumber))
                    {
                        ParkingInfo info = parkingDic[carNumber];
                        info.isOut = false;
                        info.parkingInTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, 0);
                    }
                    else
                    {
                        ParkingInfo info = new ParkingInfo()
                        {
                            carNumber = carNumber,
                            parkingInTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, 0),
                        };

                        parkingDic.Add(carNumber, info);
                    }
                }
                else // 출차 이면
                {
                    ParkingInfo info = parkingDic[carNumber];
                    info.isOut = true;
                    DateTime parkingOutTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, min, 0);

                    TimeSpan timeSpan = parkingOutTime - info.parkingInTime;
                    if (info.parkingTimeSpan == null)
                    {
                        info.parkingTimeSpan = timeSpan;
                    }
                    else
                    {
                        info.parkingTimeSpan += timeSpan;
                    }
                }

            }

            foreach (KeyValuePair<string, ParkingInfo> item in parkingDic)
            {
                if (!item.Value.isOut)
                {
                    item.Value.isOut = true;
                    DateTime parkingOutTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);

                    TimeSpan timeSpan = parkingOutTime - item.Value.parkingInTime;
                    if (item.Value.parkingTimeSpan == null)
                    {
                        item.Value.parkingTimeSpan = timeSpan;
                    }
                    else
                    {
                        item.Value.parkingTimeSpan += timeSpan;
                    }
                }

                double min = item.Value.parkingTimeSpan.TotalMinutes;

                if (min <= fees[0])
                {
                    item.Value.fee = fees[1];
                }
                else
                {
                    
                    int unit = (int)((min - fees[0]) / fees[2]);
                    if ((min - fees[0]) % fees[2] != 0)
                    {
                        unit++;
                    }

                    item.Value.fee = fees[1] + (unit * fees[3]);
                }


            }

            List<string> keys = parkingDic.Keys.ToList();
            keys.Sort();

            List<int> feeList = new List<int>();
            for (int i = 0; i < keys.Count; i++)
            {
                feeList.Add(parkingDic[keys[i]].fee);
            }

            return feeList.ToArray();
        }
    }
}
