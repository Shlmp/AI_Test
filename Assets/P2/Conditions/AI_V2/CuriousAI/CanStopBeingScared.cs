using UnityEngine;

[CreateAssetMenu(fileName = "CanStopBeingScared", menuName = "FSM/Conditions/AI_V2/Curious/CanStopBeingScared")]
public class CanStopBeingScared : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        return ai != null && ai.CanStopBeingScared();
    }
}
