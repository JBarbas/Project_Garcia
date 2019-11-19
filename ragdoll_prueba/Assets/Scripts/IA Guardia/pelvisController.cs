using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelvisController : MonoBehaviour
{

    public Transform agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(agent.position.x, transform.position.y, agent.position.z);
    }
}
