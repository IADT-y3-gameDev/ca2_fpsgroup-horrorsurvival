using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public GameObject spawn;
    public int amount = 1;
    public float delaySpawn = 1;

    private int getAmount;
    private float timer;
    private int spawned;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawner");
      ResetRound();  
    }

    private void ResetRound() {
        getAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (delaySpawn < timer) {
            if (spawned < getAmount) {
                timer = 0;
                spawned++;
                GameObject instance = Instantiate(spawn, transform);
                instance.transform.parent = null;
            }
        }
    }
    //Draw wireframe mesh of what we intend
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (spawn != null)  {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position,
            spawn.transform.rotation, Vector3.one);
        }
    }
}
