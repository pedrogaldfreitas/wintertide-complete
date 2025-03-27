using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
//using TMPro;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    /// <summary>
    /// Use Raycasts with a finite distance to determine how far an object is, if it collides with the raycast
    /// then player will be able to pick up and throw the object by pressing Mouse1 "Right Click"
    /// </summary>
    /// 

        //PEDRO'S VARIABLES
    public bool diagDisplayedFlag1;
    public bool diagDisplayedFlag2;

    //JONATHAN'S VARIABLES
    public bool pickedUp;
    private Transform playerHands;
    private Transform intObjTransform;
    public Transform crosshair;
    private Rigidbody intObjRb;
    private Collider intObjCollider;
    private float radiusOfPickup; //Determines how far away the object can be on the x or z axis before it is automatically dropped.
    private float disZ; //Difference between the distances of the object and the crosshair (on z axis)
    private float disX; //Difference between the distances of the object and the crosshair (on x axis)
    [Range(0, 15)] public float speedOfGravity;
    [Range(0, 15)] public float throwingForce;
    [Range(0, 15)] public float reachRange;
    [Range(0, 5)] public float objHoldRange;
    RaycastHit hit;

    void Start()
    {
        pickedUp = false;
        playerHands = this.gameObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        pickUpPhysics();

        pickUpCheck();
    }

    private void pickUpPhysics()
    {
        if (rayCastCollision() && !pickedUp)
        {
            ///When picking up the object: 
            ///*flags the action as true
            ///angular velocity becomes 0
            ///Gravity on object is deactivated
            ///and freezes the object rotation.
            ///Changes mass of object to 0
            ///

            //PEDRO CODE
            if (diagDisplayedFlag2 == false)
            {
                StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag5"));
                diagDisplayedFlag2 = true;
            }

            pickedUp = true;
            intObjRb.angularVelocity = Vector3.zero;
            intObjRb.useGravity = false;
            freezeObjRotation();
            intObjRb.mass = 0;

        }

        else if ((Input.GetKeyDown(KeyCode.Mouse0) && pickedUp))
        {
            ///When Throwing the object:
            ///flags action as false
            ///Gets rid of the rotation freeze
            ///Gravity is activated for the object, once again.
            ///Object gets thrown forward
            ///Changes mass of object back to 1
            ///

            pickedUp = false;
            unfreezeObjRotation();
            intObjRb.useGravity = true;
            intObjRb.velocity = throwingForce * (playerHands.forward);
            intObjRb.mass = 1;

        }

        else if ((Input.GetKeyDown(KeyCode.E) && pickedUp))
        {
            ///When Throwing the object:
            ///flags action as false
            ///Gets rid of the rotation freeze
            ///Gravity is activated for the object, once again.
            ///Object gets thrown forward
            ///Changes mass of object back to 1
            ///

            pickedUp = false;
            unfreezeObjRotation();
            intObjRb.useGravity = true;
            intObjRb.mass = 1;

        }

        ///This determines the holding range the player has over the 
        ///picked up obj
        else if ((disZ > objHoldRange) || (disX > objHoldRange))
        {
            pickedUp = false;
            unfreezeObjRotation();
            intObjRb.useGravity = true;
            intObjRb.mass = 1;
        }
    }

    private void pickUpCheck()
    {
        if (pickedUp)
        {
            intObjRb.velocity = speedOfGravity * (playerHands.position - intObjTransform.position);
            disZ = Mathf.Abs(intObjTransform.position.z - crosshair.position.z);
            disX = Mathf.Abs(intObjTransform.position.x - crosshair.position.x);

        }
    }

    bool rayCastCollision()
    {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //.DrawRay(ray.origin, ray.direction * reachRange, Color.red);
            if(Physics.Raycast(ray, out hit, reachRange)) 
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.tag == "PickUpObject")
                {
                    // ************* PEDRO CODE *******************
                    if (diagDisplayedFlag1 == false)
                    {
                        StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag1"));
                        diagDisplayedFlag1 = true;
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //variables occupate the transform and rigidbody properties of the obj.
                        intObjTransform = hit.transform;
                        intObjRb = hit.rigidbody;
                        intObjCollider = hit.collider;
                        return true;
                    }
                }
            }
        
        return false;
    }

    void freezeObjRotation()
    {
        intObjRb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void unfreezeObjRotation()
    {
        intObjRb.constraints = RigidbodyConstraints.None;
    }

}
