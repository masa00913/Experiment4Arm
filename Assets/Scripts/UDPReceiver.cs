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
    public int port = 5005; // 受信側のポート番号
    [SerializeField]private ArmController armController;

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
                // バイト配列を文字列に変換
                string message = Encoding.UTF8.GetString(data);
                Debug.Log("Message received: " + message);
                switch (message)
                {
                    case "1":
                        Debug.Log("左手");
                        armController.LeftArmNext();
                        break;
                    case "2":
                        Debug.Log("右手");
                        armController.RightArmNext();
                        break;
                    case "3":
                        Debug.Log("安静");
                        break;
                    default:
                        Debug.Log("例外を検出");
                        break;
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