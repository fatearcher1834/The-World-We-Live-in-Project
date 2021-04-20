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
     
    //���o��v����V
    private Transform mCamTra;
    private Transform camDir;

    //���a�ާ@UI�]�w
    public GameObject playerBag;
    public bool isOpen;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
        ant = GetComponent<Animator>();

        GetCameraDirectionObj();
    }

    //���z
    void FixedUpdate()
    {
        GetCameraDirection();
        GroundMovement();
    }
    private void GetCameraDirectionObj()
    {
        //���o��v����m
        mCamTra = Camera.main.transform;
        //���ͪ���A�Ӫ����V�P��v���ۦP
        GameObject cameraDirectionObject = new GameObject();
        cameraDirectionObject.transform.parent = transform;
        cameraDirectionObject.transform.localPosition = Vector3.zero;
        cameraDirectionObject.name = "Direction";
        camDir = cameraDirectionObject.transform;
    }
    private void GetCameraDirection()
    {
        //��scameraDirection�����ਤ��>�u���D��v����Y��
        if (mCamTra)
        {
            camDir.eulerAngles = new Vector3(0, mCamTra.eulerAngles.y, 0);
        }
    }
    private void GroundMovement()
    {
        //���o����^�ǭ�(1,0,-1)
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        //�z�L�t�ȱo��ϦV��� moveVector.Y�w�]��0
        moveVector = 
            (camDir.right * horizontalMove + camDir.forward * verticalMove) * playerSpeed ; //��v����V����m * �t��
        //�N���a�t�׳]��moveVector
        rid.velocity = moveVector;
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

    //�Y�ɥ\��
    private void Update()
    {
        OpenPlayerBag();
    }




}
