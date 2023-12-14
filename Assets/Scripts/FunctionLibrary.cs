using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary{

    public delegate Vector3 Function (float u, float v, float t);

    public enum FunctionName {Wave, MultiWave, Ripple, Sphere}

    static Function[] functions = {Wave, MultiWave, Ripple, Sphere};

    public static Function GetFunction (FunctionName name){
        return functions[(int)name];
    }

    public static Vector3 Wave(float u, float v, float t){
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u+v+t));
        p.z = v;
        return p;
    }
    
    public static Vector3 MultiWave(float u, float v, float t){
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += Sin(2f * PI * (v + t)) * (1f / 2f);
        p.y += Sin(PI * (u+v+0.25f*t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t){
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    public static Vector3 Sphere(float u, float v, float t){
        float r = 0.5f + 0.5f * Sin(PI * t);
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}