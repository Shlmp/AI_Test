using UnityEngine;

[CreateAssetMenu(fileName = "IsNearInterest", menuName = "FSM/Conditions/AI_V2/Curious/IsNearInterest")]
public class IsNearInterest : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        return ai != null && ai.IsNearInterest();
    }
}
