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
     
    //取得攝影機方向
    private Transform mCamTra;
    private Transform camDir;

    //玩家操作UI設定
    public GameObject playerBag;
    public bool isOpen;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
        ant = GetComponent<Animator>();

        GetCameraDirectionObj();
    }

    //物理
    void FixedUpdate()
    {
        GetCameraDirection();
        GroundMovement();
    }
    private void GetCameraDirectionObj()
    {
        //取得攝影機位置
        mCamTra = Camera.main.transform;
        //產生物件，該物件方向與攝影機相同
        GameObject cameraDirectionObject = new GameObject();
        cameraDirectionObject.transform.parent = transform;
        cameraDirectionObject.transform.localPosition = Vector3.zero;
        cameraDirectionObject.name = "Direction";
        camDir = cameraDirectionObject.transform;
    }
    private void GetCameraDirection()
    {
        //更新cameraDirection的旋轉角度>只取主攝影機的Y值
        if (mCamTra)
        {
            camDir.eulerAngles = new Vector3(0, mCamTra.eulerAngles.y, 0);
        }
    }
    private void GroundMovement()
    {
        //取得按鍵回傳值(1,0,-1)
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        //透過負值得到反向方位 moveVector.Y預設為0
        moveVector = 
            (camDir.right * horizontalMove + camDir.forward * verticalMove) * playerSpeed ; //攝影機方向的位置 * 速度
        //將玩家速度設為moveVector
        rid.velocity = moveVector;
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

    void OpenPlayerBag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            playerBag.SetActive(isOpen);
        }
    }
    public void ClosePlayerBag()
    {
        isOpen = false;
    }

    //即時功能
    private void Update()
    {
        OpenPlayerBag();
    }




}
