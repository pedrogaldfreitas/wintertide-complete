using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hintScript : MonoBehaviour
{

    public string hint1;
    public string hint2;
    public string hint3;
    public string hint4;
    public string hint5;
    private int hintToDisplayInt;
    private string hintToDisplay;


    // Start is called before the first frame update
    void Start()
    {
        hintToDisplayInt = Random.Range(1, 6);
        switch (hintToDisplayInt)
        {
            case 1:
                hintToDisplay = hint1;
                break;
            case 2:
                hintToDisplay = hint2;
                break;
            case 3:
                hintToDisplay = hint3;
                break;
            case 4:
                hintToDisplay = hint4;
                break;
            case 5:
                hintToDisplay = hint5;
                break;
        }

        GetComponent<Text>().text = hintToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
