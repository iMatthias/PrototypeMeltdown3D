using System.Collections.Generic;
using UnityEngine;

namespace MeltdownPrototype
{
	[System.Serializable]
	public class GameStartData
	{
		public List<Animator> CharacterPrefabs;
		public List<ParticleSystemWithFloat> SpawnEffectPrefabs;
		public List<ParticleSystemWithFloat> DeathEffectPrefabs;
		public Transform PlayerStartPosition;
	}

	[System.Serializable]
	public class ParticleSystemWithFloat
	{
		public ParticleSystem Prefab;
		public float Float;
	}
}