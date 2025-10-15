using UnityEngine;

[CreateAssetMenu(fileName = "WanderAI", menuName = "FSM/States/AI_V2/Curious/WanderAI")]
public class WanderAI : State
{
    public float moveSpeed = 2f;
    public float pointThreshold = 0.5f;
    private Vector3 targetPoint;
    private Color wanderColor = Color.cyan;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai != null)
        {
            SetColor(ai, wanderColor);
            targetPoint = ai.GetRandomWanderPoint();
            Debug.Log("AI is wandering around.");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai == null) return;

        if (Vector3.Distance(ai.transform.position, targetPoint) < pointThreshold)
        {
            targetPoint = ai.GetRandomWanderPoint();
        }

        ai.transform.position = Vector3.MoveTowards(
            ai.transform.position,
            targetPoint,
            moveSpeed * Time.deltaTime);
    }

    private void SetColor(CuriousAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer) renderer.material.color = color;
    }
}
