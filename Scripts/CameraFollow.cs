using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    private Vector3 offset;
    private float y;
    public float SpeedFollow = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = ObjectSpawner.ballLocation;
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followPos = target.position + offset;
        RaycastHit hit;
        if (Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
        {

            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * SpeedFollow);

        }
        else y = Mathf.Lerp(y, target.position.y, Time.deltaTime * SpeedFollow);
        followPos.y = offset.y + y;
        transform.position = followPos;
    }
}
