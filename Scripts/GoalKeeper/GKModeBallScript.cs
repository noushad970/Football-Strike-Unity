using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKModeBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;   // The target object
    public float kickForce = 10f;  // The force with which the sphere will be kicked
    public KeyCode kickButton = KeyCode.Space;  // The button to press to kick the sphere

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(kickButton))
        {
            KickTowardsTarget();
        }
    }

    void KickTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.AddForce(direction * kickForce, ForceMode.Impulse);
    }
}
