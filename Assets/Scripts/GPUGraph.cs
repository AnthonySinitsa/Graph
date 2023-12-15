using UnityEngine;

public class GPUGraph : MonoBehaviour{

    [SerializeField, Range(10, 200)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;

    public enum TransitionMode {Cycle, Random}

    [SerializeField]
    TransitionMode transitionMode;

    [SerializeField, Min(0f)]
    float functionDuration = 1f, transitionDuration = 1f;

    float duration;
    bool transitioning;
    FunctionLibrary.FunctionName transitionFunction;

    ComputeBuffer positionsBuffer;

    // OnEnable method gets invoked each time component is enabled, happens after it awakens and after hot reload is complete.
    void OnEnable(){
        // We need to store 3D position vectors, which consist of three float numbers, so the element size is three times four bytes. Thus 40,000 positions would require 0.48MB or roughly 0.46MiB of GPU memory.
        positionsBuffer = new ComputeBuffer(resolution * resolution, 3 * 4);
    }

    void OnDisable(){
        positionsBuffer.Release();
        positionsBuffer = null;
    }

    void Update() {
        duration += Time.deltaTime;
        if(transitioning){
            if(duration >= transitionDuration){
                duration -= transitionDuration;
                transitioning = false;
            }
        } else if(duration >= functionDuration){
            duration -= functionDuration;
            transitioning = true;
            transitionFunction = function;
            PickNextFunction();
        }
    }

    void PickNextFunction(){
        function = transitionMode == TransitionMode.Cycle ?
        FunctionLibrary.GetNextFunctionName(function) :
        FunctionLibrary.GetRandomFunctionNameOtherThan(function);
    }
}