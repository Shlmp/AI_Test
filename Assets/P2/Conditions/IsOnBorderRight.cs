using UnityEngine;

[CreateAssetMenu(fileName = "IsOnBorderRight", menuName = "FSM/Conditions/IsOnBorderRightCondition")]
public class IsOnBorderRight : Condition
{
    public float checkDistance = 0.5f;
    public LayerMask borderMask;

    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.right);

        return Physics.Raycast(ray, checkDistance, borderMask);
    }
}