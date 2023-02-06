using System;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Assertions;

namespace MeltdownPrototype
{
	public class PlayerCharacter : MonoBehaviour
	{
		[SerializeField]
		private PoleCollisionDetector poleCollisionDetector;

		[SerializeField]
		private MMF_Player onReceiveDamageFeedbacks;

		[SerializeField]
		private MMF_Player onDeathFeedbacks;

		[SerializeField]
		private int startingHealth;

		[SerializeField]
		private int maxHealth;

		[SerializeField]
		private int currentHealth;

		private void Awake()
		{
			Assert.IsNotNull(this.poleCollisionDetector);
			Assert.IsNotNull(this.onReceiveDamageFeedbacks);
			Assert.IsNotNull(this.onDeathFeedbacks);

			this.poleCollisionDetector.OnCollisionEnterRotatingPole += OnCollisionEnterRotatingPole;

			this.currentHealth = this.startingHealth;
		}

		private void OnCollisionEnterRotatingPole(Pole pole)
		{
			IncreaseHealth(-pole.Damage);
		}

		private void IncreaseHealth(int delta)
		{
			this.currentHealth = Math.Clamp(this.currentHealth + delta, 0, this.maxHealth);

			if (this.currentHealth == 0)
			{
				// HandleDeath()
			}
		}
	}
}