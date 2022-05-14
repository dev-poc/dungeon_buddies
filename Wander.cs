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
        moveTarget=transform.position + Vector3.forward * Random.Range((wanderDistance/4),wanderDistance);

    }


    public override TaskStatus OnUpdate()
    {

       // return TaskStatus.Success;


        return TaskStatus.Failure;
    }
}
