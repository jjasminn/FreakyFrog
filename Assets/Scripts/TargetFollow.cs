using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{   
    [SerializeField]private Transform target;//frog
    [SerializeField]private Vector3 offset;
    [SerializeField]private float followSpeed;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = target.position +offset;
        transform.position = Vector3.Lerp(transform.position,newPosition,followSpeed*Time.deltaTime);//Vector3.lerp smoothed out camera movements
        
    }
}
