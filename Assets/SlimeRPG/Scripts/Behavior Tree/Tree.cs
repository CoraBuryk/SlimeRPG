using UnityEngine;

namespace Assets.Scripts.Behavior_Tree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if(_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}