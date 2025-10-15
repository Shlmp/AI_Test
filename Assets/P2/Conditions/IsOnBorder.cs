using UnityEngine;

[CreateAssetMenu(fileName = "IsOnBorder", menuName = "FSM/Conditions/IsOnBorderCondition")]
public class IsOnBorder : Condition
{
    public float checkDistance = 0.5f;
    public LayerMask borderMask;

    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.forward);

        return Physics.Raycast(ray, checkDistance, borderMask);
    }
}