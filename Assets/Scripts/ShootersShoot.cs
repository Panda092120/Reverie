using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShootersShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBullets;
    [SerializeField] private float restTime;
    private bool isShooting = false;

    // Update is called once per frame
    public void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        for (int i = 0; i < burstCount; i++)
        {
            Debug.Log("hello");
            Vector2 targetDir = target.transform.position - transform.position;
        
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, quaternion.identity);
            newBullet.transform.right = targetDir;
            
            //UpdateMoveSpeed(bulletMoveSpeed);
            newBullet.GetComponent<Rigidbody2D>().velocity = targetDir.normalized * bulletMoveSpeed;
            yield return new WaitForSeconds(timeBetweenBullets);
        }
        yield return new WaitForSeconds(restTime);
        isShooting = false;
       
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.bulletMoveSpeed = moveSpeed;
    }
}
