using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caminarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            this.GetComponent<Animator>().SetTrigger("caminar");
        }
        else if (Input.GetKeyUp("w"))
        {
            this.GetComponent<Animator>().ResetTrigger("caminar");
            this.GetComponent<Animator>().SetTrigger("parar");
        }

    }
}
