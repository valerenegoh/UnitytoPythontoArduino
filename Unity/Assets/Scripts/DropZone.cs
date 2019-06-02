using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Net;
using System.Net.Sockets;
using System.Linq;

public class DropZone : MonoBehaviour, IDropHandler
{

    public string IP = "127.0.0.1"; 
    public int Port = 1234;
    public byte[] namebyte;
    public Socket client;
    private bool canRotatePlayer = false;
    public Draggable d;


    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null){
            d.parentToReturnTo = this.transform;
        }
        canRotatePlayer = true;
        StartCoroutine(Wait(3.0f));
    }

    void Update()
     {
         RotatePlayer();
     }

    private IEnumerator Wait(float waitTime){
        Debug.Log("Begin wait() " + Time.time);
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;
        Debug.Log("End wait() " + Time.time);
        SendPython();
    }

    private void SendPython(){
        string name =  d.gameObject.name;
        Debug.Log (name);

        // SENDING
        client = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect (IP, Port); //connecting port with ip address 
        namebyte = System.Text.Encoding.ASCII.GetBytes(name); //decode string data into byte for sending 
        client.Send (namebyte); //send data to port

        // RECEIVING
        byte[] b = new byte[1024];
        int k = client.Receive(b); //receive data from port coming from python script 
        string szReceived = System.Text.Encoding.ASCII.GetString(b, 0, k); //coming data is in bytes converting into string 
        if (client.Connected) {
            Debug.Log (szReceived); //showing data on the unity log
        } 
        else {
            Debug.Log (" Not Connected");
        }
        client.Close();  
    }

    protected void RotatePlayer()
     {
         if(canRotatePlayer){
             d.transform.Rotate(Vector3.forward, -90.0f * Time.deltaTime);
         }
     }
}