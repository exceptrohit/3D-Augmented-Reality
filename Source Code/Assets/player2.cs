using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float movementspeed=2f;
    private float currentspeed=0f;
    private float smoothvelocity=0f;
    private float smoothtime=0.1f;
    private float rotationspeed=0.1f;
    private float gravity=3f;
    private float inputx;
     private float inputz;
    private CharacterController controller=null;
    private Animator anim=null;
    private Transform camera =null;
    public FixedJoystick joystick;

    void Start()
    {
        controller=GetComponent<CharacterController>();
        //anim =GetComponent<Animator>():
        anim=GetComponentInChildren<Animator>();
        camera=Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        
        //Vector2 movementinput=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        inputx=joystick.Horizontal;
        inputz=joystick.Vertical;
        Vector2 movementinput=new Vector2(inputx,inputz);


        Vector3 forward =camera.forward;
        Vector3 right=camera.right;
        forward.Normalize();
        right.Normalize();

        Vector3 movedirection=(forward*movementinput.y +right*movementinput.x).normalized;

        Vector3 gravityvector =Vector3.zero;
        /*if(!controller.isGrounded)
        {
            gravityvector.y-=gravity;
        }*/
        if(movedirection!=Vector3.zero)
        {
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movedirection),rotationspeed);
        }
        float targetspeed=movementspeed*movementinput.magnitude;
        currentspeed=Mathf.SmoothDamp(currentspeed,targetspeed,ref smoothvelocity,smoothtime);
        controller.Move(movedirection*currentspeed*Time.deltaTime);
        controller.Move(gravityvector*Time.deltaTime);

        if(inputz==0)
        {
            
            anim.SetBool("walk_condition",false);
            //anim.SetFloat("condition",10,smoothtime,Time.deltaTime);
            //anim.SetInteger("condition",10);
            
        }
        else
        {
            anim.SetInteger("condition",-1);
            anim.SetBool("walk_condition",true );
            
        }
    }
}
