using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // How fast the projectile should move. Set in the Editor
    public float shootForce;

    // How many seconds the projectile should exist for before despawning
    // and returning to the object pool
    public float delay  = 2;

    void OnEnable()
    {
        // Shoot the projectile with a physics based velocty along its forward direction
        // The FirstPersonController script sets the position and rotation of the projectile
        // to be at the spawn location and facing the crosshair target before the projectile
        // is enabled.
        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootForce, ForceMode.Impulse);
        StartCoroutine(DeactivateRoutine(delay));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // On collision, turn on gravity so the ball bounces
        // Gravity is off for projectiles by default to improve aiming
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.useGravity = true;
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        // Delay the deactivation so the projectile exists in the world
        // for a set time before despawing
        yield return new WaitForSeconds(delay);

        // Reset the moving Rigidbody
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.velocity = new Vector3(0f, 0f, 0f);
        rBody.angularVelocity = new Vector3(0f, 0f, 0f);

        // Turn gravity back off on despawn, ready for next spawn
        rBody.useGravity = false;


        // release the projectile back to the pool
        gameObject.SetActive(false);
    }

}
