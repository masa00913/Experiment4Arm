using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    [Header("テストの順番 1:安静 2:左上 3:右上,4:左下,5:右下")]private int[] testOrder = {1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5,1,2,3,4,5};
    [Header("トレーにングの順番 1:安静 2:左上 3:右上")]private int[] training_twoArm_order = {1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3};
    [SerializeField]private bool isTraining;
    [SerializeField]private bool isTwoArm;
    private bool isStart;
    [SerializeField]private ArmController armController;
    [Header("テスト開始時間")]private float startTime;
    [Header("安静の時間")]private float restTime = 2;
    [Header("指示の時間")]private float instituteTime = 1;
    [Header("合図の時間")]private float signTime = 1;
    [Header("練習前の少しの時間")]private float preTrainingTime = 0f;
    [Header("練習時間")]private float trainingTime = 2f;
    private int trainingCount;
    [SerializeField]private GameObject trainingCanvas;
    [SerializeField]private GameObject crossObj;
    [SerializeField]private GameObject restObj;
    [SerializeField]private GameObject leftDownObj;
    [SerializeField]private GameObject rightDownObj;
    [SerializeField]private GameObject leftUpObj;
    [SerializeField]private GameObject rightUpObj;

    [SerializeField]private UdpSender udpSender;

    private bool isSend;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTraining){
            if(isTwoArm){
                if(!isStart){
                    isStart = true;
                    startTime = Time.time;
                }
                
                var elapsedTime = Time.time - startTime;
                if(elapsedTime < restTime){
                    //安静
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(false);
                    restObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);

                    armController.SetIsLeft(false);
                    armController.SetIsRight(false);
                    armController.ResetArmPos();
                }else if(elapsedTime < restTime + instituteTime){
                    //指示時間
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(false);
                    switch (training_twoArm_order[trainingCount])
                    {
                        case 1:
                            //安静
                            restObj.SetActive(true);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(false);
                            break;
                        case 2:
                            //左上
                            restObj.SetActive(false);
                            leftUpObj.SetActive(true);
                            rightUpObj.SetActive(false);
                            break;
                        case 3:
                            //右上
                            restObj.SetActive(false);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(true);
                            break;
                        default:
                            break;
                    }
                    
                }else if(elapsedTime < restTime + instituteTime + signTime){
                    //合図時間
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(true);
                    restObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);
                }else if(elapsedTime <  restTime + instituteTime + signTime + trainingTime){
                    //訓練時間
                    trainingCanvas.SetActive(false);
                    crossObj.SetActive(false);
                    restObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);
                    if(!isSend){
                        udpSender.SendMessages(training_twoArm_order[trainingCount].ToString());
                        Debug.Log(training_twoArm_order[trainingCount] + "刺激開始");
                        isSend = true;
                    }
                    if(elapsedTime > restTime + instituteTime + signTime + preTrainingTime){
                        switch (training_twoArm_order[trainingCount])
                        {
                            case 1:
                                //安静
                                armController.SetIsLeft(false);
                                armController.SetIsRight(false);
                                break;
                            case 2:
                                //左上
                                armController.SetIsLeft(true);
                                armController.SetIsRight(false);
                                break;
                            case 3:
                                //右上
                                armController.SetIsLeft(false);
                                armController.SetIsRight(true);
                                break;
                            default:
                                break;
                        }
                    }
                }else{
                    startTime = Time.time;
                    
                    trainingCount++;
                    isSend = false;
                    Debug.Log(trainingCount + "回目終了");
                    if(trainingCount >= training_twoArm_order.Length){
                        isTraining = false;
                    }
                }
            
            }else{
                if(!isStart){
                    isStart = true;
                    startTime = Time.time;
                }
                
                var elapsedTime = Time.time - startTime;
                if(elapsedTime < restTime){
                    //安静
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(false);
                    restObj.SetActive(false);
                    leftDownObj.SetActive(false);
                    rightDownObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);

                    armController.SetIsLeft(false);
                    armController.SetIsRight(false);
                    armController.SetIsLeftDown(false);
                    armController.SetIsRightDown(false);
                    armController.ResetArmPos();
                }else if(elapsedTime < restTime + instituteTime){
                    //指示時間
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(false);
                    switch (testOrder[trainingCount])
                    {
                        case 1:
                            //安静
                            restObj.SetActive(true);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(false);
                            leftDownObj.SetActive(false);
                            rightDownObj.SetActive(false);
                            break;
                        case 2:
                            //左上
                            restObj.SetActive(false);
                            leftUpObj.SetActive(true);
                            rightUpObj.SetActive(false);
                            leftDownObj.SetActive(false);
                            rightDownObj.SetActive(false);
                            break;
                        case 3:
                            //右上
                            restObj.SetActive(false);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(true);
                            leftDownObj.SetActive(false);
                            rightDownObj.SetActive(false);
                            break;
                        case 4:
                            //左下
                            restObj.SetActive(false);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(false);
                            leftDownObj.SetActive(true);
                            rightDownObj.SetActive(false);
                            break;
                        case 5:
                            //右下
                            restObj.SetActive(false);
                            leftUpObj.SetActive(false);
                            rightUpObj.SetActive(false);
                            leftDownObj.SetActive(false);
                            rightDownObj.SetActive(true);
                            break;
                        default:
                            break;
                    }
                    
                }else if(elapsedTime < restTime + instituteTime + signTime){
                    //合図時間
                    trainingCanvas.SetActive(true);
                    crossObj.SetActive(true);
                    restObj.SetActive(false);
                    leftDownObj.SetActive(false);
                    rightDownObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);
                }else if(elapsedTime <  restTime + instituteTime + signTime + trainingTime){
                    //訓練時間
                    trainingCanvas.SetActive(false);
                    crossObj.SetActive(false);
                    restObj.SetActive(false);
                    leftDownObj.SetActive(false);
                    rightDownObj.SetActive(false);
                    leftUpObj.SetActive(false);
                    rightUpObj.SetActive(false);
                    if(!isSend){
                        udpSender.SendMessages(testOrder[trainingCount].ToString());
                        Debug.Log(testOrder[trainingCount] + "刺激開始");
                        isSend = true;
                    }
                    if(elapsedTime > restTime + instituteTime + signTime + preTrainingTime){
                        switch (testOrder[trainingCount])
                        {
                            case 1:
                                //安静
                                armController.SetIsLeft(false);
                                armController.SetIsRight(false);
                                armController.SetIsLeftDown(false);
                                armController.SetIsRightDown(false);
                                break;
                            case 2:
                                //左上
                                armController.SetIsLeft(true);
                                armController.SetIsRight(false);
                                armController.SetIsLeftDown(false);
                                armController.SetIsRightDown(false);
                                break;
                            case 3:
                                //右上
                                armController.SetIsLeft(false);
                                armController.SetIsRight(true);
                                armController.SetIsLeftDown(false);
                                armController.SetIsRightDown(false);
                                break;
                            case 4:
                                //左下
                                armController.SetIsLeft(false);
                                armController.SetIsRight(false);
                                armController.SetIsLeftDown(true);
                                armController.SetIsRightDown(false);
                                break;
                            case 5:
                                //右下
                                armController.SetIsLeft(false);
                                armController.SetIsRight(false);
                                armController.SetIsLeftDown(false);
                                armController.SetIsRightDown(true);
                                break;
                            default:
                                break;
                        }
                    }
                }else{
                    startTime = Time.time;
                    
                    trainingCount++;
                    isSend = false;
                    Debug.Log(trainingCount + "回目終了");
                    if(trainingCount >= testOrder.Length){
                        isTraining = false;
                    }
                }
            }
            
        }   


        // if(Input.GetKeyDown(KeyCode.Space)){
        //     ScreenCapture.CaptureScreenshot("Assets/Screenshot/TPS.png");
        //     //Screenshot.Capture("Screenshot/test.png");
        //     Debug.Log("撮った");
        // }
    }
}
