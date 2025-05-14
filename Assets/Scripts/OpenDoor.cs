using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class OpenDoor : MonoBehaviour
{
 private SerialPort serialPort;
    public string portName = "COM3";
    public int baudRate = 9600;

    void Start()
    {
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
                }
                else if (message.Contains("LOSE"))
                {
                    Debug.Log("Spiller tabte i Arduino-spillet!");
                }
            }
            catch (System.Exception) { }
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
