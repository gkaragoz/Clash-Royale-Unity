using UnityEngine;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;

public class AnimationLoaderEditor : EditorWindow {

    AnimationGroup_SO targetAnimationSO;
    string path = "Assets/Resources/Characters/";
    FileInfo[] fileInfos;

    [MenuItem("Window/Animation Loader")]
    public static void ShowWindow() {
        GetWindow<AnimationLoaderEditor>("Animation Loader");
    }

    private void SearchFiles() {
        try {
            DirectoryInfo tempDirInfo = new DirectoryInfo(path);
            fileInfos = tempDirInfo.GetFiles("*.png");
        } catch (Exception e) {
            Debug.LogWarning(e.Message);
        }
    }

    private void Load() {
        int animatitonTypesCount = fileInfos.Length;
        AnimationEntity[] animationEntities = new AnimationEntity[animatitonTypesCount];

        for (int ii = 0; ii < animationEntities.Length; ii++) {
            animationEntities[ii] = new AnimationEntity();
            animationEntities[ii].AnimationType = (AnimationType)ii;
            animationEntities[ii].AnimationSprites = GetAnimationSprites((AnimationType)ii);
        }

        targetAnimationSO.Load(animationEntities);
    }

    private AnimationSprites[] GetAnimationSprites(AnimationType animationType) {

        int directionsCount = ExtensionMethods.GetDirectionsCount();
        AnimationSprites[] animationSprites = new AnimationSprites[directionsCount];

        for (int ii = 0; ii < directionsCount; ii++) {
            animationSprites[ii] = new AnimationSprites();
            animationSprites[ii].Direction = (Direction)ii;
            animationSprites[ii].Sprites = GetAnimationFrames(ii, animationType);
        }

        return animationSprites;
    }

    private Sprite[] GetAnimationFrames(int index, AnimationType animationType) {
        List<Sprite> sprites = (Resources.LoadAll<Sprite>(path.Replace("Assets/Resources/", "") + animationType.ToString()).ToList());

        int frameCount = sprites.Count / ExtensionMethods.GetDirectionsCount();

        return sprites.GetRange(frameCount * index, frameCount).ToArray();
    }

    private void OnGUI() {
        GUILayout.Space(10f);
        // TODO find better one rather than Deprecated
        GUILayout.Label("Initializations:\t", EditorStyles.boldLabel);
        targetAnimationSO = (AnimationGroup_SO)EditorGUILayout.ObjectField("Target Animation SO\t", targetAnimationSO, typeof(AnimationGroup_SO), false);
        path = EditorGUILayout.TextField("Path:\t\t", path);

        GUILayout.Space(10f);
        if (GUILayout.Button("Search Files")) {
            SearchFiles();
        }
        GUILayout.Space(10f);

        if (fileInfos == null) {
            return;
        }

        foreach (FileInfo file in fileInfos) {
            GUILayout.Label(file.FullName, EditorStyles.boldLabel);
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