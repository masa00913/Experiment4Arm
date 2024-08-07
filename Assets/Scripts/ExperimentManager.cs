using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExperimentManager : MonoBehaviour
{
    [Header("実験を開始するか")][SerializeField]private bool isExperiment;
    [Header("保存するCSVの名前")][SerializeField]private string csvName;
    [Header("保存する中身")]private List<string[]> rowData = new List<string[]>();
    [SerializeField]private GameObject leftCircle;
    [SerializeField]private GameObject rightCircle;
    [SerializeField]private GameObject leftDownCircle;
    [SerializeField]private GameObject rightDownCircle;
    private SpriteRenderer leftCircleSprite;
    private SpriteRenderer rightCircleSprite;
    private SpriteRenderer leftDownCircleSprite;
    private SpriteRenderer rightDownCircleSprite;
    [SerializeField]private GameObject leftTipObj;
    [SerializeField]private GameObject rightTipObj;
    [SerializeField]private GameObject leftDownTipObj;
    [SerializeField]private GameObject rightDownTipObj;
    [Header("タスクの順番 1:左上 2:右上, 3:左下 4:右下")]private int[] taskOrder = {1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4};
    [Header("現在のタスク番号")]private int currentTaskNum;
    [SerializeField]private ArmController armController;

    private float startTime;
    private float intervalTime = 1f;
    private float armStayTime = 0.25f;
    private float taskStartTime;
    private float taskEndTime;
    private bool isStart;
    private bool isTask;

    // Start is called before the first frame update
    void Start()
    {
        leftCircleSprite = leftCircle.GetComponent<SpriteRenderer>();
        rightCircleSprite = rightCircle.GetComponent<SpriteRenderer>();
        leftDownCircleSprite = leftDownCircle.GetComponent<SpriteRenderer>();
        rightDownCircleSprite = rightDownCircle.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Task();
    }

    private void Task(){
        if(!isExperiment) return;
        if(!isStart){
            //最初の処理
            startTime = Time.time;
            taskStartTime = Time.time;
            //armController.ResetArmPos();
            Debug.Log("＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝実験開始＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");
            isStart = true;
            isTask = true;
        }

        if(!isTask && Time.time - taskEndTime > armStayTime){
            //腕を戻すタイミング
            Debug.Log("腕を戻す");
            armController.ResetArmPos();
        }

        if(!isTask && Time.time - taskEndTime > intervalTime){
            //次のタスクを開始
            Debug.Log("次のタスク開始");
            currentTaskNum++;
            taskStartTime = Time.time;
            isTask = true;
            armController.SetIsReset(false);
            leftCircleSprite.color = Color.green;
            rightCircleSprite.color = Color.green;
            leftDownCircleSprite.color = Color.green;
            rightDownCircleSprite.color = Color.green;
        }

        if(isTask){
            bool isClearTask = false;
            rightCircle.SetActive(false);
            leftCircle.SetActive(false);
            rightDownCircle.SetActive(false);
            leftDownCircle.SetActive(false);
            switch (taskOrder[currentTaskNum])
            {
                case 1:
                    //左上
                    leftCircle.SetActive(true);
                    if(leftTipObj.transform.position.z >= leftCircleSprite.transform.position.z){
                        Debug.Log("左のタスク完了");
                        isClearTask = true;
                        leftCircleSprite.color = Color.red;

                        string[] rowDataTemp = new string[3];
                        rowDataTemp[0] = "左";
                        rowDataTemp[1] = (currentTaskNum + 1) + "回目";
                        rowDataTemp[2] = (Time.time - taskStartTime).ToString();
                        rowData.Add(rowDataTemp);
                    }
                    break;
                case 2:
                    //右上
                    rightCircle.SetActive(true);
                    if(rightTipObj.transform.position.z >= rightCircleSprite.transform.position.z){
                        Debug.Log("右のタスク完了");
                        isClearTask = true;
                        rightCircleSprite.color = Color.red;

                        string[] rowDataTemp = new string[3];
                        rowDataTemp[0] = "右";
                        rowDataTemp[1] = (currentTaskNum + 1) + "回目";
                        rowDataTemp[2] = (Time.time - taskStartTime).ToString();
                        rowData.Add(rowDataTemp);
                    }
                    break;
                case 3:
                    //左下
                    leftDownCircle.SetActive(true);
                    if(leftDownTipObj.transform.position.z >= leftDownCircleSprite.transform.position.z){
                        Debug.Log("左のタスク完了");
                        isClearTask = true;
                        leftDownCircleSprite.color = Color.red;

                        string[] rowDataTemp = new string[3];
                        rowDataTemp[0] = "左";
                        rowDataTemp[1] = (currentTaskNum + 1) + "回目";
                        rowDataTemp[2] = (Time.time - taskStartTime).ToString();
                        rowData.Add(rowDataTemp);
                    }
                    break;
                case 4:
                    //右下
                    rightDownCircle.SetActive(true);
                    if(rightDownTipObj.transform.position.z >= rightDownCircleSprite.transform.position.z){
                        Debug.Log("右のタスク完了");
                        isClearTask = true;
                        rightDownCircleSprite.color = Color.red;

                        string[] rowDataTemp = new string[3];
                        rowDataTemp[0] = "右";
                        rowDataTemp[1] = (currentTaskNum + 1) + "回目";
                        rowDataTemp[2] = (Time.time - taskStartTime).ToString();
                        rowData.Add(rowDataTemp);
                    }
                    break;
                default:
                    break;
            }

            if(isClearTask){
                //タスク終了時の処理
                taskEndTime = Time.time;

                var taskTime = Time.time - taskStartTime;
                Debug.Log((currentTaskNum + 1) + "回目：タスクにかかった時間 " + taskTime);
                isTask = false;
                SaveToCSV();
                if(currentTaskNum >= taskOrder.Length-1){
                    Debug.Log("タスク終了");
                    var allTaskTime = Time.time - startTime;
                    Debug.Log("総実験時間 : " + allTaskTime);
                    
                    armController.ResetArmPos();
                    isExperiment = false;


                    string[] rowDataTemp = new string[3];
                    rowDataTemp[0] = "終了";
                    rowDataTemp[1] = allTaskTime.ToString();
                    rowData.Add(rowDataTemp);
                    SaveToCSV();
                    Debug.Log("CSVに保存完了");
                }
            }
        }
    }

    public void SaveToCSV()
    {
        // 保存するファイルパス
        string filePath = Application.dataPath + "/CSVs/" + csvName + ".csv";

        // ファイルストリームを作成
        StreamWriter outStream = File.CreateText(filePath);

        // 各行を書き込む
        foreach (string[] row in rowData)
        {
            string rowString = string.Join(",", row);
            outStream.WriteLine(rowString);
        }

        // ファイルストリームを閉じる
        outStream.Close();

        Debug.Log("CSV file saved to: " + filePath);
    }

    public bool GetIsTask(){
        return isTask;
    }
}
