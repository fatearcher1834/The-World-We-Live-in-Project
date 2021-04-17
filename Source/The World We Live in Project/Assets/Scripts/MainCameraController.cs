using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //跟隨目標
    public Transform playerTarget;
    public float cameraSpeedSmooth;
    public Vector3 potionOffset;
    //目標與攝影機距離
    public float distance;

    //滑鼠視角移動
    public float x;
    public float y;
    public float xSpeed; //x靈敏度
    public float ySpeed; //y靈敏度

    public float maxRotationY;
    public float minRotationY;

    private Quaternion rotationEuler;
    public Vector3 cameraPosition;

    //滑鼠滾輪縮放
    public float disSpeed;
    public float maxDistance;
    public float minDistance;


    // Start is called before the first frame update
    void Start()
    {


    }

// Update is called once per frame
void Update()
    {
        //CameraPotion();
        CameraFollowMouse();
        CameraFollowTarget();
        WheelZoom();
    }    
    /*private void CameraPotion()
    {
        cameraPosition = playerTarget.position - distence;
        transform.position = 
            Vector3.Lerp(transform.position, cameraPosition, cameraSpeedSmooth * Time.deltaTime);
    }*/
    private void CameraFollowMouse()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        //方便查看X軸幾度
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

        rotationEuler = Quaternion.Euler(-y, x, 0);
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
