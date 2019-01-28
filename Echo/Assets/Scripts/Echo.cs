using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;//Socket编程API位于System.Net.Sockets命名空间中，需要引用它
using UnityEngine.UI;

public class Echo : MonoBehaviour
{

    Socket socket;//定义套接字
    //UGUI
    public InputField InputField;
    public Text text;
    //点击链接按钮
    public void Connection()
    {
        //Socket ，创建一个Socket对象
        /*
         * 
         * */
        socket = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream,ProtocolType.Tcp);

        //Connect,连接服务端（远程ip地址，远程端口）
        socket.Connect("127.0.0.1", 8888);
    }

    //点击发送按钮
    public void Send()
    {
        //Send
        string sendStr = InputField.text;
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr);
        socket.Send(sendBytes);
        //Recv
        byte[] readBuff = new byte[1024];
        int count = socket.Receive(readBuff);
        string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count);
        text.text = recvStr;
        //Close
        socket.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
