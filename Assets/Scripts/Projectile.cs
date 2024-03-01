using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float shootForce = 7;

    public float delay  = 2;

    void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootForce, ForceMode.Impulse);
        StartCoroutine(DeactivateRoutine(delay));
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Reset the moving Rigidbody
    //    Rigidbody rBody = GetComponent<Rigidbody>();
    //    rBody.velocity = new Vector3(0f, 0f, 0f);
    //    rBody.angularVelocity = new Vector3(0f, 0f, 0f);

    //    gameObject.SetActive(false);
    //}

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        // reset the moving Rigidbody
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.velocity = new Vector3(0f, 0f, 0f);
        rBody.angularVelocity = new Vector3(0f, 0f, 0f);

        // release the projectile back to the pool
        gameObject.SetActive(false);
    }

}
