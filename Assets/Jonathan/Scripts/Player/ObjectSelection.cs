using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    private float reachRange;//The reach range from the player to the object
    private Renderer selectionRenderer;//Renderer of the obj
    public Material defaultMaterial;//Original material obj has, before it is looked at
    public Material selectedItemMaterial;//Material given to obj after it is picked up
    private bool highlighted;//It returns whether the object is being looked upon or not
    private bool pickedUp;
    RaycastHit hit;


    void Awake()
    {
        reachRange = GameObject.Find("PlayerHands").GetComponent<PickUpObj>().reachRange;
        highlighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        pickedUp = GameObject.Find("PlayerHands").GetComponent<PickUpObj>().pickedUp;

        if (!Physics.Raycast(ray, out hit, reachRange)) { objectNotSelected(); } // Shoots out a raycast from the player's point of view
        objectSelected();

    }

    private void objectSelected()
    {
        //if (!hit.collider.CompareTag("PickUpObject") || highlighted) return;
        if (hit.collider != null)
        {
            if ((hit.collider.tag == "PickUpObject") && !highlighted)
            { //if the raycastHit collides with an object with give tag of "PickUpObject"...

                highlighted = true;
                selectionRenderer = hit.transform.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                selectionRenderer.material = selectedItemMaterial;
            }
        }
        
    }

    void objectNotSelected()
    {
        //if(highlighted && !hit.collider.tag.Equals(")
        if (!highlighted || pickedUp) return;

        highlighted = false;
        selectionRenderer.material = defaultMaterial;
    }
}
