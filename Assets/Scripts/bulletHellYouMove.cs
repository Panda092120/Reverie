using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //NEW

public class BulletHellYouMove : MonoBehaviour
{
	[SerializeField] private float BASE_SPEED = 5;
	private Rigidbody2D rb;

	float currentSpeed;
	//NEW
	//private bool isGrounded = false;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		currentSpeed = BASE_SPEED;

		
	}
	
	public IEnumerator SpeedChange(float newSpeed, float timeInSecs)
	{
		currentSpeed = newSpeed;
		yield return new WaitForSeconds(timeInSecs);
		currentSpeed = BASE_SPEED;
	}

	//NEW
	//private void OnCollisionStay2D(Collision2D collision)
	//{
	//    isGrounded = true;
	//}

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 dir = new Vector3(horizontal, vertical, 0);

		//rb.velocity = dir * currentSpeed;
		//NEW
		rb.velocity = new Vector2((dir * currentSpeed).x, (dir * currentSpeed).y);

		if (horizontal < 0)
		{
			this.transform.rotation = new Quaternion(0, -1, 0, 0);
		}
		else if(horizontal > 0)
		{
			this.transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		else if (vertical < 0)
		{
			this.transform.rotation = new Quaternion(0, 1, 0, 0);
		}
		else if (vertical > 0)
		{
			this.transform.rotation = new Quaternion(0, -1, 0, 0);
		}
	}
}