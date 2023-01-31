using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class ModuleSerializationSurrogate : ISerializationSurrogate
{
    
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        GameObject mod = (GameObject)obj;
        /*info.AddValue("posx", mod.transform.position.x);
        info.AddValue("poxy", mod.transform.position.y);
        info.AddValue("poxz", mod.transform.position.z);*/
        //info.AddValue("price", mod.transform.GetComponent<ModuleHUD>().price);
        info.AddValue("caca", 1530);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {

        GameObject mod = (GameObject)obj;
        //mod.transform.position = new Vector3((float)info.GetValue("posx", typeof(float)), (float)info.GetValue("posy", typeof(float)), (float)info.GetValue("posz", typeof(float)));
        //mod.transform.GetComponent<ModuleHUD>().price = (int)info.GetValue("price", typeof(int));
        mod.transform.position = new Vector3(100, 100, (int)info.GetValue("caca", typeof(int)));
        obj = mod;
        return obj;
    }

}
