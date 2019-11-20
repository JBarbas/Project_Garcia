using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMove : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);


        transform.position += move * speed * Time.deltaTime;

    }
}
