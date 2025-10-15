using UnityEngine;

[CreateAssetMenu(fileName = "AnnoyedAI", menuName = "FSM/States/AI_V2/AnnoyedAI")]
public class AnnoyedAI : State
{
    public float backOffSpeed = 2f;
    public float minDistance = 3f;

    private Color annoyedColor = new Color(1f, 0.5f, 0f); // Orange

    public override void EnterState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai != null)
        {
            SetColor(ai, annoyedColor);
            Debug.Log("AI is Annoyed!");
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var ai = stateMachine.GetComponent<EmotionalAIController>();
        if (ai == null || ai.player == null) return;

        float distance = Vector3.Distance(ai.transform.position, ai.player.position);

        // Move away from player if too close
        if (distance < minDistance)
        {
            Vector3 dir = (ai.transform.position - ai.player.position).normalized;
            ai.transform.position += dir * backOffSpeed * Time.deltaTime;
        }
    }

    private void SetColor(EmotionalAIController ai, Color color)
    {
        var renderer = ai.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
