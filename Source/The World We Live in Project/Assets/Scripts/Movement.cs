using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //�H���t��
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

    //���z
    void FixedUpdate()
    {
        GroundMovement();

    }
    //��v��v���e��V�q��Htransform.up���k�V�q���������V�q
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
        //���o����^�ǭ�(1,0,-1)
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        //�z�L�t�ȱo��ϦV��� moveVector.Y�w�]��0  
        moveVector = 
            (CamForwardOnPlane * verticalMove + CamRightOnPlane * horizontalMove) * playerSpeed;

        rid.velocity = moveVector;  //�N���a�t�׳]��moveVector

        //���U��������ɡA�]�w�ʵe�M��V
        if (horizontalMove != 0 || verticalMove !=0)
        {
            Quaternion LookAngle = Quaternion.LookRotation(moveVector); //���o���VmoveVector�����ਤ�� 
            rid.rotation = Quaternion.RotateTowards(rid.rotation, LookAngle, playerRSpeed); //�ѥثe���ץ������LookAngle���� *����:�H�̵u�Z������
            ant.SetBool("Run", true);
        }
        else
        {
            ant.SetBool("Run", false);
        }
    }


}
