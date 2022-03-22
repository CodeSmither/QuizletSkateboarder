using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownAnimations : MonoBehaviour
{
    private GameObject Numbers;
    private int NumberValue;
    public Text NumberValueText;
    

    private void Awake()
    {
        Numbers = GameObject.Find("CountDownTimer");
    }

    private void OnEnable()
    {
        NumberValue = 3;
        LeanTween.scale(Numbers, new Vector3(1, 1, 1), 0f).setOnComplete(ShrinkingText);
    }
    private void FixedUpdate()
    {
        if (NumberValue > 0)
        {
            NumberValueText.text = NumberValue.ToString();
        }
        else if(NumberValue == 0)
        {
            NumberValueText.text = "Go!";
        }
    }
    private void ShrinkingText()
    {
        LeanTween.scale(Numbers, Vector3.zero, 1f).setOnComplete(SizeReset);
    }
    private void SizeReset()
    {
        NumberValue -= 1;
        if(NumberValue > -1)
        {
            LeanTween.scale(Numbers, new Vector3(1, 1, 1), 0f).setOnComplete(ShrinkingText);
        }
    }
}
