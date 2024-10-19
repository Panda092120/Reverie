using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{

    public float targetTimer;
    public GameObject parent;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        targetTimer -= Time.deltaTime;
        if(targetTimer <= 0)
        {
            Destroy(parent);
        }
    }
}
