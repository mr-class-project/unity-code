using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System;
using UnityEngine.UI;

public class WeatherApi : MonoBehaviour
{

    public string city_name; //都市の名前
    public string weather_condition; //天気の状態
    public int temp_min; //最低気温
    public int temp_max; //最高気温


    //外部スクリプトからの取得用変数
    //public string tommorow_weather; // 明日(24時間後)の天気
    //public int tommorow_temperature; // 明日の最高気温

    string IconToWeather(string s)
    {
        if (s == "01d") return "快晴";
        if (s == "02d") return "晴れ";
        if (s == "03d") return "くもり";
        if (s == "04d") return "くもり";
        if (s == "09d") return "小雨";
        if (s == "10d") return "雨";
        if (s == "11d") return "雷雨";
        if (s == "13d") return "雪";
        if (s == "50d") return "霧";
        else return "不明";
    }
    int DoubleToInt(double d)
    {
        return (int)d;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //apiとの通信
        string url = "http://api.openweathermap.org/data/2.5/weather?id=1850147&units=metric&appid=111643793037a778a62d66e2a7d7d372";
        WWW www = new WWW(url);
        yield return www;
        //今日の天気をjsonから取り出す
        var jsonString = www.text;
        var json = Json.Deserialize(www.text) as Dictionary<string, object>;
        var weather = (IList)json["weather"];
        var weather0 = (IDictionary)weather[0];
        string icon = (string)weather0["icon"];
        weather_condition = IconToWeather(icon);
        var main2 = json["main"] as Dictionary<string, object>;
        var temp_min = main2["temp_min"];
        var temp_max = main2["temp_max"];
        temp_min = Convert.ToInt32(temp_min);
        temp_max = Convert.ToInt32(temp_max);
        city_name = (string)json["name"];

        //ログの出力
        //Debug.Log(weather_condition);
        //Debug.Log(temp_max);
        //Debug.Log(temp_min);
        //Debug.Log(city_name);


        //apiとの通信
        /*
        string url = "http://api.openweathermap.org/data/2.5/forecast?id=1850147&units=metric&cnt=8&appid=111643793037a778a62d66e2a7d7d372";
        WWW www = new WWW(url);
        yield return www;
        //明日の天気をjsonから取り出す
        var json = Json.Deserialize(www.text) as Dictionary<string, object>;
        var list = (IList)json["list"];
        var tommorow = (IDictionary)list[7];
        var weather = (IList)tommorow["weather"];
        var weather0 = (IDictionary)weather[0];
        string weather_icon = (string)weather0["icon"];
        tommorow_weather = IconToWeather(weather_icon);
        var main = tommorow["main"] as Dictionary<string, object>;
        tommorow_temperature = DoubleToInt(Convert.ToInt32(main["temp"]));
        //ログの出力
        //Debug.Log(tommorow_weather);
        //Debug.Log(tommorow_temperature);
        */

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
