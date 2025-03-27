using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OnClickButton : MonoBehaviour
{



    public void OnClickMainScreenButton()
    {
        StartCoroutine(actualFunction());        
    }

    IEnumerator actualFunction()
    {
        StartCoroutine(FadeOut(GameObject.Find("sfu logo")));
        StartCoroutine(FadeOutText(GameObject.Find("WintertideText")));
        yield return StartCoroutine(FadeOutText(GameObject.Find("Button")));

        SceneManager.LoadScene("busStop");
    }

    IEnumerator FadeOut(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.007f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, 0f);
    }

    IEnumerator FadeOutText(GameObject obj)
    {
        TMP_Text text = obj.GetComponent<TMP_Text>();
        for (float i = 1f; i >= 0f; i -= 0.007f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            text = obj.GetComponent<TMP_Text>();
            yield return new WaitForSeconds(0.01f);
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
    }

}
