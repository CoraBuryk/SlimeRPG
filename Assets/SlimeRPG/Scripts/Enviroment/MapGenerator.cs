using System.Collections.Generic;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enviroment
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject[] _mapPrefabs;
        [SerializeField] private GameObject _parentObject;
        private List<GameObject> _activeMaps = new List<GameObject>();
        private float _spawnPosition = 10;
        private const float _mapLength = 10;
        private int _startMaps = 5;

        void Awake()
        {
            for (int i = 0; i < _startMaps; i++)
            {
                CreateMap(Random.Range(0, _mapPrefabs.Length));
            }
        }

        void Update()
        {
            if (_player.position.z - 90 < _spawnPosition - (_startMaps * _mapLength))
            {
                CreateMap(Random.Range(0, _mapPrefabs.Length));
                DeleteMap();
            }
        }

        private void CreateMap(int mapIndex)
        {
            GameObject nextRoad = Instantiate(_mapPrefabs[mapIndex], transform.forward * _spawnPosition, transform.rotation);
            nextRoad.transform.parent = _parentObject.transform;
            _activeMaps.Add(nextRoad);
            _spawnPosition -= _mapLength;
        }

        private void DeleteMap()
        {
            Destroy(_activeMaps[0]);
            _activeMaps.RemoveAt(0);
        }

    }
}
