using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    ///When this script is enabled by the interaction script
    ///the item will be stored in its corresponding Inventory -> GameObject variable.
    ///
    [SerializeField]
    GameObject statue;

    private void Update()
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().addToInventory = true;
        if (this.gameObject.name.Equals("Phone(Item)"))
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().newItem = 0;
        }
        else if (this.gameObject.name.Equals("Card(Item)"))
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().newItem = 1;
            statue.SetActive(true);

        }
        else if (this.gameObject.name.Equals("Machete(Item)"))
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().newItem = 2;
            StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag10"));
        }
        //Debug.Log("Destroy");
        Destroy(this.gameObject);   
    }
}
