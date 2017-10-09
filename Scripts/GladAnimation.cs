using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladAnimation : MonoBehaviour
{

	public enum Direction
	{
		Left,
		Right
	};

	public enum Weapon
	{ 
		NoWeapon,
		Spear,
		Gladius,
		Mace,
	};

	public enum Action
	{
		Idle,
		Walk,
		Attack,
		Shield,
		Duck,
		Jump,
		Throw
	};
		
	public Direction currentDirection;
	public Weapon currentWeapon;
	public Action currentAction;

	Animator animator;
	GladWeaponDetection weaponDetection;

	// Use this for initialization
	void Start ()
	{
		animator = gameObject.GetComponent<Animator> ();
		weaponDetection = gameObject.GetComponent<GladWeaponDetection> ();

		Direction currentDirection = Direction.Right;
		Weapon currentWeapon = Weapon.Spear;
		Action currentAction = Action.Idle;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentDirection) {
			
		case Direction.Right:

			switch (currentWeapon) {

			case Weapon.Mace:

				switch (currentAction) {

				case Action.Idle:

					if (Input.GetAxisRaw("Horizontal") == 1) { //Input.GetKey ("right")
						animator.SetBool ("isWalkingRightMace", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Walk;
					}

					else if (Input.GetButton("Attack")) {
						animator.SetBool ("isMacingRight", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Attack;
					}
					else if (Input.GetButton("Shield")) {
						animator.SetBool ("isShieldingRightMace", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Shield;
					}
					else if (Input.GetAxisRaw("Vertical") == -1) {
						animator.SetBool ("isDuckingRightMace", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Duck;
					}
					else if (Input.GetAxisRaw("Vertical") == 1) {
						animator.SetBool ("isJumpingRightMace", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Jump;
					}
					else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightMace", true);
						animator.SetBool ("isIdleRightMace", false);

						currentAction = Action.Throw;
					}

					break;


				case Action.Walk:

					if (Input.GetAxisRaw("Horizontal") != 1) {
						animator.SetBool ("isIdleRightMace", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Idle;
					}

					else if (Input.GetButton("Attack")) {
						animator.SetBool ("isMacingRight", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Attack;
					}
					else if (Input.GetButton("Shield")) {
						animator.SetBool ("isShieldingRightMace", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Shield;
					}
					else if (Input.GetAxisRaw("Vertical") == -1) {
						animator.SetBool ("isDuckingRightMace", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Duck;
					}
					else if (Input.GetAxisRaw("Vertical") == 1) {
						animator.SetBool ("isJumpingRightMace", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Jump;
					}
					else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightMace", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Throw;
					}


					break;

				case Action.Attack:

					if (Input.GetAxisRaw("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightMace", true);
						animator.SetBool ("isMacingRight", false);

						currentAction = Action.Walk;
					} 
					else {
						animator.SetBool ("isIdleRightMace", true);
						animator.SetBool ("isMacingRight", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Shield:

					if (!Input.GetButton("Shield")) {
						
						if (Input.GetAxisRaw("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightMace", true);
							animator.SetBool ("isShieldingRightMace", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightMace", true);
							animator.SetBool ("isShieldingRightMace", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Duck:

					if (Input.GetAxisRaw("Vertical") != -1) {

						if (Input.GetAxisRaw("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightMace", true);
							animator.SetBool ("isDuckingRightMace", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightMace", true);
							animator.SetBool ("isDuckingRightMace", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Jump:

					if (Input.GetAxisRaw("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightMace", true);
						animator.SetBool ("isJumpingRightMace", false);

						currentAction = Action.Walk;
					} 
					else {
						animator.SetBool ("isIdleRightMace", true);
						animator.SetBool ("isJumpingRightMace", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Throw:

					if (Input.GetAxisRaw ("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightNoW", true);
						animator.SetBool ("isThrowingRightMace", false);

						currentAction = Action.Walk;
					} else {
						animator.SetBool ("isIdleRightNoW", true);
						animator.SetBool ("isThrowingRightMace", false);

						currentAction = Action.Idle;
					}
					currentWeapon = Weapon.NoWeapon;

					break; //end of Mace switch
				}

				break; // end of Mace case statement

			case Weapon.NoWeapon:

				switch (currentAction) {

				case Action.Idle:

					if (Input.GetAxisRaw ("Horizontal") == 1) { //Input.GetKey ("right")
						animator.SetBool ("isWalkingRightNoW", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Walk;
					} else if (Input.GetButton ("Attack")) {
						animator.SetBool ("isPunchingRight", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Attack;
					} else if (Input.GetButton ("Shield")) {
						animator.SetBool ("isShieldingRightNoW", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Shield;
					} else if (Input.GetAxisRaw ("Vertical") == -1) {
						animator.SetBool ("isDuckingRightNoW", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Duck;
					} else if (Input.GetAxisRaw ("Vertical") == 1) {
						animator.SetBool ("isJumpingRightNoW", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Jump;
					}else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightNoW", true);
						animator.SetBool ("isIdleRightNoW", false);

						currentAction = Action.Throw;
					}

					break;

				case Action.Walk:

					if (Input.GetAxisRaw ("Horizontal") != 1) {
						animator.SetBool ("isIdleRightNoW", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Idle;
					} else if (Input.GetButton ("Attack")) {
						animator.SetBool ("isPunchingRight", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Attack;
					} else if (Input.GetButton ("Shield")) {
						animator.SetBool ("isShieldingRightNoW", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Shield;
					} else if (Input.GetAxisRaw ("Vertical") == -1) {
						animator.SetBool ("isDuckingRightNoW", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Duck;
					} else if (Input.GetAxisRaw ("Vertical") == 1) {
						animator.SetBool ("isJumpingRightNoW", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Jump;
					} else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightNoW", true);
						animator.SetBool ("isWalkingRightNoW", false);

						currentAction = Action.Throw;
					}


					break;

				case Action.Attack:

					if (Input.GetAxisRaw ("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightNoW", true);
						animator.SetBool ("isPunchingRight", false);

						currentAction = Action.Walk;
					} else {
						animator.SetBool ("isIdleRightNoW", true);
						animator.SetBool ("isPunchingRight", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Shield:

					if (!Input.GetButton ("Shield")) {

						if (Input.GetAxisRaw ("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightNoW", true);
							animator.SetBool ("isShieldingRightNoW", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightNoW", true);
							animator.SetBool ("isShieldingRightNoW", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Duck:

					if (Input.GetAxisRaw ("Vertical") != -1) {

						if (Input.GetAxisRaw ("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightNoW", true);
							animator.SetBool ("isDuckingRightNoW", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightNoW", true);
							animator.SetBool ("isDuckingRightNoW", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Jump:

					if (Input.GetAxisRaw ("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightNoW", true);
						animator.SetBool ("isJumpingRightNoW", false);

						currentAction = Action.Walk;
					} else {
						animator.SetBool ("isIdleRightNoW", true);
						animator.SetBool ("isJumpingRightNoW", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Throw: //or pick up

					if (weaponDetection.macesWithinReach > 0) { //spear within reach

						if (Input.GetAxisRaw ("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightMace", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightMace", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Idle;
						}

						currentWeapon = Weapon.Mace;
					} 

					else if (weaponDetection.spearsWithinReach > 0) { //spear within reach

						if (Input.GetAxisRaw ("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightSpear", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightSpear", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Idle;
						}

						currentWeapon = Weapon.Spear;
					} 
					else { //no weapons nearby

						if (Input.GetAxisRaw ("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightNoW", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightNoW", true);
							animator.SetBool ("isThrowingRightNoW", false);

							currentAction = Action.Idle;
						}
					}




					break;

				}

				break; // end of noWeapon case

			case Weapon.Spear:

				switch (currentAction) {

				case Action.Idle:

					if (Input.GetAxisRaw("Horizontal") == 1) { //Input.GetKey ("right")
						animator.SetBool ("isWalkingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Walk;
					}

					else if (Input.GetButton("Attack")) {
						animator.SetBool ("isStabbingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Attack;
					}
					else if (Input.GetButton("Shield")) {
						animator.SetBool ("isShieldingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Shield;
					}
					else if (Input.GetAxisRaw("Vertical") == -1) {
						animator.SetBool ("isDuckingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Duck;
					}
					else if (Input.GetAxisRaw("Vertical") == 1) {
						animator.SetBool ("isJumpingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Jump;
					}
					else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightSpear", true);
						animator.SetBool ("isIdleRightSpear", false);

						currentAction = Action.Throw;
					}

					break;


				case Action.Walk:

					if (Input.GetAxisRaw("Horizontal") != 1) {
						animator.SetBool ("isIdleRightSpear", true);
						animator.SetBool ("isWalkingRightSpear", false);

						currentAction = Action.Idle;
					}

					else if (Input.GetButton("Attack")) {
						animator.SetBool ("isStabbingRightSpear", true);
						animator.SetBool ("isWalkingRightSpear", false);

						currentAction = Action.Attack;
					}
					else if (Input.GetButton("Shield")) {
						animator.SetBool ("isShieldingRightSpear", true);
						animator.SetBool ("isWalkingRightSpear", false);

						currentAction = Action.Shield;
					}
					else if (Input.GetAxisRaw("Vertical") == -1) {
						animator.SetBool ("isDuckingRightSpear", true);
						animator.SetBool ("isWalkingRightSpear", false);

						currentAction = Action.Duck;
					}
					else if (Input.GetAxisRaw("Vertical") == 1) {
						animator.SetBool ("isJumpingRightSpear", true);
						animator.SetBool ("isWalkingRightMace", false);

						currentAction = Action.Jump;
					}
					else if (Input.GetButtonDown("Throw")) {
						animator.SetBool ("isThrowingRightSpear", true);
						animator.SetBool ("isWalkingRightSpear", false);

						currentAction = Action.Throw;
					}


					break;

				case Action.Attack:

					if (Input.GetAxisRaw("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightSpear", true);
						animator.SetBool ("isStabbingRightSpear", false);

						currentAction = Action.Walk;
					} 
					else {
						animator.SetBool ("isIdleRightSpear", true);
						animator.SetBool ("isStabbingRightSpear", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Shield:

					if (!Input.GetButton("Shield")) {

						if (Input.GetAxisRaw("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightSpear", true);
							animator.SetBool ("isShieldingRightSpear", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightSpear", true);
							animator.SetBool ("isShieldingRightSpear", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Duck:

					if (Input.GetAxisRaw("Vertical") != -1) {

						if (Input.GetAxisRaw("Horizontal") == 1) {
							animator.SetBool ("isWalkingRightSpear", true);
							animator.SetBool ("isDuckingRightSpear", false);

							currentAction = Action.Walk;
						} else {
							animator.SetBool ("isIdleRightSpear", true);
							animator.SetBool ("isDuckingRightSpear", false);

							currentAction = Action.Idle;
						}
					}

					break;

				case Action.Jump:

					if (Input.GetAxisRaw("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightSpear", true);
						animator.SetBool ("isJumpingRightSpear", false);

						currentAction = Action.Walk;
					} 
					else {
						animator.SetBool ("isIdleRightSpear", true);
						animator.SetBool ("isJumpingRightSpear", false);

						currentAction = Action.Idle;
					}

					break;

				case Action.Throw: 

					if (Input.GetAxisRaw ("Horizontal") == 1) {
						animator.SetBool ("isWalkingRightNoW", true);
						animator.SetBool ("isThrowingRightSpear", false);

						currentAction = Action.Walk;
					} else {
						animator.SetBool ("isIdleRightNoW", true);
						animator.SetBool ("isThrowingRightSpear", false);

						currentAction = Action.Idle;
					}
					currentWeapon = Weapon.NoWeapon;

					break; //end of Mace switch
				}

				break; // end of Mace case statement
					
			}

			break;

		}
		/**
		if (Input.GetKeyDown("right")) {
			animator.SetTrigger ("isWalkingRightMace");
		}
		if (Input.GetKeyUp("right")) {
			animator.SetTrigger ("isIdleRightMace");
		}
		else if (Input.GetKeyDown("space")) {
			animator.SetTrigger ("isMacingRight");
		}
		else if (Input.GetKeyDown("left shift")) {
			animator.SetTrigger ("isShieldingRightMace");
		}
		else if (Input.GetKeyUp("left shift")) {
			animator.SetTrigger ("isIdleRightMace");
		}
		**/
	}
}
