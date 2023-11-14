using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mdal;
using OSGeo.GDAL;
using g3;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OSGeo.GdalConfiguration.ConfigureGdal();
        OSGeo.GdalConfiguration.ConfigureOgr();
        Pdal.PdalConfiguration.ConfigurePdal();
        Debug.Log($"MDAL vrersion : {MdalConfiguration.ConfigureMdal()}");
        g3_test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void g3_test() {
        Vector3 unityVec = new();
        Vector3f g3Vec = new();
        unityVec = g3Vec;
        g3Vec = unityVec;

        Vector2 unityVec2 = new();
        Vector2f g3Vec2 = new();
        unityVec2 = g3Vec2;
        g3Vec2 = unityVec2;

        Vector3d g3Vecd = new();
        g3Vecd = gameObject.transform.position;
        gameObject.transform.position = (Vector3)g3Vecd;

        Vector2d g3Vecd2 = new();
        g3Vecd2 = unityVec2;
        unityVec2 = (Vector2)g3Vecd2;
    }
}
