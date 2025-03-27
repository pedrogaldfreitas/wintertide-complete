using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDisappears : MonoBehaviour
{
    private RaycastHit hit;
    private float reachRange = 200f;
    private bool playerCollide;// variable that determines whether the player is standing past the statue or not

    void Update()
    {
        var pOV = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(pOV, out hit,reachRange) || !playerCollide || !hit.collider.tag.Equals("Boundary")) return; 

        GameObject.Find("Statue").GetComponent<ActivateStatue>().enabled = true;

        this.gameObject.GetComponent<StatueDisappears>().enabled = false; //Disables this script

        
    }
    private void OnTriggerStay(Collider other)
    {
        playerCollide = false;

        if (other.tag != "StatueActivation")return;

        playerCollide = true;
        
    }
}
