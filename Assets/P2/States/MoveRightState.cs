using UnityEngine;

[CreateAssetMenu(fileName = "MoveRightState", menuName = "FSM/States/MoveRightState")]
public class MoveRightState : State
{
    public float speed = 2f;

    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.right * speed * Time.deltaTime, Space.Self);
    }
}
