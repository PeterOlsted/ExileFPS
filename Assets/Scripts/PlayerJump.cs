using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    public KeyCode JumpKey;
    public void JumpToRandomPlatform()
    {
        Debug.Log(Platform.Platforms.Count);
        Platform platform = Platform.Platforms[Random.Range(0, Platform.Platforms.Count)];

        Vector3 velocity = TrajectoryHelper.GetTrajectoryVelocity(transform.position, platform.JumpTo, 2.0f, Physics.gravity);
        Debug.Log(velocity);
        rigidbody.AddForce(velocity, ForceMode.Impulse);
    }

    void Update()
    {
        if(Input.GetKeyDown(JumpKey))
        {
            JumpToRandomPlatform();
        }
    }
}
