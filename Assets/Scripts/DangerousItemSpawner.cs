using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class DangerousItemSpawner : MonoBehaviour
    {
        [Header("Dangerous items number")]
        [Tooltip("Минимальное количество опасных предметов на сцене")]
        [Min(1)]
        [SerializeField] 
        private int _minimumDangerousItem;
        [Tooltip("Максимальное количество опасных предметов на сцене")]
        [Min(1)]
        [SerializeField] 
        private int _maximumDangerousItem;
        [Header("Spawn Points")]
        [Tooltip("Точки спавна предметов")]
        [SerializeField] 
        private DangerousItemSpawnPoint[] _dangerousItemSpawnPoints;
        [Tooltip("Опасные предметы способные заспавниться")]
        [SerializeField] private DangerousItemInfo[] _spawnableDangerousItems;


        public event Action NotifyDangerousItemsWasSpawned;


        public int LastGeneratedDangerousItemsCount { get; private set; }


        #region MonoBehavior
        private void Start()
        {
            SetSpawnerSettingsWithDifficult();
            SpawnDangerousItems();
        }
        #endregion


        private void SpawnDangerousItems()
        {
            LastGeneratedDangerousItemsCount = GetNumberDangerousItemForSpawn();

            if(LastGeneratedDangerousItemsCount > _dangerousItemSpawnPoints.Length)
                LastGeneratedDangerousItemsCount = _dangerousItemSpawnPoints.Length;

            Queue<DangerousItemSpawnPoint> spawnPointsQueue = GenerateSpawnPointQueue();
            Queue<DangerousItemInfo> dangerousItemsQueue = GenerateDangerousItemQueue();
            for(int i = 0; i < LastGeneratedDangerousItemsCount; i++)
            {
                DangerousItemSpawnPoint dangerousItemSpawn = spawnPointsQueue.Dequeue();
                DangerousItemInfo dangerousItemInfo = dangerousItemsQueue.Dequeue();
                SpawnRandomItem(dangerousItemSpawn, dangerousItemInfo);
            }
            NotifyDangerousItemsWasSpawned?.Invoke();
        }

        private void SetSpawnerSettingsWithDifficult()
        {
            if(GameSettingSaver.CurrentGameDifficult is null)
                return;
            _minimumDangerousItem = GameSettingSaver.CurrentGameDifficult.fromDangerousObjectsCount;
            _maximumDangerousItem = GameSettingSaver.CurrentGameDifficult.toDangerousObjectsCount;
        }

        private int GetNumberDangerousItemForSpawn()
        {
            if(_minimumDangerousItem >= _maximumDangerousItem)
                _minimumDangerousItem = _maximumDangerousItem;
            return UnityEngine.Random.Range(_minimumDangerousItem, _maximumDangerousItem + 1);
        }

        private Queue<DangerousItemSpawnPoint> GenerateSpawnPointQueue()
        {
            LinkedList<DangerousItemSpawnPoint> spawnPoints = new LinkedList<DangerousItemSpawnPoint>(_dangerousItemSpawnPoints);
            Queue<DangerousItemSpawnPoint> generatedSpawnPoints = new Queue<DangerousItemSpawnPoint>();
            DangerousItemSpawnPoint dangerousItemSpawnPoint;
            for(int i = 0; i < LastGeneratedDangerousItemsCount; i++)
            {
                dangerousItemSpawnPoint = spawnPoints.ElementAt(UnityEngine.Random.Range(0, spawnPoints.Count));
                generatedSpawnPoints.Enqueue(dangerousItemSpawnPoint);
                spawnPoints.Remove(dangerousItemSpawnPoint);
            }
            return generatedSpawnPoints;
        }

        private Queue<DangerousItemInfo> GenerateDangerousItemQueue()
        {
            LinkedList<DangerousItemInfo> spawnableDangerousItems = new LinkedList<DangerousItemInfo>(_spawnableDangerousItems);
            Queue<DangerousItemInfo> generatedDangerousItems = new Queue<DangerousItemInfo>();
            DangerousItemInfo dangerousItems;
            for(int i = 0; i < LastGeneratedDangerousItemsCount; i++)
            {
                dangerousItems = spawnableDangerousItems.ElementAt(UnityEngine.Random.Range(0, spawnableDangerousItems.Count));
                generatedDangerousItems.Enqueue(dangerousItems);
                spawnableDangerousItems.Remove(dangerousItems);
            }
            return generatedDangerousItems;
        }
    
        public void SpawnRandomItem(DangerousItemSpawnPoint spawnPoint, DangerousItemInfo dangerousItem)
        {
            if(spawnPoint is null || dangerousItem is null)
                return;
            Instantiate( dangerousItem.ItemPrefab,
                spawnPoint.transform.position,
                spawnPoint.transform.rotation,
                spawnPoint.transform);
        }
    }
}