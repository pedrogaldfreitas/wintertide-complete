using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] [HideInInspector] public bool addToInventory; //This variable is going to be activated by the item activation script to verify that an item has been found
    [HideInInspector] public int newItem; //This variable is going to be used to see which item will be activated next (phone comes by default, then card, then machete.)
    public GameObject phone;
    public GameObject card;
    public GameObject machete;
    public string itemCheck; //This variable is used to determine which item you have equipped at the moment
    public bool isAttacking;
    private bool itemPickedUp;
    private bool _isSprinting;

    //Active Verification Array
    public bool[] activeVerification;//Change in inspector

    private void Awake()
    {
        itemCheck = "N/A";
        addToInventory = false;
        newItem = -1;
        isAttacking = false;
        itemPickedUp = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //sprinting();

        itemPickedUp = GameObject.Find("PlayerHands").GetComponent<PickUpObj>().pickedUp;
        _isSprinting = this.gameObject.GetComponentInParent<playerMovement>().isSprinting;

        ///This is used for determining when an obj is being picked up
        if (itemPickedUp || _isSprinting)
        {
            disableAllItems();

        }
        else if (!itemPickedUp || _isSprinting)
        {
            if (itemCheck == "Phone")
            {
                phone.active = true;
            }
            else if (itemCheck == "Card")
            {
                card.active = true;
            }
            else if (itemCheck == "Machete")
            {
                machete.active = true;
            }

        }
        //This is used for checking when the machete is attacking
        if ((activeVerification[2]) && (itemCheck.Equals("Machete")))//CHANGE THE 0 TO 2 AFTER YOU'RE DONE TESTING!!!
        {
            isAttacking = GameObject.Find("Machete").GetComponent<macheteScript>().isAttacking;
        }
        //If machete is not attacking, then you will be able to swtich items
        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (itemCheck.Equals("Phone") && activeVerification[2])
                {
                    //Switch to machete
                    disableAllItems();
                    itemCheck = "Machete";
                    machete.active = true;
                } else if (itemCheck.Equals("Machete") && activeVerification[0])
                {
                    disableAllItems();
                    itemCheck = "Phone";
                    phone.active = true;
                }
            }

            /*
            if (Input.GetKeyDown(KeyCode.Alpha1) && !itemCheck.Equals("Phone") && activeVerification[0])
            {
                //Pull out Phone
                disableAllItems();
                itemCheck = "Phone";
                phone.active = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2) && !itemCheck.Equals("Card") && activeVerification[1])
            {
                //Pull out Card
                disableAllItems();
                itemCheck = "Card";
                card.active = true;

            }

            else if (Input.GetKeyDown(KeyCode.Alpha3) && !itemCheck.Equals("Machete") && activeVerification[2])
            {
                //Pull out Machete
                disableAllItems();
                itemCheck = "Machete";
                machete.active = true;

            }*/
        }

        if (addToInventory)
        {
            checkForEquipping();
        }
        newItem = -1;
    }

    /// <summary>
    /// This method is used to hide all objects if the player starts sprinting
    /// </summary>
    private void sprinting()
    {
        var _isSprinting = GameObject.Find("Player").GetComponent<playerMovement>().isSprinting;
        if (!_isSprinting) return;

        itemCheck = "N/A";
        disableAllItems();
    }

    private void disableAllItems()
    {
        phone.active = false;
        card.active = false;
        machete.active = false;
    }

    //This method equips the item to the inventory
    private void checkForEquipping()
    {
        addToInventory = false;

        if (newItem == 0)
        {
            activeVerification[newItem] = true; //Equipped new item
        }

        if (newItem == 1)
        {
            activeVerification[newItem] = true; //Equipped new item
        }

        if (newItem == 2)
        {
            activeVerification[newItem] = true;
        }

    }

}
