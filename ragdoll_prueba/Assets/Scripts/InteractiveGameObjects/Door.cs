using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveItem
{

    public float kickForce = 50f;

    override
    public void onInteract()
    {
        interactionText.text = "";
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(-kickForce, 0, 0), GetComponentInParent<Transform>().position + new Vector3(0,1,0));
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia" && PlayerInventory.hasKey)
        {
            interactionText.text = text + " " + itemName;
            if (Input.GetKeyDown(KeyCode.E))
            {
                onInteract();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agent Garcia")
        {
            interactionText.text = "";
        }
    }
}
