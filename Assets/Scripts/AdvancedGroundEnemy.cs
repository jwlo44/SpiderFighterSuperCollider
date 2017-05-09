using UnityEngine;
using System.Collections;

public class AdvancedGroundEnemy : MonoBehaviour {

  private static float STRENGTH = 5;

  // Use this for initialization
  void Start () {
  }
  
  // Update is called once per frame
  void Update () {
    GameObject player = GameObject.FindGameObjectWithTag ("Player");
    Vector2 heading = player.transform.position - this.transform.position;
    Vector2 direction = heading.normalized;
    this.rigidbody2D.AddForce (direction * STRENGTH);
  }
}
