using System.Collections.Generic;
using Unity.Collections;
using System;
using System.Diagnostics;
using UnityEngine;
using Mdal;
using Pdal;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
using VirgisGeometry;
using System.IO;
using Newtonsoft.Json;
using Debug = UnityEngine.Debug;

public class test : MonoBehaviour
{

    public GameObject OgrGameObject;
    public GameObject Ogr2;
    public GameObject GdalGameObject;
    // Start is called before the first frame update
    void Start()
    {
        OSGeo.GdalConfiguration.ConfigureGdal();
        OSGeo.GdalConfiguration.ConfigureOgr();
        Debug.Log($"GDAL Path : {Gdal.GetConfigOption("GDAL_DATA", null)}");
        SpatialReference sr = new SpatialReference("");
        int ret = sr.ImportFromPCI( "LONG/LAT    D506", "DEGREE", null);
        if (ret != 0 ) Debug.LogError("GDAL Configuration incorrect");
        sr.ExportToPrettyWkt(out string wkt,0);
        Debug.Log(wkt);
        PdalConfiguration.ConfigurePdal();
        Debug.Log($"MDAL vrersion : {MdalConfiguration.ConfigureMdal()}");
        string path = Application.streamingAssetsPath;
        MeshFilter mf = OgrGameObject.GetComponent<MeshFilter>();

        try
        {
            /* -------------------------------------------------------------------- */
            /*      Open dataset.                                                   */
            /* -------------------------------------------------------------------- */
            Dataset dataset = Gdal.Open(Path.Combine(path, "bug4468.tif"), Access.GA_ReadOnly);

            if (dataset == null)
            {
                throw new Exception("Can't open GDAL");
            }

            Debug.Log("Raster dataset parameters:");
            Debug.Log("  Projection: " + dataset.GetProjectionRef());
            Debug.Log("  RasterCount: " + dataset.RasterCount);
            Debug.Log("  RasterSize (" + dataset.RasterXSize + "," + dataset.RasterYSize + ")");

            /* -------------------------------------------------------------------- */
            /*      Get driver                                                      */
            /* -------------------------------------------------------------------- */
            OSGeo.GDAL.Driver drv = dataset.GetDriver();

            if (drv == null)
            {
                throw new Exception("Can't get driver.");
            }

            Console.WriteLine("Using driver " + drv.LongName);

            /* -------------------------------------------------------------------- */
            /*      Get raster band                                                 */
            /* -------------------------------------------------------------------- */
            for (int iBand = 1; iBand <= dataset.RasterCount; iBand++)
            {
                Band band = dataset.GetRasterBand(iBand);
                Debug.Log("Band " + iBand + " :");
                Debug.Log("   DataType: " + band.DataType);
                Debug.Log("   Size (" + band.XSize + "," + band.YSize + ")");
                Debug.Log("   PaletteInterp: " + band.GetRasterColorInterpretation().ToString());

                for (int iOver = 0; iOver < band.GetOverviewCount(); iOver++)
                {
                    Band over = band.GetOverview(iOver);
                    Debug.Log("      OverView " + iOver + " :");
                    Debug.Log("         DataType: " + over.DataType);
                    Debug.Log("         Size (" + over.XSize + "," + over.YSize + ")");
                    Debug.Log("         PaletteInterp: " + over.GetRasterColorInterpretation().ToString());
                }
            }

            /* -------------------------------------------------------------------- */
            /*      Processing the raster                                           */
            /* -------------------------------------------------------------------- */


            Stopwatch timer = new Stopwatch();
            timer.Start();
            Texture2D tex = dataset.ToRGB();

            // OGR Section


            DataSource datasource = Ogr.Open(Path.Combine(path, "polygon.geojson"), 1);
            if (datasource == null)
                throw (new FileNotFoundException());

            Debug.Log($"Number of OGR Layers : {datasource.GetLayerCount()}");
            Layer layer = datasource.GetLayerByIndex(0);
            layer.ResetReading();
            Feature f = null;
            do
            {
                f = layer.GetNextFeature();
                if (f != null)
                {
                    Debug.Log($"Found Feature {f.DumpReadableAsString(new string[0])}");
                    Geometry geom = f.GetGeometryRef();
                    Matrix4x4 trans = OgrGameObject.transform.worldToLocalMatrix;
                    trans *= Ogr2.transform.localToWorldMatrix;
                    foreach (DMesh3 pmesh in geom.ToMeshList())
                    {
                        pmesh.Transform(trans, default, true);
                        pmesh.CalculateMapUVs(dataset);
                        mf.mesh = (Mesh)pmesh;
                    }
                }
            } while (f != null);



            if (tex is not null)
            {
                MeshRenderer mr = GdalGameObject.GetComponent<MeshRenderer>();
                Material mat = mr.material;
                mat.SetTexture("_MainTex", tex);
                mat.mainTexture = tex;
            }
            Debug.Log($"GDAL Raster Load took { timer.ElapsedMilliseconds} ms");
        }
        catch (Exception e)
        {
            throw new Exception("Application error: " + e.Message);
        }

        // MDAL Section

        Datasource ds = Datasource.Load(Path.Combine(path, "paraboloid.m.tin"));
        MdalMesh mesh = ds.GetMesh(0);
        mf = GetComponent<MeshFilter>();
        mf.mesh = mesh;
        PolyLine3d test = new PolyLine3d(((DMesh3)mesh).Vertices());
        Vector3 t2 = (Vector3)test[0];

        //PDAL Section
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
        TransformSequence ts = transform.localToWorldMatrix;
        Debug.Log(ts);
    }
}
