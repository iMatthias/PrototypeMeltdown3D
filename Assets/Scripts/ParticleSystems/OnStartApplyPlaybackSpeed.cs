using System.Linq;
using UnityEngine;

namespace MeltdownPrototype
{
	public class OnStartApplyPlaybackSpeed : MonoBehaviour
	{
		public ParticleSystem ParticleSystem;
		public float PlaybackSpeed = 5;

		private void Start()
		{
			// this.ParticleSystem.playbackSpeed = this.PlaybackSpeed;

			this.ParticleSystem.GetComponentsInChildren<ParticleSystem>().ToList().ForEach(x =>
			{
				ParticleSystem.MainModule mainModule = x.main;
				// x.playbackSpeed = this.PlaybackSpeed;
				// mainModule.simulationSpeed = mainModule.simulationSpeed * this.PlaybackSpeed;
				// mainModule.duration = mainModule.duration / this.PlaybackSpeed;
			});
		}
	}
}