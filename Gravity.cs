using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{

    // The force of gravity which is applied. (Negitive is down, positive is up) 
    [Tooltip("The force of gravity which is applied. (Negitive is down, positive is up)")]
    [SerializeField]
    private float gravityValue;

    [HideInInspector]
    public bool hasGravity = true;

    void FixedUpdate()
    {
        if (!hasGravity)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            Vector2 gravityForce = Vector2.up;
            gravityForce *= gravityValue;
            rigidbody2D.AddForce(gravityForce);
        }
    }

    /// <summary>
    /// Stops the influnce of gravity on the gameobject
    /// </summary>
    public void pauseGravity()
    {
        hasGravity = false;
    }

    /// <summary>
    /// Resumes the influnce of gravity on the gameobject
    /// </summary>
    public void unpauseGravity()
    {
        hasGravity = true;
    }
}
