using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridEditor : MonoBehaviour
{
    private float cell_size = 0.32f; //cell size
    private float x, y, z;

    void Start()
    {
        x = 0f;
        y = 0f;
        z = 0f;
    }

    void Update()
    {
        x = Mathf.Round(transform.position.x / cell_size) * cell_size;
        y = Mathf.Round(transform.position.y / cell_size) * cell_size;
        z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
