using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{

    public float mouseSensitvity;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensitvity = PlayerPrefs.GetFloat("Sens");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseSensitvity = PlayerPrefs.GetFloat("Sens");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime * 5;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime * 5;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
