using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using Alteruna;
using Unity.VisualScripting;

public class OpenDoor : AttributesSync
{
    private SerialPort serialPort;
    public string portName = "COM3";
    public int baudRate = 9600;

    public float openAngle = 90f;
    public float openSpeed = 2f;
    [SynchronizableField] public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Coroutine currentCoroutine;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));

        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string message = serialPort.ReadLine();
                if (message.Contains("WIN"))
                {
                    Debug.Log("Spiller vandt i Arduino-spillet!");
                    BroadcastRemoteMethod("OpenDoorRPC");
                }
                else if (message.Contains("LOSE"))
                {
                    Debug.Log("Spiller tabte i Arduino-spillet!");
                }
            }
            catch (System.Exception) { }
        }
    }

[SynchronizableMethod]
    public void OpenDoorRPC()
    {
        transform.Find("Door").Find("Collider").gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
