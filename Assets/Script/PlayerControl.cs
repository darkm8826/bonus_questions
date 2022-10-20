using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController cc;
    public Joystick joystick;
    private float passedTime = 0; 
    private float timerInterval = 0.3f; 
    public GameObject bullet;
    public GameObject firePoint;
    public float ControlTime = 0; 
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(ControlTime != 1)
        {
        passedTime += Time.deltaTime;
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        Vector3 dir = new Vector3(h,0,v);
        if (dir.magnitude>0.1f)
        {

        float faceAngle = Mathf.Atan2(h,v) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler( 0, faceAngle, 0);
        transform.rotation=Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }


        if (!cc.isGrounded)
        {
            dir.y=-9.8f*30*Time.deltaTime;
        }
        cc.Move (dir*Time.deltaTime*10);

        if (Input.GetKey(KeyCode.Space))
        {
          if (passedTime >= timerInterval)
         {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            passedTime = 0;
         }
        }
        }
    }  
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag  == "Teleport")
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
    ControlTime = 1;
    yield return new WaitForSeconds(0.2f);
    ControlTime = 0;
    }
}