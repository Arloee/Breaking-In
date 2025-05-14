using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class OpenDoor : MonoBehaviour
{
 private SerialPort serialPort;
    public string portName = "COM3";
    public int baudRate = 9600;

    public float openAngle = 90f;
    public float openSpeed = 2f;
    public bool isOpen = false;

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
                    if (currentCoroutine != null) StopCoroutine(currentCoroutine);
                    currentCoroutine = StartCoroutine(ToggleDoor());
                }
                else if (message.Contains("LOSE"))
                {
                    Debug.Log("Spiller tabte i Arduino-spillet!");
                }
            }
            catch (System.Exception) { }
        }
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;
        isOpen = !isOpen;

        while(Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }
        transform.rotation = targetRotation;
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
