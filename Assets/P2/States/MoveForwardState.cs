using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "FSM/States/State")]
public class MoveForwardState : State
{
    public float speed = 2f;

    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.forward * speed * Time.deltaTime, Space.Self);
    }
}
