using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAC : InteractiveItem
{
    override
    public void onInteract()
    {
        interactionText.text = "";
        Instantiate(Resources.Load("Prefabs/gorra"));
        PlayerInventory.equipedDAC = itemName;
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
        if (other.gameObject.tag == "Player")
        {
            interactionText.text = "";
        }
    }
}
