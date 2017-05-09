using UnityEngine;
using System.Collections;

public class animateRatking : MonoBehaviour {
  
  public Sprite[] sprites;
  public int COUNTDOWN;
  private int countDown;
  private int spriteIndex = 0;

  
  // Use this for initialization
  void Start () {
    countDown = COUNTDOWN;
    this.GetComponent<SpriteRenderer> ().sprite = sprites [spriteIndex];
  }
  
  // Update is called once per frame
  void Update () {
    
    if (countDown < 0) {
      this.GetComponent<SpriteRenderer> ().sprite = sprites [(++spriteIndex % sprites.Length)];
      countDown = COUNTDOWN;
    } else {
      countDown--;
    }

  }

}
