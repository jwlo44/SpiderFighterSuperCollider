using UnityEngine;
using System.Collections;

public class ratkingMove : MonoBehaviour {
  private int cooldown;

  
  // Use this for initialization
  void Start () {
    
  }
  
  // Update is called once per frame
  void Update () {
      if (cooldown > 0) {
        cooldown--;
        this.transform.position = Vector2.MoveTowards (this.transform.position, GameObject.Find ("Spider").transform.position, -0.05f);
      } else {
        this.transform.position = 
          Vector2.MoveTowards (this.transform.position, GameObject.Find ("Spider").transform.position, 0.1f);
      }
  }
  void OnCollisionEnter2D (Collision2D col) {
    if (col.gameObject.tag == "Player") {
      cooldown = 20;
    }
  }

}
