using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteCollisionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("scaffolding").GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
