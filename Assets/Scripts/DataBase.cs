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
