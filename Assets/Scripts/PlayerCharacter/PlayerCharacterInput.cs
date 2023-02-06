using MoreMountains.Feedbacks;
using UnityEngine;

namespace MeltdownPrototype
{
	public class PlayerCharacterInput : MonoBehaviour
	{
		public KeyCode Forward = KeyCode.W;
		public KeyCode Right = KeyCode.D;
		public KeyCode Left = KeyCode.A;
		public KeyCode Back = KeyCode.S;
		public KeyCode Jump = KeyCode.Space;

		[SerializeField]
		private MMF_Player jumpFeedbacks;

		[SerializeField]
		private Rigidbody playerCharacter;

		[SerializeField]
		private Vector3 speed;

		[SerializeField]
		private ForceMode jumpForceMode = ForceMode.VelocityChange;

		// private void Update()
		// {

		// }

		private void FixedUpdate()
		{
			// this.playerCharacter.velocity *= 0.6f;

			float forwardMultiplier = 0;
			float rightMultiplier = 0;

			if (Input.GetKey(this.Forward))
			{
				forwardMultiplier += 1;
			}

			if (Input.GetKey(this.Back))
			{
				forwardMultiplier -= 1f;
			}

			if (Input.GetKey(this.Left))
			{
				rightMultiplier -= 1;
			}

			if (Input.GetKey(this.Right))
			{
				rightMultiplier += 1;
			}

			Vector3 appliedSpeed = this.speed * Time.deltaTime;
			appliedSpeed.Scale(new Vector3(rightMultiplier, 0, forwardMultiplier));
			this.playerCharacter.MovePosition(this.playerCharacter.transform.position + appliedSpeed);
			this.playerCharacter.velocity = Vector3.zero;
			this.playerCharacter.angularVelocity = Vector3.zero;

			if (Input.GetKey(this.Jump))
			{
				this.jumpFeedbacks.PlayFeedbacks();
			}
		}
	}
}