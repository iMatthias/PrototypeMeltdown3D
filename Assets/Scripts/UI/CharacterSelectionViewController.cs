using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class CharacterSelectionViewController : MonoBehaviour
	{
		public int SelectedCharacterIndex { get => this.selectedCharacterIndex; }

		[SerializeField]
		private MainMenuViewController mainMenuViewController;

		[SerializeField]
		private Color selectedColor;

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Button confirmButton;

		[SerializeField]
		private CharacterPreviewButton[] previewButtons;

		[Header("Runtime Value")]

		[SerializeField]
		private int selectedCharacterIndex;

		private void Awake()
		{
			Assert.AreNotEqual(0, this.previewButtons.Length);
			Assert.AreNotEqual(this.previewButtons[0].Index, this.previewButtons[1].Index);

			foreach (CharacterPreviewButton button in this.previewButtons)
			{
				button.OnClickButtonEvent += OnClickCharacterPreviewButton;
			}

			this.previewButtons[0].OnClickButton();

			this.confirmButton.onClick.AddListener(OnClickConfirmButton);
		}

		private void OnClickCharacterPreviewButton(int index)
		{
			foreach (CharacterPreviewButton button in this.previewButtons)
			{
				Color newColor = button.Index == index ? this.selectedColor : this.defaultColor;
				button.GetComponent<Image>().color = newColor;
			}

			this.selectedCharacterIndex = index;
		}

		private void OnClickConfirmButton()
		{
			this.mainMenuViewController.OpenFirstMainMenu();
		}
	}

	public delegate void IntDelegate(int value);
}