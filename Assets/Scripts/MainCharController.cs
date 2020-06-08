using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCharController : MonoBehaviour
{
    Animation anim;

    // Use this for initialization
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {

        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        Animator animator = GetComponent<Animator>();

        //あらかじめ設定していたintパラメーター「trans」の値を取り出す.
        int param = animator.GetInteger("param");

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

        //intパラメーターの値を設定する.
        animator.SetInteger("param", param);

    }
}