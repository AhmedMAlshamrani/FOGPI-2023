using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float distanceMultiplier = 2.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetScreenPosition = Input.mousePosition;
            Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(targetScreenPosition.x, targetScreenPosition.y, Camera.main.transform.position.y));

            Vector3 delta = targetWorldPosition - transform.position;
            delta.y = 0;

            float distance = delta.magnitude;
            float adjustedSpeed = movementSpeed + (distance * distanceMultiplier);
            //float maxDist = Time.fixedDeltaTime * adjustedSpeed;
            //delta = delta.normalized * Mathf.Min(distance, maxDist);

            //rb.MovePosition(transform.position + delta);
            rb.AddForce(delta * movementSpeed);
        }
    }
}
