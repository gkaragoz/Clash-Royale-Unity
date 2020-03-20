using UnityEngine;
using System.IO;
using System;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;

public class AnimationLoaderEditor : EditorWindow {

    AnimationGroup_SO targetAnimationSO;
    string path = "Assets/Resources/Characters/";
    DirectoryInfo[] directoryInfos;

    [MenuItem("Window/Animation Loader")]
    public static void ShowWindow() {
        GetWindow<AnimationLoaderEditor>("Animation Loader");
    }

    private void SearchFolders() {
        try {
            DirectoryInfo tempDirInfo = new DirectoryInfo(path);
            directoryInfos = tempDirInfo.GetDirectories("*.*");
        } catch (Exception e) {
            Debug.LogWarning(e.Message);
        }
    }

    private void Load() {
        int animatitonTypesCount = directoryInfos.Length;
        AnimationEntity[] animationEntities = new AnimationEntity[animatitonTypesCount];

        for (int ii = 0; ii < animationEntities.Length; ii++) {
            animationEntities[ii] = new AnimationEntity();

            if (Enum.TryParse(directoryInfos[ii].Name, out AnimationType animationType)) {
                animationEntities[ii].AnimationType = animationType;
                animationEntities[ii].AnimationSprites = GetAnimationSprites(animationType);
            } else {
                Debug.LogError("Animation Type not found! Check sub folder names.");
                return;
            }
        }

        targetAnimationSO.Load(animationEntities);
    }

    private AnimationSprites[] GetAnimationSprites(AnimationType animationType) {
        AnimationSprites[] animationSprites = new AnimationSprites[Enum.GetNames(typeof(Direction)).Length];

        for (int ii = 0; ii < animationSprites.Length; ii++) {
            animationSprites[ii] = new AnimationSprites();

            DirectoryInfo directionFolder = directoryInfos.Where(d => d.Name == animationType.ToString()).SingleOrDefault();
            DirectoryInfo[] directionFolders = directionFolder.GetDirectories();

            if (Enum.TryParse(directionFolders[ii].Name, out Direction direction)) {
                animationSprites[ii].Direction = direction;
                animationSprites[ii].Sprites = Resources.LoadAll<Sprite>(path.Replace("Assets/Resources/", "") + "/" + animationType + "/" + direction.ToString());
            } else {
                Debug.LogError("Animation Direction not found! Check sub folder names.");
                return null;
            }
        }

        return animationSprites;
    }

    private void OnGUI() {
        GUILayout.Space(10f);
        // TODO find better one rather than Deprecated
        GUILayout.Label("Initializations:\t", EditorStyles.boldLabel);
        targetAnimationSO = (AnimationGroup_SO)EditorGUILayout.ObjectField("Target Animation SO\t", targetAnimationSO, typeof(AnimationGroup_SO), false);
        path = EditorGUILayout.TextField("Path:\t\t", path);

        GUILayout.Space(10f);
        if (GUILayout.Button("Search Folders")) {
            SearchFolders();
        }
        GUILayout.Space(10f);

        if (directoryInfos == null) {
            return;
        }

        foreach (DirectoryInfo dir in directoryInfos) {
            GUILayout.Label(dir.FullName, EditorStyles.boldLabel);
        }

        if (targetAnimationSO == null) {
            return;
        }

        GUILayout.Space(10f);
        if (GUILayout.Button("Load")) {
            Load();
        }
    }

}
#endif