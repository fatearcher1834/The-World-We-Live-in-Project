using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //跟隨目標
    public Transform playerTarget;
    public float cameraSpeedSmooth = 5;
    public Vector3 potionOffset;
    //目標與攝影機距離
    public float distance = 30;

    //滑鼠視角移動
    public float x;
    public float y;
    public float xSpeed = 800; //x靈敏度
    public float ySpeed = 500; //y靈敏度

    public float maxRotationY = 25;
    public float minRotationY = -25;

    private Quaternion rotationEuler;
    public Vector3 cameraPosition;

    //滑鼠滾輪縮放
    public float disSpeed = 9000;
    public float maxDistance = 30;
    public float minDistance = 10;

// Update is called once per frame
void Update()
    {
        CameraFollowMouse();
        CameraFollowTarget();
        WheelZoom();

    }    
    private void CameraFollowMouse()
    {
        //讀取X,Y軸滑鼠移動訊息
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        //X軸角度不超過360，方便查看X軸
        if (x > 360)
        {
            x -= 360;
        }else if (x < 0)
        {
            x += 360;
        }
        //限制攝影機Y軸最大最小值
        y = Mathf.Clamp(y,minRotationY,maxRotationY);
        //計算攝影機的旋轉及座標
        rotationEuler = Quaternion.Euler(-y, x, 0); //將傳入值轉為角度，即為Transform的Rotation
        cameraPosition = rotationEuler * new Vector3(0,7.5f,-distance) + playerTarget.position;

        transform.rotation = rotationEuler;
        transform.position = cameraPosition;
    }
    private void CameraFollowTarget()
    {
        //攝影機看向玩家位置
        transform.LookAt(playerTarget.position + potionOffset);
    }
    private void WheelZoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance,minDistance,maxDistance);

    }

}
