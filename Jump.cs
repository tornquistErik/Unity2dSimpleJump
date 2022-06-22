using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gravity))]
public class Jump : MonoBehaviour
{
    // The height of the jump over the jumpTime 
    [Tooltip("The height of the jump over the jumpTime ")]
    public AnimationCurve jumpHeight;

    // The time it takes to reach the apex of the jump 
    [Tooltip("The time it takes to reach the apex of the jump ")]
    public float jumpTime;
    
    // The multiplier applied to the jumpHeight 
    [Tooltip("The multiplier applied to the jumpHeight ")]
    public float jumpHeightMultiplier;

    private float jumpTimeCurrent;

    private float jumpTimeStart;

    private Vector3 jumpStartPosition;

    private bool isJumping;

    // Update is called once per frame
    void Update()
    {
        jump();
    }

    /// <summary>
    /// Check if the user can jump and is attempting to do so, then
    /// move the transforms height through the animation curve until
    /// the jump time is reached
    /// </summary>
    void jump()
    { 
        Gravity grav = GetComponent<Gravity>();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            grav.pauseGravity();
            jumpTimeStart = Time.time;
            jumpTimeCurrent = jumpTimeStart;
            jumpStartPosition = transform.position;
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Space) && jumpTimeCurrent - jumpTimeStart < jumpTime && isJumping)
        {
            jumpTimeCurrent += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, jumpStartPosition.y + ((jumpHeight.Evaluate((jumpTimeCurrent - jumpTimeStart) / jumpTime)) * jumpHeightMultiplier), transform.position.z);
        }
        else
        {
            grav.unpauseGravity();
            isJumping = false;
        }
    }

    /// <summary>
    /// Check if the user is grounded
    /// </summary>
    /// <returns>Is the user grounded</returns>
    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector3.down, .6f);
    }
}
