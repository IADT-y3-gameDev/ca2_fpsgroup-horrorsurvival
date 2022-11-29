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
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isDead = animator.GetBool(isDeadHash);
        bool forwardPressed = Input.GetKey("w");
        bool deadPressed = Input.GetKey("d");
        if (!isWalking && forwardPressed) {
            animator.SetBool(isWalkingHash, true);
         
        }
        
        if (isWalking && !forwardPressed) {
            animator.SetBool(isWalkingHash, false);
         
        }

        if (!isDead && deadPressed) {
            animator.SetBool(isDeadHash, true);
        }

    }
}
