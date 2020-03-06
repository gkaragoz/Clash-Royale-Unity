using UnityEngine;

public static class DrawRect {

    private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;
    private static readonly GUIStyle textureStyle = new GUIStyle { normal = new GUIStyleState { background = backgroundTexture } };

    public static void DrawRectangle(Rect position, Color color, GUIContent content = null) {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUI.Box(position, content ?? GUIContent.none, textureStyle);
        GUI.backgroundColor = backgroundColor;
    }

    public static void LayoutBox(Color color, GUIContent content = null) {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUILayout.Box(content ?? GUIContent.none, textureStyle);
        GUI.backgroundColor = backgroundColor;
    }
}
