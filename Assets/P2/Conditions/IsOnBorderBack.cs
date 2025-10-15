using UnityEngine;

[CreateAssetMenu(fileName = "IsOnBorderBack", menuName = "FSM/Conditions/IsOnBorderBackCondition")]
public class IsOnBorderBack : Condition
{
    public float checkDistance = 0.5f;
    public LayerMask borderMask;

    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.back);

        return Physics.Raycast(ray, checkDistance, borderMask);
    }
}