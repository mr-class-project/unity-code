using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class VoiceRecognition : MonoBehaviour
{
    //Controllerのインスタンス化
    public Controller c;

    //サーバーの準備
    private WebSocket ws_;
    private string order = "";

    // Start is called before the first frame update
    void Start()
    {
        // unity 走らせる前にNodeのサーバー建てる
        ws_ = new WebSocket("ws://127.0.0.1:12002");
        ws_.OnMessage += (sender, e) =>
        {
            order = e.Data;
        };
        ws_.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        //メニューを注文する時
        if (order.Contains("ハンバーガー"))
        {
            c.RecognitionData(/* 商品名 */ "ハンバーガー", /* 料金 */ 500, /* 個数 */ 1);
        }
        else if (order.Contains("ホットドッグ"))
        {
            c.RecognitionData(/* 商品名 */ "ホットドッグ", /* 料金 */ 400, /* 個数 */ 1);
        }
        else if (order.Contains("サンドウィッチ"))
        {
            c.RecognitionData(/* 商品名 */ "サンドウィッチ", /* 料金 */ 300 ,/* 個数 */ 1);
        }
        else if (order.Contains("ポテト"))
        {
            c.RecognitionData(/* 商品名 */ "ポテト", /* 料金 */ 200, /* 個数 */ 1);
        }
        else if (order.Contains("コーラ"))
        {
            c.RecognitionData(/* 商品名 */ "コーラ", /* 料金 */ 100, /* 個数 */ 1);
        }
        //メニューの注文を終える時
        else if (order.Contains("以上"))
        {
            c.FinishOrder();
        }
        //メニュー注文後、リコメンドする軽食への反応
        else if (order.Contains("お願いします"))
        {
            c.AcceptRecommend();
        }
        else if (order.Contains("結構です"))
        {
            c.RefuseRecommend();
        }

        //デバッグ用
        //上矢印キー
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            c.RecognitionData(/* 商品名 */ "ハンバーガー", /* 料金 */ 500, /* 個数 */ 1);
        }
        //下矢印キー
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            c.FinishOrder();
            //c.RecognitionData(/* 商品名 */ "ホットドッグ", /* 料金 */ 400, /* 個数 */ 1);
        }
        //右印キー
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            c.AcceptRecommend();
            //c.RecognitionData(/* 商品名 */ "コーラ", /* 料金 */ 100, /* 個数 */ 1);
        }
        //左矢印キー
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            c.RefuseRecommend();
        }
    }
}
