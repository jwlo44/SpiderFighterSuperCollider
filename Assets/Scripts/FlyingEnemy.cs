using UnityEngine;
using System.Collections;

public class FlyingEnemy : MonoBehaviour {
  private int cooldown;
  private static float MIN_DIST = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (isSeeking()) {
      if (cooldown > 0) {
        cooldown--;
        this.transform.position = Vector2.MoveTowards (this.transform.position, GameObject.Find ("Spider").transform.position, -0.05f);
      } else {
        this.transform.position = 
      Vector2.MoveTowards (this.transform.position, GameObject.Find ("Spider").transform.position, 0.1f);
      }
    }
  }
    void OnCollisionEnter2D (Collision2D col) {
    if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Breakable" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player") {
      cooldown = 20;
    }
  }

  bool isSeeking ()
  {
    return (Vector2.Distance (GameObject.Find ("Spider").transform.position, this.transform.position) < MIN_DIST);
  }
}
