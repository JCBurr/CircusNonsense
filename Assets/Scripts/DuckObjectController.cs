using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DuckObjectController : MonoBehaviour
{
    private Rigidbody duckRigidBody;

    public int movementTargetDirection;

    public event EventHandler OnDuckHitByProjectile;

    [SerializeField] IntEventChannel duckScoreChannel;

    // Start is called before the first frame update
    public void OnEnable()
    {
        duckRigidBody = gameObject.GetComponent<Rigidbody>();

        // Needs work - this only currently works in testing with the shooting gallery
        // in a set location and rotation.
        // DuckSpawner.cs sets this direction value during the spawn function
        if(movementTargetDirection == 1)
        {
            duckRigidBody.velocity = new Vector3(1.0f, 0.0f, 0.0f);
        }
        else
        {
            duckRigidBody.velocity = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            // Reset the moving Rigidbody
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.velocity = new Vector3(0f, 0f, 0f);
            rBody.angularVelocity = new Vector3(0f, 0f, 0f);

            // Trigger the "Duck hit" event. The UI controller will subscribe to this
            // event and will handle the score update when a duck is hit
            OnDuckHitByProjectile?.Invoke(this, EventArgs.Empty);

            publishDuckScoreIncrease();

            // Release the projectile back to the pool
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "ShootingGallery")
        {
            // Reset the moving Rigidbody
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.velocity = new Vector3(0f, 0f, 0f);
            rBody.angularVelocity = new Vector3(0f, 0f, 0f);

            // Release the projectile back to the pool
            gameObject.SetActive(false);
        }
    }

    private void publishDuckScoreIncrease()
    {
        Debug.Log("DuckScoreIncrease event run");
        // Pass the score to add into the duckScoreChannel EventChannel
        // Using "1" as a test value, can eventually add ducks with differing scores
        duckScoreChannel.Invoke(1);
    }
    

}
