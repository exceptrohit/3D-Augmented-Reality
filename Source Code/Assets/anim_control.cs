using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_control : MonoBehaviour
{
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator> ();
    }

    // Update is called once per frame
    public void setidle(){
		animator.SetInteger("condition",0);
	}
    public void setjump(){
		animator.SetInteger("condition",1);
	}
    public void setattack(){
		animator.SetInteger("condition",2);
	}
    void Update()
    {
        
    }
}
