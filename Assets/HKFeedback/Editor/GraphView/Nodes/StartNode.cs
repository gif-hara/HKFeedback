using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace HKFeedback.Editor.GraphViewSystems.Nodes
{
    public class StartNode : Node
    {
        public const string Guid = "StartNode";

        public StartNode()
        {
            title = "Start";
            viewDataKey = Guid;
            capabilities &= ~Capabilities.Movable;
            capabilities &= ~Capabilities.Deletable;
            var outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(string));
            outputPort.portName = "Next";
            outputContainer.Add(outputPort);

            RefreshExpandedState();
            RefreshPorts();
            SetPosition(new Rect(100, 100, 150, 100));
        }
    }
}
