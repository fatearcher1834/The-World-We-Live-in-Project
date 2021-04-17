using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //人物速度
    public int playerSpeed;
    public float playerRotateSpeed;
    private Vector3 moveVector;

    private Rigidbody rid;
    private Animator ant;

    //取得攝影機方向
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
        //取得攝影機位置
        mainCameraTranform = Camera.main.transform;
        //產生物件>該物件方向與攝影機相同
        GameObject cameraDirectionObject = new GameObject();
        cameraDirectionObject.transform.parent = transform;
        cameraDirectionObject.transform.localPosition = Vector3.zero;
        cameraDirectionObject.name = "Direction";
        cameraDirection = cameraDirectionObject.transform;
    }
    private void GetCameraDirection()
    {
        //更新cameraDirection的旋轉角度>只取主攝影機的Y值
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
    //平順旋轉Y軸
    private float currentVelocity = 0f;
    public void SmoothRotation(float targetAngle)
    {
        rid.transform.eulerAngles = 
            new Vector3(0,Mathf.SmoothDampAngle(rid.transform.eulerAngles.y,targetAngle,ref currentVelocity,playerRotateSpeed),0);
    }




}
