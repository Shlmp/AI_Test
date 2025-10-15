using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "FSM/States/State")]
public class MoveForwardState : State
{
    public float speed = 2f;

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.blackboard.Set("RoombaBattery", 100f);
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.forward * speed * Time.deltaTime, Space.Self);
        stateMachine.blackboard.Set("RommbaBattery", stateMachine.blackboard.Get<float>("RoombaBattery"));
    }
}

public static class BBKeys
{
    public const float Battery = 0;
}