using UnityEngine;
public static class TransformExtensions {

public static int GetSortingOrder (this Transform transform){
        return -(int)(transform.position.y * 100);
    }
}
