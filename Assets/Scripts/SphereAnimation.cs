using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnimation : MonoBehaviour
{
    [SerializeField]
    Vector3 m_Center;
    [SerializeField]
    float m_Radius;
    [SerializeField]
    int m_Sum;
    [SerializeField]
    GameObject m_Prefabe;

    List<GameObject> m_Objs = new List<GameObject>();
    Coroutine m_Coroutine;
    IEnumerator GenerateSphereSurface(Vector3 center, float radius, int sum, GameObject prefabe)
    {
        float phi = Mathf.PI * (3f - Mathf.Sqrt(5f));
        float x, y, z;
        float unitRadius;
        float theta;
        Vector3 point;
        for (int i = 0; i < sum; i++)
        {
            y = 1f - i / (sum - 1f) * 2f;
            unitRadius = Mathf.Sqrt(1f - y * y);
            theta = phi * i;
            x = Mathf.Cos(theta) * unitRadius;
            z = Mathf.Sin(theta) * unitRadius;
            point = new Vector3(x, y, z) * radius;
            var obj = Instantiate(prefabe, center + point, Quaternion.identity, transform);
            obj.transform.LookAt(center);
            m_Objs.Add(obj);
            yield return null;
        }
    }
    void Play()
    {
        foreach (GameObject obj in m_Objs)
        {
            Destroy(obj);
        }
        m_Objs.Clear();
        if (m_Coroutine != null)
            StopCoroutine(m_Coroutine);
        m_Coroutine = StartCoroutine(GenerateSphereSurface(m_Center, m_Radius, m_Sum, m_Prefabe));
    }
    void OnGUI()
    {
        if (GUILayout.Button("Play"))
        {
            Play();
        }
    }
}