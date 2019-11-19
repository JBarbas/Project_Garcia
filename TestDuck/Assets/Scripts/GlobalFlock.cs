using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{

    // GameObject que se va a mover en bandada
    public GameObject duckPrefab;
    // Distancia máxima con zona de aparición
    public static int spawnZone = 5;
    // Punto donde aparecerá la bandada
    public static Vector3 spawnPoint;
    // Objetivo de la bandada
    public static Vector3 objective;

    // Numero de patos y lista que los almacena
    public static int numDucks = 3;
    public static List<GameObject> allDucks;

    // Jugador
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        spawnPoint = new Vector3(transform.position.x, duckPrefab.GetComponent<MeshCollider>().bounds.size.y / 2, transform.position.z);
        objective = spawnPoint;
        allDucks = new List<GameObject>();
        // Hacemos aparecer el número deseado de patos
        for (int i = 0; i < numDucks; i++)
        {
            Vector3 pos = new Vector3(Random.Range(spawnPoint.x - spawnZone, spawnPoint.x + spawnZone),
                duckPrefab.GetComponent<MeshCollider>().bounds.size.y / 2,
                Random.Range(spawnPoint.z - spawnZone, spawnPoint.z + spawnZone));
            allDucks.Add((GameObject)Instantiate(duckPrefab, pos, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            objective.x = player.transform.position.x;
            objective.z = player.transform.position.z;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(objective, 0.1f);
        Gizmos.DrawLine(new Vector3(objective.x + spawnZone, 0, objective.z - spawnZone), new Vector3(objective.x + spawnZone, 0, objective.z + spawnZone));
        Gizmos.DrawLine(new Vector3(objective.x - spawnZone, 0, objective.z + spawnZone), new Vector3(objective.x + spawnZone, 0, objective.z + spawnZone));
        Gizmos.DrawLine(new Vector3(objective.x - spawnZone, 0, objective.z + spawnZone), new Vector3(objective.x - spawnZone, 0, objective.z - spawnZone));
        Gizmos.DrawLine(new Vector3(objective.x + spawnZone, 0, objective.z - spawnZone), new Vector3(objective.x - spawnZone, 0, objective.z - spawnZone));

    }

}
