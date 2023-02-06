using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class GameStartSystem : MonoBehaviour
	{
		[SerializeField]
		private GameStartData data;

		[SerializeField]
		private MainMenuViewController mainMenuViewController;

		[SerializeField]
		private CharacterSelectionViewController characterSelectionViewController;

		[SerializeField]
		private HPViewController hpViewController;

		[Header("Runtime Instances")]

		[SerializeField, ReadOnly]
		private Animator spawnedPlayerCharacter;

		[SerializeField, ReadOnly]
		private ParticleSystem spawnEffect;
		private readonly int selectedSpawnEffectIndex = 0; // currently no option to select from the menu

		private void Awake()
		{
			Assert.IsNotNull(this.characterSelectionViewController);
		}

		public void StartGame()
		{
			this.mainMenuViewController.ClosePanel();
			CleanUpGame();
			StartCoroutine(StartSpawnCoroutine());
		}

		private IEnumerator StartSpawnCoroutine()
		{
			int selectedCharacterIndex = this.characterSelectionViewController.SelectedCharacterIndex;

			Debug.Log($"GameStartSystem.StartSpawnCoroutine(): Starting with Character Index {selectedCharacterIndex}");
			this.spawnEffect = Instantiate(this.data.SpawnEffectPrefabs[this.selectedSpawnEffectIndex].Prefab, this.data.PlayerStartPosition);
			this.spawnEffect.transform.position = this.spawnEffect.transform.position.CopyWithY(0);

			yield return new WaitForSeconds(this.data.SpawnEffectPrefabs[this.selectedSpawnEffectIndex].Float);

			this.spawnedPlayerCharacter = Instantiate(this.data.CharacterPrefabs[selectedCharacterIndex], this.data.PlayerStartPosition);

			this.hpViewController.ConnectCharacter(this.spawnedPlayerCharacter);
			this.mainMenuViewController.ConnectCharacter(this.spawnedPlayerCharacter);

			yield return new WaitForSeconds(5);
			Destroy(this.spawnEffect.gameObject);
		}

		public void CleanUpGame()
		{
			if (this.spawnedPlayerCharacter)
			{
				Destroy(this.spawnedPlayerCharacter.gameObject);
			}
			if (this.spawnEffect)
			{
				Destroy(this.spawnEffect.gameObject);
			}
		}
	}
}