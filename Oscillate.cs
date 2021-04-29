using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use this class to make an object oscillate between two different positions, rotations, colors or materials
//The same logic can be applied if you'd like to oscillate between two other properties
[System.Serializable]
public class Rotations
{
    [Tooltip("Enable oscillating angles")]
    public bool rotationEnabled;
    [Tooltip("If true, lerp between local euler angles. If false, global euler angles")]
    public bool isRotationLocal;
    [Tooltip("Choose between a sine or a cosine wave")]
    public bool useSineWave;
    [Tooltip("Starting angle")]
    public Vector3 rotateFrom;
    [Tooltip("Ending angle")]
    public Vector3 rotateTo;
    [Tooltip("Speed of oscillation")]
    public float speed;
}

[System.Serializable]
public class Positions
{
    [Tooltip("Enable oscillating positions")]
    public bool positionEnabled;
    [Tooltip("If true, lerp between local positions. If false, global positions")]
    public bool isPositionLocal;
    [Tooltip("Choose between a sine or a cosine wave. This is useful if two objects need to be offset")]
    public bool useSineWave;
    [Tooltip("Starting position")]
    public Vector3 fromThisPosition;
    [Tooltip("Ending position")]
    public Vector3 toThisPosition;
    [Tooltip("Speed of oscillation")]
    public float speed;
}

[System.Serializable]
public class Colors
{
    [Tooltip("Enable oscillating colors")]
    public bool colorsEnabled;
    [Tooltip("Choose between a sine or a cosine wave")]
    public bool useSineWave;
    [Tooltip("Starting color")]
    public Color fromThisColor;
    [Tooltip("Ending color")]
    public Color toThisColor;
    [Tooltip("Speed of oscillation")]
    public float speed;
}

[System.Serializable]
public class Scales
{
    [Tooltip("Enable oscillating colors")]
    public bool scaleEnabled;
    [Tooltip("Choose between a sine or a cosine wave")]
    public bool useSineWave;
    [Tooltip("Starting scale")]
    public Vector3 fromThisScale;
    [Tooltip("Ending scale")]
    public Vector3 toThisScale;
    [Tooltip("Speed of oscillation")]
    public float speed;
}

[System.Serializable]
public class Materials
{
    [Tooltip("Enable oscillating colors")]
    public bool materialsEnabled;
    [Tooltip("Choose between a sine or a cosine wave")]
    public bool useSineWave;
    [Tooltip("Starting material")]
    public Material fromThisMaterial;
    [Tooltip("Ending material")]
    public Material toThisMaterial;
    [Tooltip("Speed of oscillation")]
    public float speed;
}

    public class Oscillate : MonoBehaviour
    {
    public Rotations oscillateRotation;
    public Positions oscillatePosition;
    public Scales oscillateScale;
    public Colors oscillateColors;
    public Materials oscillateMaterials;

    void LerpPosition()
    {
        float t;
        if (oscillatePosition.useSineWave)
            t = (Mathf.Sin(Time.time * oscillatePosition.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        else
            t = (Mathf.Cos(Time.time * oscillatePosition.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;

        if (oscillatePosition.isPositionLocal)
            this.gameObject.transform.localPosition = Vector3.Lerp(oscillatePosition.fromThisPosition, oscillatePosition.toThisPosition, t);
        else
            this.gameObject.transform.position = Vector3.Lerp(oscillatePosition.fromThisPosition, oscillatePosition.toThisPosition, t);
    }

    void LerpRotation()
    {
        float t;
        if (oscillateRotation.useSineWave)
            t = (Mathf.Sin(Time.time * oscillateRotation.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        else
            t = (Mathf.Cos(Time.time * oscillateRotation.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;

        if (oscillateRotation.isRotationLocal)
            this.gameObject.transform.localEulerAngles = Vector3.Lerp(oscillateRotation.rotateFrom, oscillateRotation.rotateTo, t);
        else
            this.gameObject.transform.eulerAngles = Vector3.Lerp(oscillateRotation.rotateFrom, oscillateRotation.rotateTo, t);

    }

    void LerpScale()
    {
        float t;
        if (oscillateScale.useSineWave)
            t = (Mathf.Sin(Time.time * oscillateScale.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        else
            t = (Mathf.Cos(Time.time * oscillateScale.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;

        this.gameObject.transform.localScale = Vector3.Lerp(oscillateScale.fromThisScale, oscillateScale.toThisScale, t);

    }

    void LerpColors()
    {
        float t;
        if (oscillateColors.useSineWave)
            t = (Mathf.Sin(Time.time * oscillateColors.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        else
            t = (Mathf.Cos(Time.time * oscillateColors.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;

        this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(oscillateColors.fromThisColor, oscillateColors.toThisColor, t);

    }

    void LerpMaterials()
    {
        float t;
        if (oscillateMaterials.useSineWave)
            t = (Mathf.Sin(Time.time * oscillateMaterials.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        else
            t = (Mathf.Cos(Time.time * oscillateMaterials.speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;

        this.gameObject.GetComponent<Renderer>().material.Lerp(oscillateMaterials.fromThisMaterial, oscillateMaterials.toThisMaterial, t);

    }

    // Update is called once per frame
    void Update () {
        if (oscillateRotation.rotationEnabled) LerpRotation() ;
        if (oscillatePosition.positionEnabled) LerpPosition();
        if (oscillateScale.scaleEnabled) LerpScale();
        if (oscillateColors.colorsEnabled) LerpColors();
        if (oscillateMaterials.materialsEnabled) LerpMaterials();
    }
}
