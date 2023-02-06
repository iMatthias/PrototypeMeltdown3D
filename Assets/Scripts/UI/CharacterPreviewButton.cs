using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class CharacterPreviewButton : MonoBehaviour
	{
		public event IntDelegate OnClickButtonEvent;
		public int Index { get => this.index; }
		public Sprite PreviewSprite { get => this.previewImage.sprite; }

		[SerializeField]
		private Button button;

		[SerializeField]
		private Image previewImage;

		[SerializeField]
		private int index;

		private void Awake()
		{
			Assert.IsNotNull(this.previewImage);

			this.button.onClick.AddListener(OnClickButton);
		}

		public void OnClickButton()
		{
			this.OnClickButtonEvent?.Invoke(this.index);
		}
	}
}