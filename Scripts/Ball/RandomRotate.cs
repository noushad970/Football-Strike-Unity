using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of the rotation

    void Update()
    {
        if(BallScript.ballSpin)
            InvokeRepeating("RotateRandomly", 0f, 0.01f);
    }

    void RotateRandomly()
    {
        // Generate random rotation angles
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        // Create a random rotation vector
        Vector3 randomRotation = new Vector3(randomX, randomY, randomZ) * rotationSpeed * Time.deltaTime;

        // Apply the random rotation to the football
        transform.Rotate(randomRotation);
    }
}
