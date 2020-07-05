using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Textを使用する為追加。
using System; //DateTimeを使用する為追加。

public class DateApi : MonoBehaviour
{
    //外部スクリプトからの取得用変数
    public string month; //月
    public string day; //日
    public string hour_min; //時分

    //DateTimeを使うため変数を設定
    DateTime TodayNow;

    // Start is called before the first frame update
    void Start()
    {
        //時間を取得
        TodayNow = DateTime.Now;
        month = TodayNow.Month.ToString();
        day = TodayNow.Day.ToString();
        hour_min = TodayNow.ToShortTimeString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
