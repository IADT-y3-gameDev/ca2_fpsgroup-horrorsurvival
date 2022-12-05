using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isDeadHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isDeadHash = Animator.StringToHash("isDead");
    }

    // Update is called once per frame
    void Update()
    {
        // more efficient way of ->bool isWalking = animator.GetBool("isWalking");
        //isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isDead = animator.GetBool(isDeadHash);

        bool forwardPressed = Input.GetKey("w");
        bool deadPressed = Input.GetKey("d");
        
        //w key pressed AND isWalking is false
        if (!isWalking && forwardPressed) {
            // more efficient way of 
            // animator.SetBool("isWalking", true)
            animator.SetBool(isWalkingHash, true);
         
        }
        //w key released AND isWalking is true
        if (isWalking && !forwardPressed) {
            animator.SetBool(isWalkingHash, false);
         
        }

        if (!isDead && deadPressed) {
            animator.SetBool(isDeadHash, true);
        }

    }
}
