using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : InteractiveItem
{

    override
    public void onInteract()
    {
        interactionText.text = "";
        PlayerInventory.hasKey = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Agent Garcia")
        {
            interactionText.text = LocalizationManager.instance.getValue(itemName); 
            if (Input.GetKeyDown(KeyCode.E)){
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
