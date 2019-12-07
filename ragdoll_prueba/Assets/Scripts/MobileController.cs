using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{

    public dirPelvis pelvis;
    public static bool mouseDown;
    public float timeMouseDown;
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void downW()
    {
        pelvis.setMoveFront(true);
    }

    public void upW()
    {
        pelvis.setMoveFront(false);
    }

    public void downS()
    {
        pelvis.setMoveBack(true);
    }

    public void upS()
    {
        pelvis.setMoveBack(false);
    }

    public void downA()
    {
        pelvis.setMoveLeft(true);
    }

    public void upA()
    {
        pelvis.setMoveLeft(false);
    }

    public void downD()
    {
        pelvis.setMoveRight(true);
    }

    public void upD()
    {
        pelvis.setMoveRight(false);
    }

    void Update()
    {
        if (mouseDown)
            timeMouseDown += Time.deltaTime;
    }

    void OnPointerDown()
    {
        switch (key)
        {
            case "w":
                downW();
                break;
            case "a":
                downA();
                break;
            case "s":
                downS();
                break;
            case "d":
                downD();
                break;
            default:
                break;
        }
    }
    void OnPointerUp()
    {
        switch (key)
        {
            case "w":
                upW();
                break;
            case "a":
                upA();
                break;
            case "s":
                upS();
                break;
            case "d":
                upD();
                break;
            default:
                break;
        }
    }
}
