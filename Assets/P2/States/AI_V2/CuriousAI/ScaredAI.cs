using UnityEngine;

[CreateAssetMenu(fileName = "ScaredAI", menuName = "FSM/States/AI_V2/Curious/ScaredAI")]
public class ScaredAI : State
{
    public float fleeSpeed = 5f;
    private Color scaredColor = Color.red;

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai != null)
        {
            ai.SetScaredTimer();
            SetColor(ai, scaredColor);
            Debug.Log("AI is scared and running away!");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<CuriousAIController>();
        if (ai == null || ai.player == null) return;

        Vector3 dir = (ai.transform.position - ai.player.position).normalized;
        ai.transform.position += dir * fleeSpeed * Time.deltaTime;
    }

    private void SetColor(CuriousAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer) renderer.material.color = color;
    }
}
