using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enviroment
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Map[] _mapPrefabs;
        private Transform _transform;
        private List<Map> _activeMaps = new List<Map>();
        private float _spawnPosition = -15;
        private const float _mapLength = 10;
        private int _startMaps = 3;
        private float _speed = 4;
        private float _timeForWalk = 15;

        void Awake()
        {
            _transform = transform;
            for (int i = 0; i < _startMaps; i++)
            {
                CreateMap(UnityEngine.Random.Range(0, _mapPrefabs.Length), _spawnPosition-_mapLength*i);
            }
            StartCoroutine(Walking());
        }

        private void CreateMap(int mapIndex, float position)
        {
            Map nextMap = Instantiate(_mapPrefabs[mapIndex], new Vector3(0,-0.3f, position), Quaternion.identity);
            _activeMaps.Add(nextMap);
            _timeForWalk += 30;
        }

        private void DeleteMap()
        {
            _activeMaps[1].DestroyBarrier();
            Destroy(_activeMaps[0].gameObject);
            _activeMaps.RemoveAt(0);
        }

        public void DestroyAllMaps()
        {
            for (int i = 0; i < _activeMaps.Count; i++)
            {
                Destroy(_activeMaps[i].gameObject);
            }
        }

        public IEnumerator Walking()
        {
           float time = _timeForWalk;
           do
           {
                Move();
                CheckForSpawn();
                time -= Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
           }
           while (time > 0);
        }

        private void Move()
        {
            for(int i = 0; i < _activeMaps.Count; i++)
            {
                Vector3 vector = _transform.forward * _speed;
                _activeMaps[i].MoveMap(vector);
            }
        }

        private void CheckForSpawn()
        {
            if (IsPlayerReachBarrier())
            {
                CreateMap(UnityEngine.Random.Range(0, _mapPrefabs.Length),_spawnPosition);
                DeleteMap();
            }
        }

        private bool IsPlayerReachBarrier()
        {
            if (_playerTransform == null)
                return false;
            return Vector3.Distance(_playerTransform.position, _activeMaps[1].Barrier.position) < 5;
        }
    }
}
