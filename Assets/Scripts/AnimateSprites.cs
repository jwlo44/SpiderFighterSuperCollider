using UnityEngine;
using System.Collections;

public class AnimateSprites : MonoBehaviour {

  public Sprite[] sprites;
  public int COUNTDOWN;
  private int countDown;
  private int spriteIndex = 0;
  private bool facingRight = false;

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

    // If the input is moving the player right and the player is facing left...
    if (this.rigidbody2D.velocity.x > 0 && !facingRight) {
      // ... flip the player.
      Flip ();
    }
    // Otherwise if the input is moving the player left and the player is facing right...
    else if (this.rigidbody2D.velocity.x < 0 && facingRight) {
      // ... flip the player.
      Flip ();
    }
	}

  void Flip ()
  {
    // Switch the way the player is labelled as facing.
    facingRight = !facingRight;
    
    // Multiply the player's x local scale by -1.
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
}
