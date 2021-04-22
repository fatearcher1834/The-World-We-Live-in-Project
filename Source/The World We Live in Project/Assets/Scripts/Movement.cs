using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //人物速度
    public float playerSpeed = 5;
    public float playerRSpeed = 15;
    private Vector3 moveVector;

    private Rigidbody rid;
    private Animator ant;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
        ant = GetComponent<Animator>();


    }

    //物理
    void FixedUpdate()
    {
        GroundMovement();

    }
    //投影攝影機前方向量到以transform.up為法向量之平面的向量
    public Vector3 CamForwardOnPlane
    {
        get
        {
            return Vector3.ProjectOnPlane( Camera.main.transform.forward, Vector3.up).normalized; 
        }
    }
    public Vector3 CamRightOnPlane
    {
        get
        {
            return Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;
        }
    }
    private void GroundMovement()
    {
        //取得按鍵回傳值(1,0,-1)
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        //透過負值得到反向方位 moveVector.Y預設為0  
        moveVector = 
            (CamForwardOnPlane * verticalMove + CamRightOnPlane * horizontalMove) * playerSpeed;

        rid.velocity = moveVector;  //將玩家速度設為moveVector

        //按下對應按鍵時，設定動畫和轉向
        if (horizontalMove != 0 || verticalMove !=0)
        {
            Quaternion LookAngle = Quaternion.LookRotation(moveVector); //取得面向moveVector的旋轉角度 
            rid.rotation = Quaternion.RotateTowards(rid.rotation, LookAngle, playerRSpeed); //由目前角度平順轉到LookAngle角度 *平順:以最短距離旋轉
            ant.SetBool("Run", true);
        }
        else
        {
            ant.SetBool("Run", false);
        }
    }


}
