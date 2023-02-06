using UnityEngine;
using UnityEngine.UI;

namespace MeltdownPrototype
{
	public class CharacterPreviewButton : MonoBehaviour
	{
		public event IntDelegate OnClickButtonEvent;
		public int Index { get => this.index; }

		[SerializeField]
		private Button button;

		[SerializeField]
		private int index;

		private void Awake()
		{
			this.button.onClick.AddListener(OnClickButton);
		}

		public void OnClickButton()
		{
			this.OnClickButtonEvent?.Invoke(this.index);
		}
	}
}