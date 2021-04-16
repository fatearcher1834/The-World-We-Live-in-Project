using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //�H�����ʳt��
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
        //���o��L�^�ǭ�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //��L����+����
        Move(h, v);
        Turn(h, v);

    }
    private void Move(float h,float v)
    {
        if (h !=0 || v !=0) 
        { 
            //�N��L�^�ǭ��ର�V�q�í��W�t��>�ܦ��C���Ӥ�V����
            Vector3 movement = new Vector3(h, 0, v);
            movement = movement * playerSpeed * Time.deltaTime;
            //�H����m�[�W�C���Ӥ�V����>�Φ��C���ʶZ��
            rid.MovePosition(transform.position + movement);
            //�]�B�ʵe�}��
            ant.SetBool("Run",true);
        }
        else
        {
            //�]�B�ʵe����
            ant.SetBool("Run", false);
        }
    }
    private void Turn(float h, float v)
    {
        //���첾�ɡA������V��첾������V
        if (h !=0 || v !=0) 
        {
            Quaternion quternionNote = Quaternion.LookRotation(new Vector3(h, 0, v));
            rid.MoveRotation(Quaternion.Lerp(transform.rotation,quternionNote,playerRotateSpeed));
        }
    }
    /*private void CameraTurn()
    {
        //���o�ƹ�
        float h = Input.GetAxisRaw("Mouse X");
        Debug.Log(h);
  
    }*/




}
