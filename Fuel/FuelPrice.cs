﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Robot.Database;

namespace Robot.Fuel
{
    public class FuelPrice
    {
        private int city_id = 0;
        private string content = "";
        private DataService ds;
        public FuelPrice(List<string> P)
        {
            if (P.Count > 1)
            {
                ds = new DataService();
                string city = P[1];
                int id = ds.GetCityId(city);
                city_id = id;
            }
        }


        public string GetPrice()
        {
            string sb = "";
            //3 -> mel 2-> syd
            if (city_id != 3 && city_id != 2)
            {
                sb = "查询油价，请输入：油价 城市名称\r\n 比如【油价 墨尔本】 或者 【fuel mel】\r\n 当前只支持墨尔本和悉尼油价查询，其它城市油价查询会在未来推出";
            }
            else
            {
                sb = ds.GetFuelPrice(city_id);
            }

            return sb;
        }
    }
}