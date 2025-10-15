using UnityEngine;

[CreateAssetMenu(fileName = "MoveBackwardsState", menuName = "FSM/States/MoveBackwardsState")]
public class MoveBackwardsState : State
{
    public float speed = 2f;

    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate((stateMachine.transform.forward * -1) * speed * Time.deltaTime, Space.Self);
    }
}
