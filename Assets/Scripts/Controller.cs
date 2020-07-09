using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //インスタンス化
    public VoiceRecognition vr;
    public DataBase db;
    public WeatherApi wa;
    public DateApi da;
    public TextDisplay td;
    public ClerkMotion cm;
    //変数定義
    public string weather;
    public string hour;
    public string recommend_light_food;

    public void RecognitionData(string s, int money, int num)
    {
        db.SaveDataBase(s,money,num);
        td.Display(s,money);
    }
    public void FinishOrder()
    {
        RecommendLightFood(weather,hour);
    }
    public void AcceptRecommend()
    {
        db.SaveDataBase(recommend_light_food, 200, 1);
        td.Display(recommend_light_food, 200);
        Invoke("Account", 3.5f);
    }
    public void RefuseRecommend()
    {
        Account();
    }
    void Account()
    {
        int hamburger = db.GetComponent<DataBase>().hamburger;
        int hotdog= db.GetComponent<DataBase>().hotdog;
        int sandwich = db.GetComponent<DataBase>().sandwich;
        int potato = db.GetComponent<DataBase>().potato;
        int cola = db.GetComponent<DataBase>().cola;
        int total_money = db.GetComponent<DataBase>().total_money;
        int recommend = db.GetComponent<DataBase>().recommend;
        string s = "";
        if(hamburger > 0)
        {
            if (s != "") s = s + "\n";
            s = s + "ハンバーガー" + hamburger.ToString() + "個";
        }
        if (hotdog > 0)
        {
            if (s != "") s = s + "\n";
            s = s + "ホットドッグ" + hotdog.ToString() + "個";
        }
        if (sandwich > 0)
        {
            if (s != "") s = s + "\n";
            s = s + "サンドウィッチ" + sandwich.ToString() + "個";
        }
        if (potato > 0)
        {
            if (s != "") s = s + "\n";
            s = s + "ポテト" + potato.ToString() + "個";
        }
        if (cola > 0)
        {
            if (s != "") s = s + "\n";
            s = s + "コーラ" + cola.ToString() + "個";
        }
        if (recommend > 0)
        {
            if (s != "") s = s + "\n";
            s = s + recommend_light_food + recommend.ToString() + "個";
        }
        if (s != "") s = s + "\n";
        s = s + "合計金額" + total_money.ToString() + "円です";
        td.Display(s);
        cm.isWavingTrue();
        Invoke("Thank",3.5f);
    }
    void RecommendLightFood(string weather, string h)
    {
        int hour = System.Convert.ToInt32(h);
        if (weather == "快晴" || weather == "晴れ")
        {
            if (hour < 8)
            {
                recommend_light_food = "カフェオレ";
            }
            else if (hour < 16)
            {
                recommend_light_food = "アイスコーヒー";
            }
            else
            {
                recommend_light_food = "ホットコーヒー";
            }
        }
        else if (weather == "くもり")
        {
            if (hour < 8)
            {
                recommend_light_food = "アイスクリーム";
            }
            else if (hour < 16)
            {
                recommend_light_food = "クッキー";
            }
            else
            {
                recommend_light_food = "鯛焼き";
            }
        }
        else if (weather == "小雨" || weather == "雨" || weather == "雷雨" || weather == "雪" || weather == "霧" || weather == "不明")
        {
            if (hour < 8)
            {
                recommend_light_food = "ビール";
            }
            else if (hour < 16)
            {
                recommend_light_food = "ワイン";
            }
            else
            {
                recommend_light_food = "焼酎";
            }
        }
        string s = recommend_light_food + "はいかが？";
        td.Display(s);
    }
    void Thank()
    {
        td.Display("まいどー！");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
