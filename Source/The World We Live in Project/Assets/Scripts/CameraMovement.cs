using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float cameraSpeed;
    public  Vector3 cameraOffest;
    
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset =   target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,target.position - offset,cameraSpeed * Time.deltaTime);
        transform.LookAt(target.position + cameraOffest);
    }
    private void CamerTurn()
    {
        float h = Input.GetAxisRaw("Mouse X");

    }


}
