using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject preb;
    [SerializeField,Range(0.0f,5.0f)]
    private float radius = 0.0f;//生成半径
    [SerializeField]
    private int max_generateNumber = 10;//最大生成数量


    private void Start()
    {
        Generate();
    }


    private void Generate()
    {
        for(int i = 0;i<max_generateNumber;i++)
        {
            //Vector3 pos = generateFunc(radius);
            Vector3 pos = generateFunc2(radius);

            GameObject.Instantiate(preb,pos,Quaternion.identity);
        }

    }

    private Vector3 generateFunc(float _radius)
    {

        float rad = 2.0f * Mathf.PI * Random.value;
        float u = Random.value + Random.value;
        float r = Mathf.Infinity;

        if (u > 1.0f) r = 2.0f - u;
        else r = u;

        return new Vector3(r*_radius*Mathf.Cos(rad),r*_radius*Mathf.Sin(rad));
    }

    private Vector3 generateFunc2(float _radius)
    {
        float r = Mathf.Sqrt(Random.value);
        float rad = 2.0f * Mathf.PI * Random.value;
        return new Vector3(_radius * r * Mathf.Cos(rad), _radius * r * Mathf.Sin(rad));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(),this.radius);
    }
}
