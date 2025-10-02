using UnityEngine;
using UnityEditor;

public class BulkRename : EditorWindow
{
  private static int popup_window_width  = 250;
  private static int popup_window_height = 100;
  private static readonly Vector2Int popup_window_size = new Vector2Int(popup_window_width,
                                                                        popup_window_height);
  private string prefix;
  private int start_idx;

  [MenuItem("GameObject/Bulk Rename")]

  public static void ShowWindow()
  {
    EditorWindow window = GetWindow<BulkRename>();
    window.minSize = popup_window_size;
    window.maxSize = popup_window_size;
  }

  private void OnGUI()
  {
    prefix = EditorGUILayout.TextField("Prefix", prefix);
    start_idx = EditorGUILayout.IntField("Start index", start_idx);
    
    if (GUILayout.Button("Rename Children"))
    {
      GameObject[] selected_obj = Selection.gameObjects;
      for (int obj_idx = 0; obj_idx < selected_obj.Length; obj_idx++)
      {
        Transform selected_obj_transform = selected_obj[obj_idx].transform;
        for (int child_idx = 0, idx = start_idx;
             child_idx < selected_obj_transform.childCount;
             child_idx++, idx++)
        {
          // NOTE(arka): idx:D3 means formating idx as 3 digit number padded with leading zeros if necessary --------------------------------------------------------------------------------
          selected_obj_transform.GetChild(child_idx).name = $"{prefix}{idx:D3}";
        }
      }
    }
  }
}
