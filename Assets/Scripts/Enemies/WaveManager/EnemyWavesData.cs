using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace VM.TopDown.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Waves", menuName = "GameData/Enemy/Waves")]
    public class EnemyWavesData : ScriptableObject
    {
        public bool isInfinite;
        [ConditionalField(nameof(isInfinite))] public SingleWaveData wave;
        [ConditionalField(nameof(isInfinite), true)] public int maxWaves;
        [ConditionalField(nameof(isInfinite), true)] public WaveList waves;
    }

    [System.Serializable]
    public struct WaveList
    {
        public List<SingleWaveData> waves;
    }

    [System.Serializable]
    public struct SingleWaveData
    {
        public string waveName;
        public int maxEnemiesSpawnned;
        public EnemyType[] enemies;
    }

    [System.Serializable]
    public struct InfiniteWaveData
    {
        public string waveName;
        public int firstWaveEnemiesCount;
        public int enemyCountIncrementPerWave;
    }
}
