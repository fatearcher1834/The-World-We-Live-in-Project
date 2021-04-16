using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //人物移動速度
    public int playerSpeed;
    public float playerRotateSpeed;
    //public bool cameraCanTurn;


    private Rigidbody rid;
    private Animator ant;
    void Start()
    {
        rid = GetComponent<Rigidbody>();
        ant = GetComponent<Animator>();

    }
    void Update()
    {
        //取得鍵盤回傳值
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //鍵盤移動+旋轉
        Move(h, v);
        Turn(h, v);

    }
    private void Move(float h,float v)
    {
        if (h !=0 || v !=0) 
        { 
            //將鍵盤回傳值轉為向量並乘上速度>變成每秒往該方向移動
            Vector3 movement = new Vector3(h, 0, v);
            movement = movement * playerSpeed * Time.deltaTime;
            //人物位置加上每秒往該方向移動>形成每秒移動距離
            rid.MovePosition(transform.position + movement);
            //跑步動畫開啟
            ant.SetBool("Run",true);
        }
        else
        {
            //跑步動畫關閉
            ant.SetBool("Run", false);
        }
    }
    private void Turn(float h, float v)
    {
        //當有位移時，角色轉向到位移對應方向
        if (h !=0 || v !=0) 
        {
            Quaternion quternionNote = Quaternion.LookRotation(new Vector3(h, 0, v));
            rid.MoveRotation(Quaternion.Lerp(transform.rotation,quternionNote,playerRotateSpeed));
        }
    }
    /*private void CameraTurn()
    {
        //取得滑鼠
        float h = Input.GetAxisRaw("Mouse X");
        Debug.Log(h);
  
    }*/




}
