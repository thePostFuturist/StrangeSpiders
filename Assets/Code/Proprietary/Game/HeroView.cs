using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class HeroView: View, IHeroView {

		[SerializeField] float move_speed = 5f;
		[SerializeField] float rotation_speed = 5f;
		[SerializeField] float gravity = 9.8f;

		[SerializeField] Transform spawn_point;

		CharacterController character_controller;

		protected override void Start()
		{
			character_controller = GetComponent<CharacterController> ();
		}

		void Update()
		{
			float rotation_amount = Input.GetAxis ("Horizontal") * rotation_speed * Time.deltaTime;
			transform.RotateAround (Vector3.up, rotation_amount);

			float move_amount = Input.GetAxis ("Vertical") * move_speed * -1;

			Vector3 total_movement = new Vector3 (move_amount * move_speed, 0, 0);
			total_movement = transform.TransformDirection (total_movement);
			total_movement.y -= gravity;

			character_controller.Move (total_movement * Time.deltaTime);
		}


		void ReSpawnHero()
		{
			transform.position = spawn_point != null ? spawn_point.position : Vector3.zero; 
		}

	}

	public interface IHeroView {
		
	}
	
}
