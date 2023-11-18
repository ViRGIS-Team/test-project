using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mdal;
using Pdal;
using OSGeo.GDAL;
using g3;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OSGeo.GdalConfiguration.ConfigureGdal();
        OSGeo.GdalConfiguration.ConfigureOgr();
        Pdal.PdalConfiguration.ConfigurePdal();
        Debug.Log($"MDAL vrersion : {MdalConfiguration.ConfigureMdal()}");
        string path = Application.streamingAssetsPath;
        Datasource ds = Datasource.Load(Path.Combine(path, "paraboloid.m.tin"));
        MdalMesh mesh = ds.GetMesh(0);
        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh = mesh;
        PolyLine3d test = new PolyLine3d(((DMesh3)mesh).Vertices());
        Vector3 t2 = (Vector3)test[0];
        List<object> pipe = new List<object>();
        pipe.Add(Path.Combine(path,"autzen-height.tif"));
        pipe.Add(new
            {
                type = "filters.delaunay"
            }
        );

        string json = JsonConvert.SerializeObject(pipe.ToArray());

        Pipeline pl = new Pipeline(json);

        long count = pl.Execute();

        Debug.Log($"Point Count is {count}");

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
