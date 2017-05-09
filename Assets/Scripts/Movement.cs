using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
  public AudioClip JUMP_SOUND;
  // Constants
  private static float SCALE = 20;
  private static float JUMP_FORCE = 750;
  private static float MAX_SPEED = 10;
  private Transform groundCheck;
  private bool facingRight = true;
  private bool grounded = false;

  // Use this for initialization
  void Start ()
  {
    groundCheck = this.transform.Find ("GroundCheck");
  }
  
  // Update is called once per frame
  void Update ()
  {
    grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
    float h = Input.GetAxisRaw ("Horizontal");
    // If the input is moving the player right and the player is facing left...
    if (h > 0 && !facingRight)
      // ... flip the player.
      Flip ();
    // Otherwise if the input is moving the player left and the player is facing right...
    else if (h < 0 && facingRight)
      // ... flip the player.
      Flip ();
    MoveX ();
    MoveY ();
  }

  void MoveX ()
  {
    if (Mathf.Abs (rigidbody2D.velocity.x) < MAX_SPEED) {
      float speedX = Input.GetAxisRaw ("Horizontal") * SCALE;
      this.rigidbody2D.AddForce (new Vector2 (speedX, 0));
      if (Input.GetButtonDown("Horizontal")) {
        audio.Play();
      } else if (Input.GetButtonUp("Horizontal")) {
        audio.Stop();
      }
    }
  }

  void MoveY ()
  {
    bool jump = Input.GetButtonDown ("Jump");
    if (grounded && jump) {
      AudioSource.PlayClipAtPoint(JUMP_SOUND, this.transform.position);
      this.rigidbody2D.AddForce (new Vector2 (0, JUMP_FORCE));
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
