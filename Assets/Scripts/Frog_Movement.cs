using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Frog_Movement : MonoBehaviour
{
    private float horizantolMovement;
    private float verticalMovement;
    private Vector3 desiredDirections;
    private Animator frogAnimator;
    private Rigidbody frogRigidBody;
    [SerializeField]private float turnSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        //Gather the Animator component from frog gameobject
        frogAnimator = GetComponent<Animator>();
        frogRigidBody = GetComponent<Rigidbody>();
        frogAnimator.SetBool("IsIdle",true);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gathering the Input from player
        horizantolMovement=Input.GetAxisRaw("Horizontal");
        verticalMovement=Input.GetAxisRaw("Vertical");

        //Calculating the desired direction for frog
        desiredDirections = new Vector3(horizantolMovement,0,verticalMovement);
        
       

        
    }

    void FixedUpdate(){
        //if the desired direction is zero...
        if(desiredDirections==Vector3.zero){
            //then set the animation state to Idle
            frogAnimator.SetBool("IsIdle",true);

        }
        else{
            //calculate the rotation by the frog should rotate to look in the desired direction
            Quaternion targetRotation = Quaternion.LookRotation(desiredDirections,Vector3.up);

            //Calculate another rotation that will rotate frog from its current rotation to targetrotation over a certion period  of time
            Quaternion newRotation = Quaternion.Lerp(frogRigidBody.rotation,targetRotation,turnSpeed*Time.fixedDeltaTime);
            //rotate our frog
            frogRigidBody.MoveRotation(targetRotation);
            //else set the IsIdle parameter to false (Frog Hop)
            frogAnimator.SetBool("IsIdle",false);
        }
    }
}
