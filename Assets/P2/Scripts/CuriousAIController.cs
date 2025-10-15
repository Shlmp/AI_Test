using UnityEngine;

public class CuriousAIController : MonoBehaviour
{
    public Transform player;
    public float viewRadius = 5f;
    public float fleeDistance = 3f;
    public float wanderRadius = 10f;

    [HideInInspector] public Transform targetInterest;
    private float scaredTimer;
    public float scaredDuration = 5f;

    private void Update()
    {
        // Timer for scared recovery
        if (scaredTimer > 0f)
            scaredTimer -= Time.deltaTime;
    }

    public bool PlayerIsClose()
    {
        if (player == null) return false;
        return Vector3.Distance(transform.position, player.position) < fleeDistance;
    }

    // Searches GameObjects with tag "Interest"
    public bool IsNearInterest()
    {
        GameObject[] interests = GameObject.FindGameObjectsWithTag("Interest");
        if (interests == null || interests.Length == 0)
        {
            targetInterest = null;
            return false;
        }

        Transform nearest = null;
        float bestDist = float.MaxValue;
        Vector3 myPos = transform.position;

        foreach (var go in interests)
        {
            if (go == null) continue;
            float d = Vector3.Distance(myPos, go.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                nearest = go.transform;
            }
        }

        // If the nearest interest is within viewRadius, choose it; otherwise none
        if (nearest != null && bestDist <= viewRadius)
        {
            targetInterest = nearest;
            return true;
        }
        else
        {
            targetInterest = null;
            return false;
        }
    }

    public bool CanStopBeingScared()
    {
        if (player == null) return false;
        float distance = Vector3.Distance(transform.position, player.position);
        return distance > fleeDistance * 2 && scaredTimer <= 0f;
    }

    public void SetScaredTimer()
    {
        scaredTimer = scaredDuration;
    }

    // Get random position nearby (keeps the same Y as the AI)
    public Vector3 GetRandomWanderPoint()
    {
        Vector2 random = Random.insideUnitCircle * wanderRadius;
        return new Vector3(random.x + transform.position.x, transform.position.y, random.y + transform.position.z);
    }
}
