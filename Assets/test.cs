using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mdal;
using OSGeo.GDAL;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OSGeo.GdalConfiguration.ConfigureGdal();
        OSGeo.GdalConfiguration.ConfigureOgr();
        Pdal.PdalConfiguration.ConfigurePdal();
        Debug.Log($"MDAL vrersion : {MdalConfiguration.ConfigureMdal()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
