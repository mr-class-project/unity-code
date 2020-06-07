using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;

public class AskWeather : MonoBehaviour
{

    private WebSocket ws_;
    // 質問 (最高気温, 最低気温, 天気を含む文字列に反応させて, APIの結果を表示する。
    private String question;

    public GameObject gameobject;

    // Start is called before the first frame update
    void Start()
    {
        // unity 走らせる前にNodeのサーバー建てる
        ws_ = new WebSocket("ws://127.0.0.1:12002");
        ws_.OnMessage += (sender, e) => {
            question = e.Data;
        };
        ws_.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        String answer = "";

        if (question.Contains("最高気温"))
        {
            answer = "今日の最高気温は, " + gameobject.GetComponent<WeatherApi>().temp_max.ToString();
        } else if (question.Contains("最低気温"))
        {
            answer = "今日の最低気温は, " + gameobject.GetComponent<WeatherApi>().temp_max.ToString();
        }
        else if (question.Contains("天気"))
        {
            answer = "今日の天気は, " + gameobject.GetComponent<WeatherApi>().weather_condition;
        }

        // GameObjectにTextMeshがついてる想定 (答えを表示するテキストボックス)
        gameobject.GetComponent<TextMesh>().text = answer;
    }
}
