using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public GameObject TextObject;
    private bool isFadeout = false;
    float red, green, blue, alpha;
    float speed = 0.003f;

    public void Display(string s)
    {
        GetComponent<TextMesh>().text = s;
        ReStart();
    }

    public void Display(string s,int money)
    {
        GetComponent<TextMesh>().text = s + " " + money.ToString() + "円";
        ReStart();
    }

    void Fadeout()
    {
        alpha -= speed;
        GetComponent<TextMesh>().color = new Color(red,green,blue,alpha);
        if (alpha < 0)
        {
            isFadeout = false;
        }
    }

    void ReStart()
    {
        red = GetComponent<TextMesh>().color.r;
        green = GetComponent<TextMesh>().color.g;
        blue = GetComponent<TextMesh>().color.b;
        alpha = 1.0f;
        isFadeout = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeout) Fadeout();
    }
}
