using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private float movespeed;
    private float walkspeed;
    private Vector3 movedirection;
    private Vector3 movement;
    public FixedJoystick joystick;
     public float gravity = 13.0F;
     private float inputx;
     private float inputz;
     private float rotspeed=80;
     private float rot=0f;

    // Start is called before the first frame update
    private CharacterController controller;
    private Animator anim;
    void Start()
    {
        controller =GetComponent<CharacterController>();
        anim=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputx=joystick.Horizontal;
        inputz=joystick.Vertical;
        if(inputz==0)
        {
            anim.SetBool("walk_condition",false);
            
        }
        else
        {
            anim.SetBool("walk_condition",true );
            anim.SetInteger("condition",-1);
        }

        Move();
        
    }
    public void Move()
    {
        //float hoz=joystick.Horizontal;
        //float ver=joystick.Vertical;
        //Vector3 movedirection =new Vector3(0,0,ver).normalized;
        //rot=inputx*rotspeed*Time.deltaTime;
        //controller.transform.eulerAngles=new Vector3(0,rot,0);

        movement=controller.transform.forward*inputz;
        //movedirection=transform.TransformDirection (movedirection);
        
        
        controller.transform.Rotate(Vector3.up*inputx*(100f * Time.deltaTime)); 
        //movedirection*=movespeed;
        controller.Move(movement*5*Time.deltaTime);
        
        
    }

    public void Idle()
    {
        anim.SetInteger("condition",0);
    }
    public void Walk()
    {
        movespeed=5;
        anim.SetInteger("condition",3);
    }
}
