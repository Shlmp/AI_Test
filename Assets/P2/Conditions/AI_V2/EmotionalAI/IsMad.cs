using UnityEngine;

[CreateAssetMenu(fileName = "IsMad", menuName = "FSM/Conditions/AI_V2/IsMad")]
public class IsMad : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        return ai != null && ai.IsMad();
    }
}
