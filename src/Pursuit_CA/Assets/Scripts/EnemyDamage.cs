using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int hitNumber;
    public int noHits = 3;

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.transform.CompareTag("bullet")){
            hitNumber++;
            //Debug.Log("with Bullet. Hit: " + hitNumber);
        }

        if (hitNumber == noHits){
            //gameObject.SetActive(false);
            Debug.Log("Zombie dead!");
            Destroy(gameObject);
        }
    }
}
