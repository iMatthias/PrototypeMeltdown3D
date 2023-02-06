using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace MeltdownPrototype
{
	public static class Constants
	{
		public const string LayerNamePlayerCharacter = "Player/Character";
		public const string LayerNameRotatingPole = "World/RotatingPole";
		public const string LayerNameWall = "World/Wall";
	}

	public delegate void EmptyDelegate();
	public delegate void PoleDelegate(Pole pole);

	public class PoleCollisionDetector : MonoBehaviour
	{
		public event PoleDelegate OnCollisionEnterRotatingPole;

		[SerializeField, Layer]
		private int wallLayer;

		[SerializeField, Layer]
		private int poleLayer;

		[SerializeField, Layer]
		private List<int> layers;

		private HashSet<int> layersSet = new HashSet<int>();

		private void Awake()
		{
			this.wallLayer = LayerMask.NameToLayer(Constants.LayerNameWall);
			this.poleLayer = LayerMask.NameToLayer(Constants.LayerNameRotatingPole);

		}

		private void OnCollisionEnter(Collision other)
		{
			int anotherLayer = other.gameObject.layer;
			if (this.layersSet.Contains(anotherLayer) == false)
			{
				this.layers.Add(anotherLayer);
				this.layersSet.Add(anotherLayer);
			}

			if (anotherLayer == this.poleLayer)
			{
				Pole pole = other.gameObject.GetComponent<Pole>();

				Assert.IsNotNull(pole);

				this.OnCollisionEnterRotatingPole?.Invoke(pole);
			}
		}

		private void OnCollisionExit(Collision other)
		{
			int anotherLayer = other.gameObject.layer;
			if (this.layersSet.Contains(anotherLayer))
			{
				this.layers.Remove(anotherLayer);
				this.layersSet.Remove(anotherLayer);
			}
		}
	}
}