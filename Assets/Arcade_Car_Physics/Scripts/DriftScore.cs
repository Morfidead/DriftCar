using UnityEngine;

public class DriftScore : MonoBehaviour
{
    public Rigidbody rb;
    public float minAngle = 15f;
    public float minSpeed = 5f;

    float score, combo;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 v = rb.linearVelocity;
        v.y = 0;
        float speed = v.magnitude;
        float angle = Vector3.Angle(transform.forward, v);

        if (speed > minSpeed && angle > minAngle && angle < 120f)
        {
            combo += Time.fixedDeltaTime;
            score += angle * speed * 0.01f * (1f + combo) * Time.fixedDeltaTime;
        }
        else combo = 0f;
    }

    void OnCollisionEnter(Collision c) => combo = 0f;

    void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.Label(new Rect(20, 20, 600, 120), $"Score: {score:0}\nCombo: x{1 + combo:0.0}");
    }
}