using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject particle;

    void OnCollisionEnter(Collision other) {
       //if  (other.collider.transform.CompareTag("Player") == false)
        
        Debug.Log("bullet collision: "+ other.gameObject);
    
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        if (particle != null) {
            Instantiate(particle, pos, rot);
        }
        gameObject.SetActive(false);
       
    }
}
