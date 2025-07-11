using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public GameObject crosshair;
    float xRotation = 0f;
    private bool cursorLocked = false;
    private Alteruna.Avatar _avatar;
    private GameObject menu;
    private bool fingerprintIsOn = false;

    void Start()
    {
        _avatar = GetComponentInParent<Alteruna.Avatar>();

        if (!_avatar.IsMe) return;

        menu = GameObject.FindGameObjectWithTag("Menu");
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        crosshair.SetActive(true);
    }

    void Update()
    {
        if (!_avatar.IsMe) return;

        if (cursorLocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cursorLocked)
            {
                if (!fingerprintIsOn)
                {
                    Cursor.lockState = CursorLockMode.None;
                    cursorLocked = false;
                    crosshair.SetActive(false);
                    menu.SetActive(true);
                    menu.transform.Find("PauseMenuUI").gameObject.SetActive(true);
                }
                else
                {
                    FingerPrintOff();
                }
            }
            else
            {
                if (!fingerprintIsOn)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    cursorLocked = true;
                    crosshair.SetActive(true);
                    menu.SetActive(false);
                }
                else
                {
                    FingerPrintOff();
                }
            }
        }
    }

    public void FingerPrintToggle()
    {
        fingerprintIsOn = !fingerprintIsOn;
        if (fingerprintIsOn)
        {
            Cursor.lockState = CursorLockMode.None;
            cursorLocked = false;
            crosshair.SetActive(false);
        }
    }

    public void FingerPrintOff()
    {
        GameObject.FindGameObjectWithTag("FingerprintUI").transform.Find("FingerprintPanel").gameObject.SetActive(false);
        FingerPrintToggle();
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        crosshair.SetActive(true);
    }
}