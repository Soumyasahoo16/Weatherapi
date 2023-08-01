using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
namespace Exam
{
     class DataAccess
    {
        public static List<DataModel.List> l = new List<DataModel.List>();
        public DataAccess()
        {
            var client = new HttpClient();
            String Url = "https://samples.openweathermap.org/data/2.5/forecast/hourly?q=London,us&appid=b6907d289e10d714a6e88b30761fae22";
            var response = client.GetAsync(Url);
            response.Wait();

            var result = response.Result;


            var data = result.Content.ReadAsStringAsync();
            data.Wait();
            String da = data.Result;
            var deserializedata = JsonConvert.DeserializeObject<DataModel>(da);

            foreach (var dat in deserializedata.list)
            {
                l.Add(dat);
            }
        }
         public List<DataReprestentation.WindsWithDate> GetWinds(string date)
           {
            List<DataReprestentation.WindsWithDate> lw = new List<DataReprestentation.WindsWithDate>();
            foreach(var data in l)
            {
                string db_txt = data.dt_txt;
                
                string onlydate = db_txt.Substring( 0, 10);
                if (onlydate == date)
                {
                    DataModel.Wind w = data.wind;
                    DateTime da = Convert.ToDateTime(db_txt);
                    DataReprestentation.WindsWithDate dp = new DataReprestentation.WindsWithDate(da,w);
                    lw.Add(dp);
                }
            }
            return lw;
        }
      public List<DataReprestentation.MainWithDate> GetData(string date)
        {
            List<DataReprestentation.MainWithDate> mw = new List<DataReprestentation.MainWithDate>();
            foreach (var data in l)
            {
                string db_txt = data.dt_txt;
                string onlydate = db_txt.Substring(0, 10);
                
                if (onlydate == date)
                {
                    DataModel.Main m = data.main;
                    DateTime da = Convert.ToDateTime(db_txt);
                    DataReprestentation.MainWithDate datemain = new DataReprestentation.MainWithDate(m,da);
                    mw.Add(datemain);
                }
            }
            
            return mw;

        }

    }
}
