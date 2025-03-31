using System.Runtime.CompilerServices;
using UnityEngine;

public class spawnprojectile : MonoBehaviour
{

    public GameObject Gprojectile;
    public Transform Player;
    public float thrust;

    void FixedUpdate()
    {
        HandleSpawn();
    }

    void HandleSpawn() {
        if (Input.GetKeyDown(KeyCode.L)) {
            GameObject spawnedobj = Instantiate(Gprojectile, Player.position, Player.rotation);

            Rigidbody rb = spawnedobj.GetComponent<Rigidbody>();

            Destroy(Gprojectile, 10);

            Debug.Log("wystrzelono pocisk!");
        }
    }
}
