using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class RangedEnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire = 0f;

    public Transform firingPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (!target)
            GetTarget();
        else
            RotateTowardsTarget();

        if (Vector2.Distance(target.position, transform.position) <= distanceToStop) 
            Shoot();
    }

    private void Shoot()
{
    if (timeToFire <= 0f)
    {
            Debug.Log("Shoot");
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
    }
    else
    {
        timeToFire -= Time.deltaTime;
    }
}
    private void FixedUpdate()
{
        if (target != null)
        {
            // Use Vector2.Distance and correct references to positions
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            rb.linearVelocity = transform.GetChild(0).up * speed;
            else
            rb.linearVelocity = Vector2.zero;
        }
}

    private void RotateTowardsTarget()
    {
        
        Vector2 targetDirection = (Vector2)(target.position - transform.position);
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.GetChild(0).localRotation = Quaternion.Slerp(transform.GetChild(0).localRotation, q, rotateSpeed);
    }
    private void GetTarget()
{       if(GameObject.FindGameObjectWithTag("Player"))
        target = GameObject.FindGameObjectWithTag("Player").transform;


    }


    
}

