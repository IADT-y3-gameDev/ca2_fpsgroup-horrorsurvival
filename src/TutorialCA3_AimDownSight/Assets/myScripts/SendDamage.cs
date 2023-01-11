using UnityEngine;

public class SendDamage : MonoBehaviour
{
    private Animator animator;

    public Transform target;
    float AttackDistance = 10;
    private GameObject thePlayer;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        // animator.SetTrigger("isAttack");
    }

    void OnCollisionStay(Collision other)
    {
        //We compare the tag in the other object to the tag name we set earlier.
         //change this  from -- other.transform.CompareTag("Player")
        if (other.collider.transform.CompareTag("Player"))
        {
            //If the above matches, then send a message to the other object.
            //This will also pass a value of 1 for our damage.
            other.transform.SendMessage("ApplyDamage", 1);
            animator.SetTrigger("isAttack");
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (Vector3.Distance(thePlayer.transform.position, target.position) > AttackDistance)
    //     {
    //         animator.SetTrigger("isAttack");
    //     }
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     animator.SetTrigger("isAttack");
    // }

    // void OnCollisionEnter(Collision other) {
    //     if (other.collider.transform.CompareTag("Player")) 
    //     {
            
    //     }
    // }

    // void Update() {
    //     if(Vector3.Distance(transform.position, target.position) > AttackDistance)
    //     {
    //         animator.SetTrigger("isAttack");
    //     }
    //     else
    //     {
    //         return;
    //     }
    // }
}
