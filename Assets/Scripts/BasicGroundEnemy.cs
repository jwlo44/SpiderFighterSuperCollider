using UnityEngine;
using System.Collections;

public class BasicGroundEnemy : MonoBehaviour {

  private Vector2 vel = new Vector2(10, 0);
  private float MAX_VELOCITY = 10f;
  private float accel = 5f;
  private float direction = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

    if (Mathf.Abs (rigidbody2D.velocity.x) < MAX_VELOCITY)
    {
      this.rigidbody2D.AddForce (new Vector2 (accel * direction, 0));
    }
    else
    {
      this.rigidbody2D.velocity = new Vector2 (MAX_VELOCITY * direction, rigidbody2D.velocity.y);
    }
	}

  void OnCollisionEnter2D (Collision2D col) {
    if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Breakable" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player") {
      this.direction *= -1f;
    }
  }
}
