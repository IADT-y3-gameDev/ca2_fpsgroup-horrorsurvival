using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageAnim : MonoBehaviour
{

    private Animator animator;
    //Private means only this script can access the variable.
    private int hitNumber;
    private NavMeshAgent agent;
    
    
    
    private void  OnEnable() {
        hitNumber = 0;
    }

   void Start() {
        animator = GetComponentInChildren<Animator>();
         animator.SetBool("isDead", false);
        Debug.Log(animator.GetBool("isDead"));
        agent = GetComponent<NavMeshAgent>();  
   }

    //Unity stores the collider it hits and we can access it via the name other.
    void OnCollisionEnter(Collision other)
    {   
       
        
        //We compare the tag in the other object to the tag name we set earlier.
        //change this  from -- other.transform.CompareTag("bullet")
        if (other.collider.transform.CompareTag("bullet"))
        {
            //Debug.Log("Collision w bullet");
            //If the comparison is true, we increase the hit number.
            hitNumber++;
            //Debug.Log(hitNumber);
        }
        //if the hit number is equal to 3 we destroy this object.
        if (hitNumber == 3)
        {
            animator.SetBool("isDead", true);
            //allow physics to be applied
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //disable navmesh seeking behaviour
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            
            StartCoroutine(WaitToDie());
         
        }
    }

    IEnumerator WaitToDie() {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false); 
    }
}