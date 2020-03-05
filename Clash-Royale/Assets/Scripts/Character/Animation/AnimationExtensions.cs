using UnityEngine;

public static class AnimationExtensions {

    /// <summary>
    /// Get angle from single vector based on direction of Vector2.Right (1, 0)
    /// </summary>
    /// <param name="targetVector"></param>
    /// <returns>float angle</returns>
    public static float GetAngleFromVector2(Vector2 targetVector) {
        return Vector2.Angle(targetVector, Vector2.right);
    }
    
    /// <summary>
    /// Works based on standard cartesian coordinate system via degree.
    /// </summary>
    /// <param name="degree"></param>
    /// <returns>InputVector</returns>
    public static InputVector GetDirectionVector(this float degree) {
        //Topdown rotate angles
        if (degree <= 30 || degree > 330) {         // Right
            return new InputVector() {
                x = 1,
                y = 0
            };
        } else if (degree > 30 && degree <= 60) {   // Upper-Right
            return new InputVector() {
                x = 0.5f,
                y = 0.5f
            };
        } else if (degree > 60 && degree <= 120) {  // Up
            return new InputVector() {
                x = 0,
                y = 1f
            };
        } else if (degree > 120 && degree <= 150) { // Upper-Left
            return new InputVector() {
                x = -0.5f,
                y = 0.5f
            };
        } else if (degree > 150 && degree <= 210) { // Left
            return new InputVector() {
                x = -1,
                y = 0
            };
        } else if (degree > 210 && degree <= 240) { // Bottom-Left
            return new InputVector() {
                x = -0.5f,
                y = -0.5f
            };
        } else if (degree > 240 && degree <= 300) { // Bottom
            return new InputVector() {
                x = 0,
                y = -1
            };
        } else if (degree > 300 && degree <= 330) { // Default Bottom
            return new InputVector() {
                x = 0.5f,
                y = -0.5f
            };
        } else {
            return new InputVector() {
                x = 0,
                y = -1
            };
        }
    }
}

public class InputVector {
    public float x;
    public float y;
}