﻿using System.Collections.Generic;

namespace Assets.Scripts.Behavior_Tree
{
    internal class Sequence : Node
    {
        public Sequence() : base() { }

        public Sequence(List<Node> children): base(children){ }

        public override NodeState Evaluate()
        {
            bool anyChildrenIsRunning = false;

            foreach(Node node in children)
            {
                switch(node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildrenIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = anyChildrenIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }

}
