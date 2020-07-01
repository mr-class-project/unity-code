using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;

public class MainCharController : MonoBehaviour
{
    Animation anim;

    private WebSocket ws_;

    private string order = "";

    // Use this for initialization
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
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

        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        Animator animator = GetComponent<Animator>();

        //あらかじめ設定していたintパラメーター「trans」の値を取り出す.
        //int param = animator.GetInteger("param");

        //あらかじめ設定していたboolパラメーター「isJump」「isRun」「isKiik」「isLook」の値を取り出す.
        bool isJump = animator.GetBool("isJump");
        bool isRun = animator.GetBool("isRun");
        bool isKiik = animator.GetBool("isKiik");
        bool isLook = animator.GetBool("isLook");

        if (order.Contains("ジャンプ"))
        {
            isJump = true;
            Debug.Log(isJump);
        }
        else if (order.Contains("ストップ"))
        {
            isJump = false;
            isRun = false;
            isKiik = false;
            isLook = false;
            Debug.Log(isJump);
            Debug.Log(isRun);
            Debug.Log(isKiik);
            Debug.Log(isLook);
        }
        else if (order.Contains("走れ"))
        {
            isRun = true;
            Debug.Log(isRun);
        }
        else if (order.Contains("キック"))
        {
            isKiik = true;
            Debug.Log(isKiik);
        }
        else if (order.Contains("探す"))
        {
            isLook = true;
            Debug.Log(isLook);
        }

        /*
        //上矢印キーを押した際にパラメータ「trans」の値を増加させる.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            param++;
            Debug.Log(param);
        }

        //下矢印キーを押した際にパラメータ「trans」の値を減少させる.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            param--;
            Debug.Log(param);
        }
        */

        //intパラメーターの値を設定する.
        //animator.SetInteger("param", param);

        //boolパラメーターの値を設定する.
        animator.SetBool("isJump",isJump);
        animator.SetBool("isRun",isRun);
        animator.SetBool("isKiik",isKiik);
        animator.SetBool("isLook",isLook);

    }
}