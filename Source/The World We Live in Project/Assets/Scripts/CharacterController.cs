using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //�H���t��
    public int playerSpeed;
    public float playerRotateSpeed;
    private Vector3 moveVector;

    private Rigidbody rid;
    private Animator ant;

    //���o��v����V
    private Transform mainCameraTranform;
    private Transform cameraDirection;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
        ant = GetComponent<Animator>();

        GenerateCameraDirectionGameObject();
        rid.position = new Vector3(0,1,0);
    }
    void FixedUpdate()
    {
        GetCameraDirection();
        KeyControl();

        

    }
    private void GenerateCameraDirectionGameObject()
    {
        //���o��v����m
        mainCameraTranform = Camera.main.transform;
        //���ͪ���>�Ӫ����V�P��v���ۦP
        GameObject cameraDirectionObject = new GameObject();
        cameraDirectionObject.transform.parent = transform;
        cameraDirectionObject.transform.localPosition = Vector3.zero;
        cameraDirectionObject.name = "Direction";
        cameraDirection = cameraDirectionObject.transform;
    }
    private void GetCameraDirection()
    {
        //��scameraDirection�����ਤ��>�u���D��v����Y��
        if (mainCameraTranform)
        {
            cameraDirection.eulerAngles = new Vector3(0, mainCameraTranform.eulerAngles.y, 0);
        }
    }
    private void KeyControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SmoothRotation(cameraDirection.eulerAngles.y);
            moveVector = cameraDirection.forward * playerSpeed;
            ant.SetBool("Run",true);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            SmoothRotation(cameraDirection.eulerAngles.y + 180);
            moveVector = cameraDirection.forward * -playerSpeed;
            ant.SetBool("Run", true);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            SmoothRotation(cameraDirection.eulerAngles.y + 90);
            moveVector = cameraDirection.right * playerSpeed;
            ant.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SmoothRotation(cameraDirection.eulerAngles.y + 270);
            moveVector = cameraDirection.right * -playerSpeed;
            ant.SetBool("Run", true);
        }
        else
        {
            moveVector = Vector3.zero;
            ant.SetBool("Run", false);
        }

        rid.position += moveVector * Time.deltaTime;

    }
    //��������Y�b
    private float currentVelocity = 0f;
    public void SmoothRotation(float targetAngle)
    {
        rid.transform.eulerAngles = 
            new Vector3(0,Mathf.SmoothDampAngle(rid.transform.eulerAngles.y,targetAngle,ref currentVelocity,playerRotateSpeed),0);
    }




}
