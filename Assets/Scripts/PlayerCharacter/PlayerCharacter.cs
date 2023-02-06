using System;
using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Assertions;

namespace MeltdownPrototype
{
	public class PlayerCharacter : MonoBehaviour
	{
		public event IntDelegate OnHpUpdated;
		public event EmptyDelegate OnDeathEvent;

		public int MaxHealth { get => this.maxHealth; }
		public int StartingHealth { get => this.startingHealth; }

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

		[Header("Debug")]

		[SerializeField, ReadOnly]
		private bool isInvincible;

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
			if (this.isInvincible)
				return;

			IncreaseHealth(-pole.Damage);

			StartCoroutine(StartInvincibleTimerCoroutine());
		}

		private IEnumerator StartInvincibleTimerCoroutine()
		{
			this.isInvincible = true;

			yield return new WaitForSeconds(1f);

			this.isInvincible = false;
		}

		private void IncreaseHealth(int delta)
		{
			int oldHealth = this.currentHealth;

			this.currentHealth = Math.Clamp(this.currentHealth + delta, 0, this.maxHealth);

			Debug.Log($"Player {this.gameObject.name} received '{delta}' Damage/Healing. HP: {oldHealth} -> {this.currentHealth}");

			if (this.currentHealth == 0)
			{
				HandleDeathEvent();
			}

			this.OnHpUpdated?.Invoke(this.currentHealth);
		}

		private void HandleDeathEvent()
		{
			StartCoroutine(HandleDeathEventCoroutine());
		}

		private IEnumerator HandleDeathEventCoroutine()
		{
			this.onDeathFeedbacks.PlayFeedbacks();

			// wait for death particle animation before opening mainMenu UI
			yield return new WaitForSeconds(3.2f);

			this.OnDeathEvent?.Invoke();
		}
	}
}