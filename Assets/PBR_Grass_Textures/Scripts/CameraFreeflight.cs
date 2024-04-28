using UnityEngine;
using System.Collections;

public class CameraFreeflight : MonoBehaviour 
{
    public float speedNormal = 10.0f;
    public float speedFast   = 50.0f;

    public float mouseSensitivityX = 5.0f;
	public float mouseSensitivityY = 5.0f;
    
	float rotY = 0.0f;
    
//	void Start()
//	{
//		if (GetComponent<Rigidbody>())
//			GetComponent<Rigidbody>().freezeRotation = true;
//	}

	void Update()
	{
        // rotation        
        // if (Input.GetMouseButton(1)) 
        // {
            float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivityX;
            rotY += Input.GetAxis("Mouse Y") * mouseSensitivityY;
            rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0.0f);
        // }
        
        float forward = Input.GetAxis("Vertical");
        float strafe  = Input.GetAxis("Horizontal");
        float upward = Input.GetAxis("Jump");
        float downard = Input.GetAxis("Crouch");

        
        // move forwards/backwards
        if (forward != 0.0f)  
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? speedFast : speedNormal;
            Vector3 trans = new Vector3(0.0f, 0.0f, forward * speed * Time.deltaTime);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }

        // strafe left/right
        if (strafe != 0.0f) 
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? speedFast : speedNormal;
            Vector3 trans = new Vector3(strafe * speed * Time.deltaTime, 0.0f, 0.0f);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }
        
        if (upward != 0.0f)  
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? speedFast : speedNormal;
            Vector3 trans = new Vector3(0.0f, upward * speed * Time.deltaTime,0.0f);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }
        
        if (downard != 0.0f)  
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? speedFast : speedNormal;
            Vector3 trans = new Vector3(0.0f, downard * speed * Time.deltaTime,0.0f);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }
	}
}
