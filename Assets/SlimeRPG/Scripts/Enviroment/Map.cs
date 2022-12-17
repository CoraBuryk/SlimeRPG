using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enviroment
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform _barrier;

        public Transform Barrier { get { return _barrier; } }

        public void MoveMap(Vector3 movementVector)
        {
            transform.Translate(movementVector * Time.deltaTime);
        }           

        public void DestroyBarrier()
        {
            Destroy(_barrier.gameObject);
        }        
    }
}
