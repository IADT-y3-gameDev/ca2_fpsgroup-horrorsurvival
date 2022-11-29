using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{

    public GameObject projectile;
    private GameObject clone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("projectile");
            clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(clone, 4.0f);
        }
    }
}
