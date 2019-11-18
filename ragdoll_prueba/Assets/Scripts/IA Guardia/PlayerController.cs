using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public bool debugMode = false;
    /*state = ["patrullando", "persiguiendo", "buscando"]*/
    public string state = "patrullando";
    public Vector3 lastPosPlayer;
    public float speed = 3.0F;
    public float rotateSpeed = 1.5F;
    public Transform target;
    public Transform nextPoint;
    public int actualPoint = 0; //waypoint actual
    public GameObject player;
    NavMeshAgent _agent;    

    void Start()
    {
        
        if (player == null)
        {
            player = this.gameObject;
        }
        _agent = this.GetComponent<NavMeshAgent>();

        /*Asignamos el primer punto de su patrulla*/
        nextPoint = target.GetChild(actualPoint);
        transform.Rotate(new Vector3(nextPoint.position.x, 0, nextPoint.position.z));
        _agent.SetDestination(new Vector3(nextPoint.position.x, 0, nextPoint.position.z));
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        /*
        //movimiento continuo
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

        // moverse hacia delante
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        */

        //mover guardia con raton
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                _agent.SetDestination(hit.point);
            }
        }*/

        switch (state)
        {
            case "patrullando":

                if (player.transform.position.x == nextPoint.position.x && player.transform.position.z == nextPoint.position.z)
                {

                    if (actualPoint < target.childCount - 1)
                    {
                        actualPoint++;
                    }
                    else
                    {
                        actualPoint = 0;
                    }
                    if (debugMode)
                    {
                        Debug.Log("Siguiente waypoint: "+actualPoint);
                    }

                    nextPoint = target.GetChild(actualPoint);
                }
                transform.Rotate(new Vector3(nextPoint.position.x, 0, nextPoint.position.z));
                _agent.SetDestination(new Vector3(nextPoint.position.x, 0, nextPoint.position.z));
                break;

            case "persiguiendo":

                if (debugMode)
                {
                    Debug.Log("persigue");
                }

                transform.Rotate(lastPosPlayer);
                _agent.SetDestination(lastPosPlayer);
                break;

            case "buscando":
                state = "patrullando";
                break;
            
            default:

                if (debugMode)
                {
                    Debug.Log("Sin estado reconocido");
                }
                break;
        } 
    }
}
