using UnityEngine;

[CreateAssetMenu(fileName = "IsHappy", menuName = "FSM/Conditions/AI_V2/IsHappy")]
public class IsHappy : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai == null) return false;

        float distance = Vector3.Distance(ai.transform.position, ai.player.position);
        return ai.IsHappy(distance);
    }
}
