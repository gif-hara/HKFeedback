using UnityEditor;
using UnityEditor.Experimental.GraphView;
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

            var background = new GridBackground();
            Insert(0, background);

            var path = "Assets/HKFeedback/Editor/Settings/HKFeedbackGraphView.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(path);
            Assert.IsNotNull(styleSheet, $"{path} not found");
            styleSheets.Add(styleSheet);
        }
    }
}
