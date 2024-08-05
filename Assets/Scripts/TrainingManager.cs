using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    [Header("テストの順番 0:安静 1:左手 2:右手")]private int[] testOrder = {0,1,2,0,1,2,0,1,2,0,1,2};
    [SerializeField]private bool isTraining;
    private bool isStart;
    [SerializeField]private ArmController armController;
    [Header("テスト開始時間")]private float startTime;
    [Header("安静の時間")]private float restTime = 2;
    [Header("指示の時間")]private float instituteTime = 1;
    [Header("合図の時間")]private float signTime = 1;
    [Header("練習前の少しの時間")]private float preTrainingTime = 0.5f;
    [Header("練習時間")]private float trainingTime = 2.5f;
    private int trainingCount;
    [SerializeField]private GameObject trainingCanvas;
    [SerializeField]private GameObject crossObj;
    [SerializeField]private GameObject restObj;
    [SerializeField]private GameObject leftObj;
    [SerializeField]private GameObject rightObj;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTraining){
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
                leftObj.SetActive(false);
                rightObj.SetActive(false);

                armController.SetIsLeft(false);
                armController.SetIsRight(false);
                armController.SetIsReset(true);
            }else if(elapsedTime < restTime + instituteTime){
                //指示時間
                trainingCanvas.SetActive(true);
                crossObj.SetActive(false);
                switch (testOrder[trainingCount])
                {
                    case 0:
                        restObj.SetActive(true);
                        leftObj.SetActive(false);
                        rightObj.SetActive(false);
                        break;
                    case 1:
                        restObj.SetActive(false);
                        leftObj.SetActive(true);
                        rightObj.SetActive(false);
                        break;
                    case 2:
                        restObj.SetActive(false);
                        leftObj.SetActive(false);
                        rightObj.SetActive(true);
                        break;
                    default:
                        break;
                }
                
            }else if(elapsedTime < restTime + instituteTime + signTime){
                //合図時間
                trainingCanvas.SetActive(true);
                crossObj.SetActive(true);
                restObj.SetActive(false);
                leftObj.SetActive(false);
                rightObj.SetActive(false);
            }else if(elapsedTime <  restTime + instituteTime + signTime + trainingTime){
                //訓練時間
                trainingCanvas.SetActive(false);
                crossObj.SetActive(false);
                restObj.SetActive(false);
                leftObj.SetActive(false);
                rightObj.SetActive(false);

                armController.SetIsReset(false);
                if(elapsedTime > restTime + instituteTime + signTime + preTrainingTime){
                    switch (testOrder[trainingCount])
                    {
                        case 0:
                            armController.SetIsLeft(false);
                            armController.SetIsRight(false);
                            break;
                        case 1:
                            armController.SetIsLeft(true);
                            armController.SetIsRight(false);
                            break;
                        case 2:
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
                if(trainingCount >= testOrder.Length){
                    isTraining = false;
                }
            }
        }   
    }
}
