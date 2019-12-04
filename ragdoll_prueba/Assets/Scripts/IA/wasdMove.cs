using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMove : MonoBehaviour
{
    public float speed = 7.0f;
    private bool dead = false;
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

    public void morir()
    {
        dead = true;
        Debug.Log("Muerto");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Security"))
        {
            if (other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Golpear"))
            {
                morir();
            }
        }
    }
}
