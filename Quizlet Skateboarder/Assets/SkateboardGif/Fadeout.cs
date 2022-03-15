using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    Image MySpriteRender;
    float FinishedAlpha;
    float duration;

    // Update is called once per frame
    private void OnEnable()
    {
        MySpriteRender = gameObject.GetComponent<Image>();
        FinishedAlpha = 1;
        duration = 1;
        StartCoroutine(FadingSprite(MySpriteRender, FinishedAlpha,duration));
    }
    public IEnumerator FadingSprite(Image sr, float EndValue, float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, EndValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;

        }
    }
    
}
