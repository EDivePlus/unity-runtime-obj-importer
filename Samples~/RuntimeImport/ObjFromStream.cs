using Dummiesman;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ObjFromStream : MonoBehaviour
{
    IEnumerator Start()
    {
        using (var request = UnityWebRequest.Get("https://people.sc.fsu.edu/~jburkardt/data/obj/lamp.obj"))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed to download OBJ: {request.error}");
                yield break;
            }

            using (var textStream = new MemoryStream(Encoding.UTF8.GetBytes(request.downloadHandler.text)))
            {
                new OBJLoader().Load(textStream);
            }
        }
    }
}
