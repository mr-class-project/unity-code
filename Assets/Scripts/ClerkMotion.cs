using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerkMotion : MonoBehaviour
{
    private int RemainTime = 500;
    private bool isThinking = false;
    private bool isIdlingB = false;
    private bool isLooking = false;
    private bool isSwitching = false;
    public bool isWaving = false;

    public void isWavingTrue()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isWaving", true);
        animator.SetBool("isThinking", false);
        animator.SetBool("isIdlingB", false);
        animator.SetBool("isLooking", false);
        animator.SetBool("isSwitching", false);
    }
    void ChangeMotion()
    {
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        Animator animator = GetComponent<Animator>();

        //あらかじめ設定していたboolパラメーターの値を取り出す.
        isThinking = animator.GetBool("isThinking");
        isIdlingB = animator.GetBool("isIdlingB");
        isLooking = animator.GetBool("isLooking");
        isSwitching = animator.GetBool("isSwitching");

        if (isWaving)
        {
            isThinking = false;
            isIdlingB = false;
            isLooking = false;
            isSwitching = false;
        }
        else if (isThinking || isIdlingB || isLooking || isSwitching)
        {
            isThinking = false;
            isIdlingB = false;
            isLooking = false;
            isSwitching = false;
        }
        else
        {
            double num = Random.value;
            if(num < 0.25)
            {
                isThinking = true;
            }
            else if (num < 0.50)
            {
                isIdlingB = true;
            }
            else if (num < 0.75)
            {
                isLooking = true;
            }
            else
            {
                isSwitching = true;
            }
        }

        //boolパラメーターの値を設定する.
        animator.SetBool("isThinking", isThinking);
        animator.SetBool("isIdlingB", isIdlingB);
        animator.SetBool("isLooking", isLooking);
        animator.SetBool("isSwitching", isSwitching);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemainTime--;
        if(RemainTime < 0)
        {
            RemainTime += 500;
            ChangeMotion();
        }
    }
}
