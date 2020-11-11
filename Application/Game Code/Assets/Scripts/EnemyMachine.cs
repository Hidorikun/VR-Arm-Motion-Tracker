using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachine : MonoBehaviour
{
    public Transform muzzle;
    public Rigidbody ball; 
    public float timer = 5.0f; // 1 every 5 sec
    private float currentTimer; 
    public float shootForce = 10.0f; 

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer; 
    }

    void Shoot()
    {
        Rigidbody shot = Instantiate(ball, muzzle.position, muzzle.rotation) as Rigidbody;
        // Destroy(Instantiate(muzzleFlash, shotPosition.position, shotPosition.rotation), 1);
        shot.AddForce(muzzle.forward * shootForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer <= 0)
        {
            Shoot();
            currentTimer = timer; 
        }

        currentTimer = currentTimer - Time.deltaTime;

    }
}
