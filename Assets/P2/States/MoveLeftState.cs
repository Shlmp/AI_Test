using UnityEngine;

[CreateAssetMenu(fileName = "MoveLeftState", menuName = "FSM/States/MoveLeftState")]
public class MoveLeftState : State
{
    public float speed = 2f;

    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate((stateMachine.transform.right * -1) * speed * Time.deltaTime, Space.Self);
    }
}
