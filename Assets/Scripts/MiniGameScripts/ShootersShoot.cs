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
    [SerializeField] private int burstCount;
    [SerializeField] private int bulletsPerBurst;
    [SerializeField] [Range(0,359)] private float angleSpread;
    
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private float startingDistance = 0.1f;
    [SerializeField] private float timeBetweenBullets;
    [SerializeField] private float restTime;

    [SerializeField] private bool oscillate;
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

        float startAngle, curAngle, angleStep, endAngle;
        ConeOfInfluence(out startAngle, out curAngle, out angleStep, out endAngle);

        if (!oscillate)
        {
            ConeOfInfluence(out startAngle, out curAngle, out angleStep, out endAngle);
        }
        else
        {
            curAngle = endAngle;
            endAngle = startAngle;
            startAngle = curAngle;
            angleStep *= -1;
        }
        
        for (int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < bulletsPerBurst; j++)
            {
                Vector2 pos = FindBUlletSpawnPos(curAngle);
            
                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                
                newBullet.transform.right = newBullet.transform.position - transform.position;
                
                Vector2 dir = new Vector2(Mathf.Cos(curAngle * Mathf.Deg2Rad), Mathf.Sin(curAngle * Mathf.Deg2Rad));
                //UpdateMoveSpeed(bulletMoveSpeed);
                newBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletMoveSpeed;
            
                curAngle += angleStep;
            }

            curAngle = startAngle;
            yield return new WaitForSeconds(timeBetweenBullets);
            ConeOfInfluence(out startAngle, out curAngle, out angleStep, out endAngle);
        }
        yield return new WaitForSeconds(restTime);
        isShooting = false;
       
    }

    private Vector2 FindBUlletSpawnPos(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector2 pos = new Vector2(x,y);
        return pos;
    }

    private void ConeOfInfluence(out float startAngle, out float curAngle, out float angleStep, out float endAngle)
    {
        Vector2 targetDir = target.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        curAngle = targetAngle;
        
        float halfAngle = 0f;
        angleStep = 0;

        if (angleSpread != 0)
        {
            angleStep = angleSpread / (bulletsPerBurst - 1);
            halfAngle = angleSpread / 2f;
            startAngle = targetAngle - halfAngle;
            endAngle = targetAngle + halfAngle;
            curAngle = startAngle;
        }
    }
}
