using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace HKFeedback.Editor
{
    public class HKFeedbackGraphView : GraphView
    {
        public HKFeedbackGraphView()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.StretchToParentSize();

            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContextualMenuManipulator(BuildContextualMenu));

            var background = new GridBackground();
            Insert(0, background);
            background.StretchToParentSize();
            background.SendToBack();

            var path = "Assets/HKFeedback/Editor/Settings/HKFeedbackGraphView.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(path);
            Assert.IsNotNull(styleSheet, $"{path} not found");
            styleSheets.Add(styleSheet);
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            var position = viewTransform.matrix.inverse.MultiplyPoint(evt.localMousePosition);
            evt.menu.AppendAction("Create Node", action => CreateNode("Node", position));
            base.BuildContextualMenu(evt);
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>(ports.Count());
            foreach (var port in ports)
            {
                if (startPort.node == port.node || startPort.direction == port.direction || startPort.portType != port.portType)
                {
                    continue;
                }
                compatiblePorts.Add(port);
            }
            return compatiblePorts;
        }

        private Node CreateNode(string title, Vector2 position)
        {
            var node = new CustomNode(title);
            node.styleSheets.Add(EditorGUIUtility.Load("StyleSheets/GraphView/Node.uss") as StyleSheet);
            node.SetPosition(new Rect(position, new Vector2(150, 100)));
            AddElement(node);
            return node;
        }
    }
}
