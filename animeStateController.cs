using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool fowardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if(!isWalking && fowardPressed){
            animator.SetBool(isWalkingHash,true);
        }
        if(isWalking && !fowardPressed){
            animator.SetBool(isWalkingHash,false);
        }

        if(!isRunning && (runPressed && fowardPressed)){
            animator.SetBool(isRunningHash,true);
        }
        if(isRunning && (!runPressed || !fowardPressed)){
            animator.SetBool(isRunningHash,false);
        }
        
        // bool isRunning = animator.GetBool("isRunning");
        // bool isWalking = animator.GetBool("isWalking");
        // bool fowardPressed = Input.GetKey("w");
        // bool runPressed = Input.GetKey("left shift");
        //
        // if(!isWalking && fowardPressed){
        //     animator.SetBool("isWalking",true);
        // }
        // if(isWalking && !fowardPressed){
        //     animator.SetBool("isWalking",false);
        // }
        //
        // if(!isRunning && (runPressed && fowardPressed)){
        //     animator.SetBool("isRunning",true);
        // }
        // if(isRunning && (!runPressed || !fowardPressed)){
        //     animator.SetBool("isRunning",false);
        // }
    }
}
