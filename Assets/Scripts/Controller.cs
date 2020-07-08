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
    private string weather;
    private string hour;

    void SaveDataBase()
    {
        //db.GetComponent<DataBase>().order_num++;
    }
    void OutputTextDisplay()
    {
        td.GetComponent<TextMesh>().text = "まいどー！";
    }
    void OutputClerkMotion()
    {
        cm.isWavingTrue();

    }
    // Start is called before the first frame update
    void Start()
    {
        //APIから取得
        weather = wa.GetComponent<WeatherApi>().weather_condition;
        hour = da.GetComponent<DateApi>().hour;
    }

    // Update is called once per frame
    void Update()
    {
        SaveDataBase();
        OutputTextDisplay();
        OutputClerkMotion();
    }
}
