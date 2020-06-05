using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System;
using UnityEngine.UI;

public class WeatherApi : MonoBehaviour
{
    public Text title;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //apiとの通信
        string url = "http://api.openweathermap.org/data/2.5/weather?id=1850147&units=metric&appid=111643793037a778a62d66e2a7d7d372";
        WWW www = new WWW(url);
        yield return www;
        //jsonからデータを取り出す
        var jsonString = www.text;
        var json = Json.Deserialize(www.text) as Dictionary<string, object>;
        var weather = (IList)json["weather"];
        var weather0 = (IDictionary)weather[0];
        var weather_condition = weather0["main"];
        var main2 = json["main"] as Dictionary<string, object>;
        var temp_min = main2["temp_min"];
        var temp_max = main2["temp_max"];
        int int_temp_min = Convert.ToInt32(temp_min);
        int int_temp_max = Convert.ToInt32(temp_max);
        var city_name = json["name"];
        title.text = "都市:" + city_name.ToString() + "\r\n" + "天気:" + weather_condition.ToString() + "\r\n" + "最高気温:" + int_temp_max.ToString() + "\r\n" + "最低気温:" + int_temp_min.ToString();
        //ログの出力
        Debug.Log(weather_condition);
        Debug.Log(int_temp_max);
        Debug.Log(int_temp_min);
        Debug.Log(city_name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
