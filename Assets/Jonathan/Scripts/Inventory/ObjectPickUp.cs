using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] private float reachRange;
    [SerializeField] private float radius;
    private RaycastHit hit;

    private void Update()
    {
        //if (!Input.GetKeyDown(KeyCode.E)) return;
        pickUpObj();
    }
    private void pickUpObj()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.SphereCast(ray, radius, out hit, reachRange) || !hit.collider.CompareTag("Item")) return;
        Debug.Log("Name of object" + hit.collider.name);
        hit.collider.gameObject.GetComponent<ActivationScript>().enabled = true;

        Debug.Log("item is here");

    }

    private void OnDrawGizmosSelected()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.red);
        Gizmos.DrawWireSphere(ray.origin + ray.direction * reachRange, radius);
    }
}
