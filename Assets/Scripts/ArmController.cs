using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    private Animator animator;
    private int leftArmState;
    private int rightArmState;
    private bool isReset;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("leftArmState",leftArmState);
        animator.SetInteger("rightArmState",rightArmState);
        animator.SetBool("isReset",isReset);
        isReset = false;
    }

    public void LeftArmNext(){
        leftArmState++;
        if(leftArmState > 2){
            leftArmState = 2;
        }
        
        
    }

    public void RightArmNext(){
        rightArmState++;
        if(rightArmState > 2){
            rightArmState = 2;
        }
        
    }

    public void ResetArmPos(){
        isReset = true;
        leftArmState = 0;
        rightArmState = 0;
    }
}
