using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Wander : Action
{
    // Start is called before the first frame update
    private float xLoc,zLoc;
    public SharedVector3 moveTarget;
    [BehaviorDesigner.Runtime.Tasks.Tooltip("How far it wll wander")]
    public float wanderDistance;
    [BehaviorDesigner.Runtime.Tasks.Tooltip("How haphazard will it wander")]
    public float deviateRange;
    void Start()
    {
        xLoc=gameObject.transform.position.x;
        zLoc=gameObject.transform.position.z;

        transform.Rotate(0,  Random.Range(-deviateRange,deviateRange),0,Space.World);
        moveTarget=transform.position + Vector3.forward * Random.Range(0,wanderDistance);

       // Debug.Log(moveTarget+" - - "+transform.position);
    }


    public override TaskStatus OnUpdate()
    {
      //  Vector3 direction = (moveTarget - transform.position).normalized;
      //  transform.LookAt(moveTarget.transform);

        Debug.Log(moveTarget+" - - "+transform.position);
        return TaskStatus.Success;


       // return TaskStatus.Failure;
    }
}