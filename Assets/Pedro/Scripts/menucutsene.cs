using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menucutsene : MonoBehaviour
{
    [SerializeField]
    GameObject playbutton;
    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject sfu;
    [SerializeField]
    GameObject ournames;

    private void Start()
    {
        title.GetComponent<TMP_Text>().color -= new Color(0f, 0f, 0f, 1f);
        //title.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 1f);
        sfu.GetComponent<Image>().color -= new Color(0f, 0f, 0f, 1f);
        //ournames.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 1f);
        ournames.GetComponent<TMP_Text>().color -= new Color(0f, 0f, 0f, 1f);
        playbutton.GetComponent<TMP_Text>().color -= new Color(0f, 0f, 0f, 1f);
        //playbutton.GetComponent<Image>().color -= new Color(0f, 0f, 0f, 1f);
        playbutton.SetActive(false);
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        yield return StartCoroutine(FadeInText(ournames));
        yield return StartCoroutine(wait(3f));
        yield return StartCoroutine(FadeOutText(ournames));
        yield return StartCoroutine(wait(2f));
        yield return StartCoroutine(FadeIn(sfu));
        yield return StartCoroutine(wait(1f));
        yield return StartCoroutine(FadeInText(title));
        yield return StartCoroutine(wait(1f));
        playbutton.SetActive(true);
        yield return StartCoroutine(FadeInText(playbutton));

    }

    IEnumerator FadeInText(GameObject obj)
    {
        TMP_Text text = obj.GetComponent<TMP_Text>();
        for (float i = 0f; i <= 1f; i += 0.007f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            text = obj.GetComponent<TMP_Text>();
            yield return new WaitForSeconds(0.01f);

        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
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

    IEnumerator FadeIn(GameObject obj)
    {
        for (float i = 0f; i <= 1f; i += 0.007f)
        {
            obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, 1f);
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
