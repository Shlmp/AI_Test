using UnityEngine;

[CreateAssetMenu(fileName = "IsOnBorderLeft", menuName = "FSM/Conditions/IsOnBorderLeftCondition")]
public class IsOnBorderLeft : Condition
{
    public float checkDistance = 0.5f;
    public LayerMask borderMask;

    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.left);

        return Physics.Raycast(ray, checkDistance, borderMask);
    }
}