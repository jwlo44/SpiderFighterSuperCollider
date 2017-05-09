using UnityEngine;
using System.Collections;

// collision handler to attach to the spider
// totally copied from BallCollide
public class SpiderCollide : MonoBehaviour {

  private static float FORCE = -500;

  void OnCollisionEnter2D (Collision2D col)
  {   
    if (col.gameObject.tag == "Enemy") {
      // call health script on the spider
      PlayerHealth h = gameObject.GetComponent<PlayerHealth>();
      h.Hit(1); // TODO: replace 1 with damage factor for spider
      Vector3 heading = col.transform.position - this.transform.position;
      float distance = heading.magnitude;
      Vector3 direction = heading / distance;
      this.rigidbody2D.AddForce(new Vector2(direction.x, direction.y) * FORCE);
    }
  }
}