using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirPelvis : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider caps;

    public Transform camera;
    public Transform parent;
    public float rotateSpeed = 3;
    public float rotationSpeed = 15.0f;
    public float jumpForce = 5;
    public float walkSpeed = 100;
    public float runSpeed = 500;

    private bool moving = false;
    private bool rotated = false;
    private bool jumping = false;
    private bool running = false;
    private Vector3 origin;
    private bool moveFront = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveBack = false;

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
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetRotation = camera.transform.eulerAngles.y;

        if (Input.GetKeyDown("w"))
        {
            moveFront = true;
        }
        else if (Input.GetKeyUp("w"))
        {
            moveFront = false;
        }
        if (Input.GetKeyDown("a"))
        {
            moveLeft = true;
        }
        else if (Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }
        if (Input.GetKeyDown("s"))
        {
            moveBack = true;
        }
        else if (Input.GetKeyUp("s"))
        {
            moveBack = false;
        }
        if (Input.GetKeyDown("d"))
        {
            moveRight = true;
        }
        else if (Input.GetKeyUp("d"))
        {
            moveRight = false;
        }
        if (Input.GetKeyDown("space") && !jumping)
        {
            jumping = true;
            jump();
        }
        if (Input.GetKeyDown("left shift"))
        {
            running = true;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            running = false;
        }

        float direction = 0;
        if (moveBack) direction = 180;
        if (moveLeft)
        {
            direction += -90;
            if (moveFront) direction += 45;
            if (moveBack) direction += 135;
        }
        if (moveRight)
        {
            direction += 90;
            if (moveFront) direction += -45;
            if (moveBack) direction += -135;
        }

        if (moveFront || moveLeft || moveBack || moveRight)
        {
            Vector3 currentPos = transform.position;
            transform.position = origin;
            Quaternion desiredRotation = Quaternion.Euler(-90, targetRotation-180+direction, 0);
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            transform.position = currentPos;
        }
    }

    private void FixedUpdate()
    {
        if (running)
        {
            rb.AddForce(new Vector3(-transform.forward.x, 0, -transform.forward.z) * runSpeed);
        }
        else if (moving)
        {
            rb.AddForce(new Vector3(-transform.forward.x, 0, -transform.forward.z) * walkSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11 && jumping)
        {
            jumping = false;
        }
    }

    void jump()
    {
        rb.AddForce(new Vector3(0, jumpForce * 100, 0), ForceMode.Impulse);
    }
}
