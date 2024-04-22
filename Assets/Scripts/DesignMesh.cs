using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignMesh : MonoBehaviour
{
    public MeshFilter filter;
    public Mesh[] meshes;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int c = 0;
        while(true)
        {
            if (c >= meshes.Length)
                c = 0;

            filter.mesh = meshes[c];

            c++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
