using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public float force = 4000;
    public Transform arm;
    Rigidbody rb;
    private bool holding = false;
    private bool canHold = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!holding && canHold)
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = collision.rigidbody;
            sp.spring = 12000;
            sp.breakForce = force;
            holding = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HingeJoint hj = arm.GetComponent<HingeJoint>();
        if (!canHold)
        {
            Destroy(this.GetComponent<SpringJoint>());
            holding = false;
            hj.useSpring = false;
        }
        else if (holding)
        {
            hj.useSpring = false;
        }
        else
        {
            hj.useSpring = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            canHold = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            canHold = false;
        }
    }
}
