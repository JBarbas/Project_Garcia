using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : InteractiveItem
{
    override
    public void onInteract()
    {
        interactionText.text = "";
        Color temp = interactionImage.color;
        temp.a = 1f;
        interactionImage.color = temp;
        PlayerInventory.hasKey = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionText.text = text + " " + itemName;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
