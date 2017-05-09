using UnityEngine;
using System.Collections;

public class GrowBall : MonoBehaviour {
  
  public float MAX_SCALE;
  private float MIN_SCALE;
  
  // Use this for initialization
  void Start () {
    MIN_SCALE = transform.localScale.x;
  }
  
  // Return the scaling factor of the ball
  public float GetDiff() {
    return transform.localScale.x / (MAX_SCALE - MIN_SCALE);
  }
  
  // Update is called once per frame
  void Update () {
    if (transform.localScale.x < MIN_SCALE) {
      transform.localScale = new Vector3(MIN_SCALE, MIN_SCALE, MIN_SCALE);
    }
    bool moving = Mathf.Abs (this.rigidbody2D.velocity.x) > 0 && this.rigidbody2D.velocity.y < 0.01f;
    if (transform.localScale.x < MAX_SCALE && moving) {
      transform.localScale *= getFactor();
    }
    rigidbody2D.mass = transform.localScale.x*3;
  }
  
  // Shrink the ball (call in collision)
  public void Shrink() {
    if (transform.localScale.x > MIN_SCALE) {
      transform.localScale /= getFactor()*2;
    }
  }

  private float getFactor() {
    return 1 + Mathf.Abs(this.rigidbody2D.velocity.x/1000f);
  }
  
}