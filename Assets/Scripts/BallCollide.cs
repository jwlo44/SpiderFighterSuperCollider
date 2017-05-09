using UnityEngine;
using System.Collections;

// collision handler for the ball
public class BallCollide : MonoBehaviour {
  void OnCollisionEnter2D (Collision2D col)
  {   
    GrowBall ball = gameObject.GetComponent<GrowBall>();
    if (col.gameObject.tag == "Breakable" || col.gameObject.tag == "Enemy") {
      
      // call health script on the breakable
      Health h = col.gameObject.GetComponent<Health>();
      Debug.Log(ball.GetDiff() * rigidbody2D.velocity.magnitude);
      float damage = ball.GetDiff() * rigidbody2D.velocity.magnitude;
      h.Hit(damage);
      
      // shrink this (ball)
      ball.Shrink();
    }
    if (col.gameObject.tag == "RatKing") {
      // call health script on the breakable
      KingHealth h = col.gameObject.GetComponent<KingHealth>();
      Debug.Log(ball.GetDiff() * rigidbody2D.velocity.magnitude);
      float damage = ball.GetDiff() * rigidbody2D.velocity.magnitude;
      h.Hit(damage);
      
      // shrink this (ball)
      ball.Shrink();
    }
  }
}