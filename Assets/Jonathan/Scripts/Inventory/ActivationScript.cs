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
            CardPickupConsequences();
        }
        else if (this.gameObject.name.Equals("Machete(Item)"))
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().newItem = 2;
            GameObject.Find("Crosshair").GetComponent<objectInteraction>().MachetePickupDiag();
        }
        //Debug.Log("Destroy");
        Destroy(this.gameObject);   
    }

    private void CardPickupConsequences()
    {
        //1. Door slamming sound (ONLY works when there is the third audio source, being the door slam sound.)
        GameObject.Find("AmbienceSound").GetComponents<AudioSource>()[2].Play();

        //2. Scary music (ONLY works when there is the second audio source, being the monolith music.)
        GameObject.Find("AmbienceSound").GetComponents<AudioSource>()[1].Play();

        //3. Text

    }
}
