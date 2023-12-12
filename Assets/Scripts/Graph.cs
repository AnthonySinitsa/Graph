using UnityEngine;

public class Graph : MonoBehaviour{
    [SerializeField]
    Transform pointPrefab;

    void Awake(){
        var scale = Vector3.one / 5f;
        for(int i = 0; i < 10; i++){
            Transform point = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);
            point.localScale = scale;
        }

    }
}