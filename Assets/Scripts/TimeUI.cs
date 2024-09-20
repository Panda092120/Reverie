using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TimeState { Morning, Afternoon, Night}
public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TimeState state;

    // Start is called before the first frame update
    void Start()
    {
        state = TimeState.Morning;
        
    }


    private void OnEnable()
    {
        TimeManager.onTimeChange += UpdateTime;
        
    }

    private void OnDisable()
    {
        TimeManager.onTimeChange -= UpdateTime;
        
    }
    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.currTime}";
    }

    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    public Transform target;

    private Vector3 vel = Vector3.zero;
    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition,
            ref vel, damping);

    }
}
