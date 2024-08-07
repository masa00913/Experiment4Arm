using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UdpReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    public int port = 12345; // 受信側のポート番号
    [SerializeField]private ArmController armController;
    [SerializeField]private ExperimentManager experimentManager;

    void Start()
    {
        // UdpClientを指定したポート番号で初期化
        udpClient = new UdpClient(port);
        // データ受信用のスレッドを開始
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
        Debug.Log("UDP receiver started");
    }

    void ReceiveData()
    {
        // 受信するエンドポイントを指定
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
        while (true)
        {
            try
            {
                // データを受信
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                int message = data[0];
                if(experimentManager.GetIsTask()){
                    if(!experimentManager.GetIsGiveUp()){
                        switch (message)
                        {
                            case 1:
                                Debug.Log("安静");
                                armController.ArmStay();
                                break;
                            case 2:
                                Debug.Log("左上手");
                                armController.LeftArmNext();
                                break;
                            case 3:
                                Debug.Log("右上手");
                                armController.RightArmNext();
                                break;
                            case 4:
                                Debug.Log("左下手");
                                armController.LeftDownArmNext();
                                break;
                            case 5:
                                Debug.Log("右下手");
                                armController.RightDownArmNext();
                                break;
                            default:
                                Debug.Log("例外を検出");
                                break;
                        }
                    }else{
                        switch (experimentManager.GetCurrentTaskNum())
                        {
                           case 1:
                                Debug.Log("ギブアップ安静");
                                armController.ArmStay();
                                break;
                            case 2:
                                Debug.Log("ギブアップ左上手");
                                armController.LeftArmNext();
                                break;
                            case 3:
                                Debug.Log("ギブアップ右上手");
                                armController.RightArmNext();
                                break;
                            case 4:
                                Debug.Log("ギブアップ左下手");
                                armController.LeftDownArmNext();
                                break;
                            case 5:
                                Debug.Log("ギブアップ右下手");
                                armController.RightDownArmNext();
                                break;
                            default:
                                Debug.Log("例外を検出");
                                break;
                        }
                    }
                }else{
                    Debug.Log("タスク中ではありません");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error receiving data: " + e.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        // アプリケーション終了時にスレッドとUdpClientを閉じる
        receiveThread.Abort();
        udpClient.Close();
    }
}
