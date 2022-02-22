using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffects : MonoBehaviour
{
    public PostProcessProfile globalPostProcess_default;
    public PostProcessProfile globalPostProcess_hit;
    public PostProcessVolume globalPostProcess;
    public IEnumerator shake(float mag, float dur)
    {
        Vector3 origpos = transform.localPosition;
        float elapsed = 0f;
        globalPostProcess.profile = globalPostProcess_hit;
        while (elapsed < dur)
        {
            float x = Random.Range(-1f, 1f) * mag;
            float y = Random.Range(-1f, 1f) * mag;
            transform.localPosition = new Vector3(x, y, origpos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        globalPostProcess.profile = globalPostProcess_default;
        transform.localPosition = origpos;
    }
}
