using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{

    private int window = 0;
    private string ip = "127.0.0.1";
    private string port = "25000";
    private string MaxConnections = "20";
    public GUISkin skin;
    //public List<string> chatHistory = new List<string>();
    //private string currentMessage = string.Empty;

    public NetworkView nView;

    void Start()
    {
        nView = GetComponent<NetworkView>();
    }

    void Update()
    {

    }

    private void OnServerInitialized()
    {
        window = 1;
    }

    private void OnConnectedToServer()
    {
        window = 2;
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        if (window == 0)
        {
            ip = GUI.TextField(new Rect(Screen.width / 2 - 100, 155, 110, 25),ip);
            port = GUI.TextField(new Rect(Screen.width / 2 + 15, 155, 55, 25), port);
            MaxConnections = GUI.TextField(new Rect(Screen.width / 2 + 75, 155, 25, 25), MaxConnections);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Start Server"))
            {
                Network.InitializeServer(int.Parse(MaxConnections), int.Parse(port), true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Connect"))
            {
                Network.Connect(ip,int.Parse(port));
            }
        }

        if (window == 1)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Server Shutdown"))
            {
                Network.Disconnect();
                window = 0;
            }
            GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Connections" + Network.connections.Length);

            if (GUI.Button(new Rect(Screen.width / 2 - 100, 245, 200, 25), "Start Room"))
            {


                //currentMessage = GUI.TextField(new Rect(0, Screen.height - 20, 175, 20), currentMessage);
                //if (GUI.Button(new Rect(200, Screen.height - 20, 75, 20), "Send"))
                //{

                //} 

                //GUILayout.Space(15);
                //GUILayout.BeginHorizontal(GUILayout.Width(150));
                //currentMessage = GUILayout.TextField(currentMessage);

                //if(GUILayout.Button("Send"))
                //{
                //    if (!string.IsNullOrEmpty(currentMessage.Trim()))
                //    {
                //        nView.RPC("ChatMessage", RPCMode.AllBuffered, new object[] { currentMessage });
                //        currentMessage = string.Empty;
                //    }
                //}
                //GUILayout.EndHorizontal();
                //foreach (string c in chatHistory)
                //    GUILayout.Label(c);


                nView.RPC("LoadLevel", RPCMode.All);
            }
            
        }

        if (window == 2)
        {
            GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Connected");
        }
    }

    [RPC]
    void LoadLevel()
    {
        Application.LoadLevel(1);
    }

    //[RPC]
    //public void ChatMessage(string message)
    //{
    //    chatHistory.Add(message);
    //}
}
