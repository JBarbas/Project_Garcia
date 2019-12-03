using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveItem
{

    public float kickForce = 50f;
    public bool needsKey = false;

    override
    public void onInteract()
    {
        interactionText.text = "";
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(-kickForce, 0, 0), GetComponentInParent<Transform>().position + new Vector3(0,1,0));
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            if (other.gameObject.tag == "Agent Garcia" && (PlayerInventory.hasKey || !needsKey))
            {
                interactionText.text = LocalizationManager.instance.getValue(itemName);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    onInteract();
                }

            }
            else if (other.gameObject.tag == "Agent Garcia" && needsKey)
            {
                interactionText.text = "You need a Key Card to open this door";
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
