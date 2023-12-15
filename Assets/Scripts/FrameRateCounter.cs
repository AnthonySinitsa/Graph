using UnityEngine;
using TMPro;

public class FrameRateCounter : MonoBehaviour{

    [SerializeField]
    TextMeshProUGUI display;

    void Update(){
        float frameDuration = Time.unscaledDeltaTime;
        display.SetText("FPS\n000\n000\n000");
    }
}