using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerClose", menuName = "FSM/Conditions/AI_V2/Curious/IsPlayerClose")]
public class IsPlayerClose : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        return ai != null && ai.PlayerIsClose();
    }
}
