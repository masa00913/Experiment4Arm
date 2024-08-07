using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    private Animator animator;
    private int leftArmState;
    private int rightArmState;
    private int leftDownArmState;
    private int rightDownArmState;
    private bool isReset;
    private bool isLeft;
    private bool isRight;
    private bool isLeftDown;
    private bool isRightDown;
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
        animator.SetInteger("leftDownArmState",leftDownArmState);
        animator.SetInteger("rightDownArmState",rightDownArmState);
        animator.SetBool("isLeft",isLeft);
        animator.SetBool("isRight",isRight);
        animator.SetBool("isLeftDown",isLeftDown);
        animator.SetBool("isRightDown",isRightDown);
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

    public void LeftDownArmNext(){
        leftDownArmState++;
        if(leftDownArmState > 2){
            leftDownArmState = 2;
        }   
    }

    public void RightDownArmNext(){
        rightDownArmState++;
        if(rightDownArmState > 2){
            rightDownArmState = 2;
        }
    }

    public void ResetArmPos(){
        isReset = true;
        leftArmState = 0;
        rightArmState = 0;
        leftDownArmState = 0;
        rightDownArmState = 0;
        animator.SetBool("isReset",isReset);
    }

    public void SetIsReset(bool isReset){
        this.isReset = isReset;
        animator.SetBool("isReset",isReset);
    }

    public void SetIsLeft(bool isLeft){
        this.isLeft = isLeft; 
    }

    public void SetIsRight(bool isRight){
        this.isRight = isRight;
    }
    public void SetIsLeftDown(bool isLeftDown){
        this.isLeftDown = isLeftDown; 
    }

    public void SetIsRightDown(bool isRightDown){
        this.isRightDown = isRightDown;
    }
}
