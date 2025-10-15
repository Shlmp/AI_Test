using UnityEngine;

[CreateAssetMenu(fileName = "InvestigateAI", menuName = "FSM/States/AI_V2/Curious/InvestigateAI")]
public class InvestigateAI : State
{
    public float moveSpeed = 3f;
    public float stopDistance = 1.5f;
    private Color investigateColor = Color.yellow;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai != null)
        {
            // reset the shared investigation timer in the FSM context
            stateMachine.context.investigationTimer = 0f;

            SetColor(ai, investigateColor);
            Debug.Log("AI is investigating something.");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai == null || ai.targetInterest == null) return;

        float distance = Vector3.Distance(ai.transform.position, ai.targetInterest.position);

        if (distance > stopDistance)
        {
            ai.transform.position = Vector3.MoveTowards(
                ai.transform.position,
                ai.targetInterest.position,
                moveSpeed * Time.deltaTime);
        }
        else
        {
            ai.transform.LookAt(ai.targetInterest);
        }
    }

    private void SetColor(CuriousAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer) renderer.material.color = color;
    }
}
