using System;
using UnityEngine;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class MainMenuViewController : MonoBehaviour
	{
		[SerializeField]
		private GameStartSystem gameStartSystem;

		[SerializeField]
		private CanvasGroup menuCanvasGroup;

		[SerializeField]
		private CharacterSelectionViewController characterSelectionViewController;

		[SerializeField]
		private HPViewController hpViewController;

		[SerializeField]
		private Button startGameButton;

		[SerializeField]
		private Button openCharacterSelectionMenuButton;

		[SerializeField]
		private GameObject firstMenuPanel;

		[SerializeField]
		private KeyCode mainMenuKey = KeyCode.Escape;

		[Header("Debug")]

		[SerializeField]
		private bool startGameOnAwakeImmediately;

		private void Awake()
		{
			this.startGameButton.onClick.AddListener(this.gameStartSystem.StartGame);
			this.openCharacterSelectionMenuButton.onClick.AddListener(OpenCharacterSelectionMenuButton);
		}

		private void Start()
		{
			OpenFirstMainMenu();

			if (this.startGameOnAwakeImmediately)
			{
				this.startGameButton.onClick.Invoke();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(this.mainMenuKey))
			{
				OpenFirstMainMenu();
			}
		}

		public void OpenFirstMainMenu()
		{
			this.menuCanvasGroup.gameObject.SetActive(true);
			this.firstMenuPanel.SetActive(true);
			this.characterSelectionViewController.gameObject.SetActive(false);

			this.hpViewController.gameObject.SetActive(false);
		}

		private void OpenCharacterSelectionMenuButton()
		{
			this.firstMenuPanel.SetActive(false);
			this.characterSelectionViewController.gameObject.SetActive(true);
		}

		public void ClosePanel()
		{
			this.menuCanvasGroup.gameObject.SetActive(false);
			this.hpViewController.gameObject.SetActive(true);
		}

		public void ConnectCharacter(Animator spawnedPlayerCharacter)
		{
			PlayerCharacter playerCharacter = spawnedPlayerCharacter.GetComponent<PlayerCharacter>();
			playerCharacter.OnDeathEvent += OpenFirstMainMenu;
		}
	}
}