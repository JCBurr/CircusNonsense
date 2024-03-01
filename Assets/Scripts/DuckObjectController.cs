using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DuckObjectController : MonoBehaviour
{
    private Rigidbody duckRigidBody;

    // Start is called before the first frame update
    public void OnEnable()
    {
        duckRigidBody = gameObject.GetComponent<Rigidbody>();
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
            // reset the moving Rigidbody
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.velocity = new Vector3(0f, 0f, 0f);
            rBody.angularVelocity = new Vector3(0f, 0f, 0f);

            // release the projectile back to the pool
            gameObject.SetActive(false);
        }
    }

    public int movementTargetDirection;

}
