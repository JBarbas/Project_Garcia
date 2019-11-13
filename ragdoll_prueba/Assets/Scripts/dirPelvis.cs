using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirPelvis : MonoBehaviour
{
    public Transform camera;
    public Transform parent;
    public float rotateSpeed = 3;
    public float rotationSpeed = 15.0f;

    private bool moving = false;
    private bool rotated = false;
    private Vector3 origin;

    IEnumerator RotatePelvis(float targetRotation)
    {
        //Debug.Log();
        float moveSpeed = 0.1f;
        while (parent.transform.rotation.y < targetRotation)
        {
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, Quaternion.Euler(-90, targetRotation, 0), moveSpeed * Time.time);
            yield return rotated = true;
        }
        parent.transform.rotation = Quaternion.Euler(-90, targetRotation, 0);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float targetRotation = camera.transform.eulerAngles.y;

        if (moving)
        {
            Vector3 currentPos = transform.position;
            transform.position = origin;
            
            if (rotated)
            {
                //parent.transform.rotation = Quaternion.Euler(-90, targetRotation, 0);
                Quaternion desiredRotation = Quaternion.Euler(-90, targetRotation-180, 0);
                parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
                //parent.transform.Rotate(0, 0, 180, Space.Self);
            }
            transform.position = currentPos;
        }

        if (Input.GetKeyDown("w"))
        {
            if(!moving)
            {
                //StartCoroutine(RotatePelvis(targetRotation-180));
            }
            moving = true;
            rotated = true;
        }
        else if (Input.GetKeyUp("w"))
        {
            moving = false;
            rotated = false;
        }
    }
}
