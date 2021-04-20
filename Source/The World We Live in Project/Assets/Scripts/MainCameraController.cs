using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //���H�ؼ�
    public Transform playerTarget;
    public float cameraSpeedSmooth = 5;
    public Vector3 potionOffset;
    //�ؼлP��v���Z��
    public float distance = 30;

    //�ƹ���������
    public float x;
    public float y;
    public float xSpeed = 800; //x�F�ӫ�
    public float ySpeed = 500; //y�F�ӫ�

    public float maxRotationY = 25;
    public float minRotationY = -25;

    private Quaternion rotationEuler;
    public Vector3 cameraPosition;

    //�ƹ��u���Y��
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
        //Ū��X,Y�b�ƹ����ʰT��
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        //X�b���פ��W�L360�A��K�d��X�b
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
        rotationEuler = Quaternion.Euler(-y, x, 0); //�N�ǤJ���ର���סA�Y��Transform��Rotation
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
