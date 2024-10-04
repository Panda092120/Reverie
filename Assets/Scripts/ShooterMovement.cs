using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] routes;
    [SerializeField] float speed = 10f;

    private int routeIndex;
    // Start is called before the first frame update
    void Start()
    {
       transform.position = routes[routeIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (routeIndex <= routes.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, routes[routeIndex].transform.position,
                speed * Time.deltaTime);
            if (transform.position == routes[routeIndex].transform.position)
            {
                routeIndex++;
            }
        }

        if (routeIndex == routes.Length)
        {
            routeIndex = 0;
        }
    }
}
