using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace MeltdownPrototype
{
	public class Pole : MonoBehaviour
	{
		public int Damage { get => this.damage; }

		[SerializeField]
		private Rigidbody rigidBody;

		[SerializeField]
		private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);

		[SerializeField]
		private Vector3 velocity = new Vector3(20, 0, 0);

		[SerializeField]
		private int damage;

		private void Awake()
		{
			Assert.AreNotEqual(expected: 0, actual: this.damage, message: $"Pole '{this.gameObject.name}': damage is set to {this.damage}. Specify the damage value from the inspector of this object.");
		}

		private void FixedUpdate()
		{
			Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
			Vector3 deltaPosition = this.velocity * Time.fixedDeltaTime;

			if (this.rigidBody)
			{
				this.rigidBody.MoveRotation(this.rigidBody.rotation * deltaRotation);
				this.rigidBody.MovePosition(this.transform.position + deltaPosition);
			}
			else
			{
				this.transform.Rotate(deltaRotation.eulerAngles);
				this.transform.position += deltaPosition;
			}
		}
	}
}