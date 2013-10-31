using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    public KeyCode JumpKey;

    private Platform lastPlatform;

    public void JumpToRandomPlatform()
    {
        Debug.Log(Platform.Platforms.Count);
        int randomPlatformIndex = Random.Range(0, Platform.Platforms.Count);
        Platform platform = Platform.Platforms[randomPlatformIndex];
        if (platform == lastPlatform)
        {
            randomPlatformIndex = (randomPlatformIndex + 1) % Platform.Platforms.Count;
            platform = Platform.Platforms[randomPlatformIndex];
        }
        lastPlatform = platform;

        Vector3 velocity = TrajectoryHelper.GetTrajectoryVelocity(transform.position, platform.JumpTo, 2.0f, Physics.gravity);
        rigidbody.AddForce(velocity, ForceMode.Impulse);
    }

    void Update()
    {
        if(Input.GetKeyDown(JumpKey))
        {
            rigidbody.velocity = new Vector3();
            JumpToRandomPlatform();
        }
    }
}
