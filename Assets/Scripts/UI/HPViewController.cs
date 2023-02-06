using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class HPViewController : MonoBehaviour
	{
		[SerializeField]
		public Image characterPreview;

		[SerializeField]
		private Image[] innerHealthImages;

		private void Awake()
		{
			Assert.IsNotNull(this.characterPreview);
			Assert.AreNotEqual(0, this.innerHealthImages.Length);
		}

		public void SetCharacterPreviewImage(Sprite sprite)
		{
			Debug.Log($"HPViewController.SetCharacterPreviewImage(): Setting image to {sprite.name}");
			this.characterPreview.sprite = sprite;
		}

		private void OnUpdateHealth(int newHealth)
		{
			for (int i = 0; i < this.innerHealthImages.Length; i++)
			{
				bool hasHealth = i < newHealth;

				innerHealthImages[i].fillAmount = hasHealth ? 1 : 0;
			}
		}

		public void ConnectCharacter(Animator spawnedPlayerCharacter)
		{
			PlayerCharacter playerCharacter = spawnedPlayerCharacter.GetComponent<PlayerCharacter>();

			playerCharacter.OnHpUpdated += OnUpdateHealth;

			InitializeHealthView(playerCharacter);
		}

		private void InitializeHealthView(PlayerCharacter playerCharacter)
		{
			OnUpdateHealth(playerCharacter.StartingHealth);

			for (int i = 0; i < this.innerHealthImages.Length; i++)
			{
				GameObject iconView = this.innerHealthImages[i].transform.parent.gameObject;
				bool toActivate = i < playerCharacter.MaxHealth;

				iconView.SetActive(toActivate);
			}
		}
	}
}