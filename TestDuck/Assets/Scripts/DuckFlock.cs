using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFlock : MonoBehaviour
{

    // velocidad
    private float speed;
    public float minSpeed = 0.5f;
    public float maxSpeed = 1f;

    // Velocidad de rotación
    private float rotSpeed = 10f;

    Vector3 averageHeadingDir;
    Vector3 averagePosition;
    float neighbourDistance = 5f;

    // 
    private NavMeshAgent agent;

    // Variables auxiliares para gizmos
    private Vector3 vCenterGizmo;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, GlobalFlock.objective) >= GlobalFlock.spawnZone)
        {
            Vector3 direction = GlobalFlock.objective - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1f);
        }
        else
        {
            // 1 de cada 5 frames, aplicamos las reglas de comportamiento
            if (Random.Range(0f, 5f) < 1)
                applyFlockRules();
        }
        

        transform.Translate(GlobalFlock.spawnPoint.x, GlobalFlock.spawnPoint.y, Time.deltaTime * speed);
    }


    private void applyFlockRules()
    {
        List<GameObject> gameObjects = GlobalFlock.allDucks;

        // Vectores que apuntan al centro de la bandada y evitar vecinos
        Vector3 vCenter = GlobalFlock.objective;
        Vector3 vAvoid = GlobalFlock.objective;
        float groupSpeed = 0.5f;

        Vector3 goalPosition = GlobalFlock.objective;

        float dist;
        gameObjects.Add(GameObject.FindGameObjectWithTag("Player"));
        foreach(GameObject gO in gameObjects)
        {
            if(gO != this.gameObject && gO != GameObject.FindGameObjectWithTag("Player"))
            {
                dist = Vector3.Distance(gO.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vCenter += gO.transform.position;

                    if (dist < 1.5f)
                    {
                        vAvoid += (this.transform.position - gO.transform.position);
                    }

                    DuckFlock otherFlock = gO.GetComponent<DuckFlock>();
                    groupSpeed += otherFlock.speed;
                }
            }
        }
        vCenter = vCenter / GlobalFlock.numDucks + (goalPosition - this.transform.position);
        speed = groupSpeed / GlobalFlock.numDucks;

        vCenterGizmo = vCenter;

        Vector3 direction = (vCenter + vAvoid) - transform.position;
        if (direction != GlobalFlock.objective)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.TransformPoint(vCenterGizmo), 0.1f);

    }

}
