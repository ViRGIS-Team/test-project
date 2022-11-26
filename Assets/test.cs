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
        Debug.Log(MdalConfiguration.ConfigureMdal());
        OSGeo.GdalConfiguration.ConfigureGdal();
        OSGeo.GdalConfiguration.ConfigureOgr();
        Pdal.PdalConfiguration.ConfigurePdal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
