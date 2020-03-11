using UnityEngine;

public static class ExtensionMethods {

    public static float Map(this float value, float fromSource, float toSource, float fromTarget, float toTarget) {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

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
    public static Direction GetDirection(this float degree) {
        //Topdown rotate angles
        if (degree <= 30 || degree > 330) {         // Right
            return Direction.Right;
        } else if (degree > 30 && degree <= 60) {   // Upper-Right
            return Direction.UpperRight;
        } else if (degree > 60 && degree <= 120) {  // Up
            return Direction.Up;
        } else if (degree > 120 && degree <= 150) { // Upper-Left
            return Direction.UpperLeft;
        } else if (degree > 150 && degree <= 210) { // Left
            return Direction.Left;
        } else if (degree > 210 && degree <= 240) { // Bottom-Left
            return Direction.BottomLeft;
        } else if (degree > 240 && degree <= 300) { // Bottom
            return Direction.Bottom;
        } else if (degree > 300 && degree <= 330) { // Bottom-Right 
            return Direction.BottomRight;
        } else {                                    // Default Bottom
            Debug.LogError("Check this degree status.");
            return Direction.Bottom;
        }
    }

}