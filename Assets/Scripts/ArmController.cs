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
    private bool isResetLeftUp;
    private bool isResetRightUp;
    private bool isResetLeftDown;
    private bool isResetRightDown;
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

        if(rightArmState == 2){
            rightArmState = 0;
        }
        if(leftDownArmState == 2){
            leftDownArmState = 0;
        }
        if(rightDownArmState == 2){
            rightDownArmState = 0;
        }
    }

    /// <summary>
    /// 安静時の処理
    /// </summary>
    public void ArmStay(){
        if(leftArmState == 2){
            leftArmState = 0;
        }
        if(rightArmState == 2){
            rightArmState = 0;
        }

        if(leftDownArmState == 2){
            leftDownArmState = 0;
        }
        if(rightDownArmState == 2){
            rightDownArmState = 0;
        }
    }

    public void RightArmNext(){
        rightArmState++;
        if(rightArmState > 2){
            rightArmState = 2;
        }

        if(leftArmState == 2){
            leftArmState = 0;
        }

        if(leftDownArmState == 2){
            leftDownArmState = 0;
        }
        if(rightDownArmState == 2){
            rightDownArmState = 0;
        }
    }

    public void LeftDownArmNext(){
        leftDownArmState++;
        if(leftDownArmState > 2){
            leftDownArmState = 2;
        }
        if(leftArmState == 2){
            leftArmState = 0;
        }

        if(rightArmState == 2){
            rightArmState = 0;
        }
        if(rightDownArmState == 2){
            rightDownArmState = 0;
        }
    }

    public void RightDownArmNext(){
        rightDownArmState++;
        if(rightDownArmState > 2){
            rightDownArmState = 2;
        }

        if(leftArmState == 2){
            leftArmState = 0;
        }

        if(rightArmState == 2){
            rightArmState = 0;
        }
        if(leftDownArmState == 2){
            leftDownArmState = 0;
        }
    }

    public void ResetArmPos(){
        leftArmState = 0;
        rightArmState = 0;
        leftDownArmState = 0;
        rightDownArmState = 0;
    }

    

    public void ResetLeftArmUp(){
        leftArmState = 0;
        isResetLeftUp = true;
        animator.SetBool("isResetLeftUp", isResetLeftUp);
    }
    public void ResetLeftArmDown(){
        leftDownArmState = 0;
        isResetLeftDown = true;
        animator.SetBool("isResetLeftDown", isResetLeftDown);
    }

    public void ResetRightArmUp(){
        rightArmState = 0;
        isResetRightUp = true;
        animator.SetBool("isResetRightUp", isResetRightUp);
    }
    public void ResetRightArmDown(){
        rightDownArmState = 0;
        isResetRightDown = true;
        animator.SetBool("isResetRightDown", isResetRightDown);
    }


    public void SetIsLeft(bool isLeft){
        this.isLeft = isLeft;
        leftArmState = 2;
    }

    public void SetIsRight(bool isRight){
        this.isRight = isRight;
        rightArmState = 2;
    }
    public void SetIsLeftDown(bool isLeftDown){
        this.isLeftDown = isLeftDown; 
        leftDownArmState = 2;
    }

    public void SetIsRightDown(bool isRightDown){
        this.isRightDown = isRightDown;
        rightDownArmState = 2;
    }
}
