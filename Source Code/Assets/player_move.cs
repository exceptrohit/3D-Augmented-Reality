using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour

{
    private const float speed=2f;
    private Animator anim;
    public FixedJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            float x=joystick.Horizontal;
            float z=joystick.Vertical;
        
        if(!x.Equals(0) && !z.Equals(0))
        {
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,Mathf.Atan2(x,z)* Mathf.Rad2Deg,transform.eulerAngles.z);
        }
        if(!x.Equals(0) || !z.Equals(0))
        {
            Vector3 movement =new Vector3(x,0,z);
            transform.position+=transform.forward*Time.deltaTime*speed;
            anim.SetInteger("condition",-1);
            anim.SetBool("walk_condition",true );
        }
        else
        {
        anim.SetBool("walk_condition",false);

        }
    }
}
