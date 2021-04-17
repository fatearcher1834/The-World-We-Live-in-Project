using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //���H�ؼ�
    public Transform playerTarget;
    public float cameraSpeedSmooth;
    public Vector3 potionOffset;
    //�ؼлP��v���Z��
    public float distance;

    //�ƹ���������
    public float x;
    public float y;
    public float xSpeed; //x�F�ӫ�
    public float ySpeed; //y�F�ӫ�

    public float maxRotationY;
    public float minRotationY;

    private Quaternion rotationEuler;
    public Vector3 cameraPosition;

    //�ƹ��u���Y��
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

        //��K�d��X�b�X��
        if (x > 360)
        {
            x -= 360;
        }else if (x < 0)
        {
            x += 360;
        }
        //������v��Y�b�̤j�̤p��
        y = Mathf.Clamp(y,minRotationY,maxRotationY);

        //�p����v��������ήy��

        rotationEuler = Quaternion.Euler(-y, x, 0);
        cameraPosition = rotationEuler * new Vector3(0,7.5f,-distance) + playerTarget.position;

        transform.rotation = rotationEuler;
        transform.position = cameraPosition;
    }
    private void CameraFollowTarget()
    {
        //��v���ݦV���a��m
        transform.LookAt(playerTarget.position + potionOffset);
    }
    private void WheelZoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance,minDistance,maxDistance);

    }

}
