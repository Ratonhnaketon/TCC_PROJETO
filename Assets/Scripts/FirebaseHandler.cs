using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Firebase;
using Firebase.Unity.Editor;
using System.Linq;
using RSG;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class FirebaseHandler : MonoBehaviour
{
	private const string projectId = "hellopoly-1590535973818";
	private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

	public delegate void ARObjectsCallback(ARObject[] arObjects);

	public void getElements(ARObjectsCallback callback, string hashtag = "")
	{
		RestClient.Get($"{databaseURL}leandro.json").Then(response => {
    		JObject json = JsonConvert.DeserializeObject<JObject>(response.Text);
			List<ARObject> arObjects = new List<ARObject>();
			foreach (var e in json)
			{
				string name = (string) e.Value["name"];
				string description = (string) e.Value["description"];
				string id = (string) e.Value["id"];
				string[] hashtags = { e.Value["hashtags"][0].ToString() };
				float scale = (float) e.Value["scale"];
				arObjects.Add(new ARObject(name, description, id, hashtags, scale));
			}
			callback(arObjects.ToArray());
		});
	}
}
