using UnityEngine;

public class CueController : MonoBehaviour
{
    public float maxPower = 10f; // maximum shot power
    public float powerIncrement = 0.1f; // power increase per frame
    public float aimSpeed = 5f; // speed of aiming the cue

    private Vector3 aimDirection; // direction of the cue
    private float shotPower; // current shot power
    private bool aiming; // whether the player is aiming

    private void Start()
{
    GetComponent<Rigidbody>().velocity = Vector3.zero;
}

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            aiming = true;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            aimDirection += new Vector3(mouseX, 0, mouseY) * aimSpeed * Time.deltaTime;
            aimDirection = Vector3.ClampMagnitude(aimDirection, 1f); // limit the length of the aim direction
        }
        else if (aiming && Input.GetMouseButtonUp(0))
        {
            aiming = false;
            GetComponent<Rigidbody>().AddForce(aimDirection * shotPower, ForceMode.Impulse); // apply the shot force to the cue ball
            shotPower = 0f; // reset the shot power
        }

        if (aiming)
        {
            shotPower = Mathf.Clamp(shotPower + powerIncrement, 0f, maxPower); // increase the shot power while the player is holding down the mouse button
        }
    }
}
