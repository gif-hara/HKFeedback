using UnityEditor;
using UnityEngine;

namespace HKFeedback.Editor
{
    public class HKFeedbackGraphWindow : EditorWindow
    {
        private HKFeedbackGraphView graphView;

        [MenuItem("Window/HKFeedback/Graph", false, 0)]
        public static void OpenWindow()
        {
            var window = GetWindow<HKFeedbackGraphWindow>();
            window.titleContent = new GUIContent("HKFeedback Graph");
            window.Show();
        }

        private void CreateGUI()
        {
            graphView = new HKFeedbackGraphView();
            rootVisualElement.Add(graphView);
        }
    }
}
