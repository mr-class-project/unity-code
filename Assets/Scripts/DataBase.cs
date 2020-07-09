using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public int hamburger = 0;
    public int hotdog = 0;
    public int sandwich = 0;
    public int potato = 0;
    public int cola = 0;
    public int total_money = 0;
    public int recommend = 0;

    public void SaveDataBase(string s, int money, int num)
    {
        GetComponent<DataBase>().total_money += money;
        if (s == "ハンバーガー")
        {
            GetComponent<DataBase>().hamburger += num;
        }
        else if (s == "ホットドッグ")
        {
            GetComponent<DataBase>().hotdog += num;
        }
        else if (s == "サンドウィッチ")
        {
            GetComponent<DataBase>().sandwich += num;
        }
        else if (s == "ポテト")
        {
            GetComponent<DataBase>().potato += num;
        }
        else if (s == "コーラ")
        {
            GetComponent<DataBase>().cola += num;
        }
        else
        {
            GetComponent<DataBase>().recommend += num;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // データベース変数の読み込み
        //order_num = PlayerPrefs.GetInt("HAMBURGER", 0);
        //order_num = PlayerPrefs.GetInt("HOTDOG", 0);
        //order_num = PlayerPrefs.GetInt("COLA", 0);
        //order_num = PlayerPrefs.GetInt("HOTCOFFEE", 0);
        //order_num = PlayerPrefs.GetInt("ICECREAM", 0);

    }
    // 削除時の処理
    void OnDestroy()
    {
        // データベースに保存
        //PlayerPrefs.SetInt("HAMBURGER", hamburger);
        //PlayerPrefs.SetInt("HOTDOG", hotdog);
        //PlayerPrefs.SetInt("COLA", cola);
        //PlayerPrefs.SetInt("HOTCOFFEE", hotcoffee);
        //PlayerPrefs.SetInt("ICECREAM", icecream);
        //PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
