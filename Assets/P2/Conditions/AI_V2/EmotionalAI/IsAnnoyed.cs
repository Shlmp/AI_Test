using UnityEngine;

[CreateAssetMenu(fileName = "IsAnnoyed", menuName = "FSM/Conditions/AI_V2/IsAnnoyed")]
public class IsAnnoyed : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        return ai != null && ai.IsAnnoyed();
    }
}
