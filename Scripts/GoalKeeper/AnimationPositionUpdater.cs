using UnityEngine;

public class AnimationPositionUpdater : MonoBehaviour
{
    public Animator animator;
    public string animationName;

    void Awake()
    {
        Vector3 finalPosition = GetAnimationFinalPosition(animationName);
        Debug.Log("Final Position: " + finalPosition);
    }

    Vector3 GetAnimationFinalPosition(string animName)
    {
        // Create a temporary GameObject to sample the animation
        GameObject tempObject = new GameObject("TempAnimator");
        Animator tempAnimator = tempObject.AddComponent<Animator>();
        tempAnimator.runtimeAnimatorController = animator.runtimeAnimatorController;

        // Find the animation clip
        AnimationClip clip = null;
        foreach (var animClip in tempAnimator.runtimeAnimatorController.animationClips)
        {
            if (animClip.name == animName)
            {
                clip = animClip;
                break;
            }
        }

        if (clip == null)
        {
            Debug.LogError("Animation clip not found: " + animName);
            Destroy(tempObject);
            return Vector3.zero;
        }

        // Temporarily set the position of the temporary object to match the original object's position
        tempObject.transform.position = transform.position;
        tempObject.transform.rotation = transform.rotation;

        // Sample the last frame of the animation
        clip.SampleAnimation(tempObject, clip.length);

        // Capture the final position
        Vector3 finalPosition = tempObject.transform.position;

        // Clean up the temporary object
        Destroy(tempObject);

        return finalPosition;
    }
}
