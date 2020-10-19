﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Linq;
using RSG;
using System.Threading.Tasks;
using UnityEditor;
using System.Reflection;

[Serializable]
public class User
{
  public int id;
  public string name;
  public string username;
  public string email;
  public string phone;
  public string website;
}

// [Serializable]
// public class User
// {
//   public int id;
//   public string name;
//   public string username;
//   public string email;
//   public string phone;
//   public string website;
// }

public class FirebaseHandler : MonoBehaviour
{
	private const string projectId = "hellopoly-1590535973818";
	private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

	public delegate void ARObjectsCallback(ARObject[] arObjects);
	
	void Start() {

    // Set up the Editor before calling into the realtime database.
    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hellopoly-1590535973818.firebaseio.com/");

    // Get the root reference location of the database.
    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
  }

	public void getElements(ARObjectsCallback callback, string hashtag = "")
	{

     FirebaseDatabase.DefaultInstance
        .GetReference("leandro")
        .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted) {
            // Handle the error...
						Debug.Log("errou");
						Debug.Log(task);
          }
          else if (task.IsCompleted) {
            DataSnapshot snapshot = task.Result;
						var chaveEval = snapshot.ToString();
						// ARObject obj = new ARObject("a","a","a", v);
						var i = 0;

						Debug.Log("fiotes");
						Debug.Log(snapshot.ChildrenCount);
						ARObject[] convertedObjects = new ARObject[snapshot.ChildrenCount];

						foreach (DataSnapshot value in snapshot.Children) {
							string[] v = {""};
							ARObject obj = new ARObject("a","a","a", v);
							// Debug.Log(value);
							// obj = (ARObject)value.Value;
							Debug.LogFormat("valor de i {0}", i);
							foreach (DataSnapshot good in value.Children) {
								// Debug.LogFormat("Key = {0}, Value = {0}", good.Key, good.Value.ToString());
								// Debug.Log(good.Key);
								// Debug.Log(good.Value);

								if (good.Key == "id") {
									obj.id = good.Value.ToString();
								} else if (good.Key == "name") {
									obj.name = good.Value.ToString();
								} else if (good.Key == "description") {
									obj.description = good.Value.ToString();
								} else if (good.Key == "hashtags") {
									foreach (DataSnapshot hashTag in good.Children) {
										Debug.LogFormat("e ai? {0}", hashTag);
										obj.hashtags[0] = hashTag.Value.ToString();
									}
								}

							}

							convertedObjects[i] = obj;
							i++;
						}

						Debug.LogFormat("esse estah assim: {0} {1} {2} {3}", convertedObjects[0].id, convertedObjects[0].name, convertedObjects[0].description, convertedObjects[0].hashtags[0]);
						Debug.LogFormat("e esse assim: {0} {1} {2} {3}", convertedObjects[1].id, convertedObjects[1].name, convertedObjects[1].description, convertedObjects[1].hashtags[0]);
						callback(convertedObjects);
          }

		// var usersRoute = "https://jsonplaceholder.typicode.com/users"; 
		// RestClient.Get<User>(usersRoute + "/1").Then(firstUser => {
  	// 	EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(firstUser, true), "Ok");
		// });
		
		// RestClient.Get<Dictionary<string, ARObject>>($"{databaseURL}leandro.json").Then(arObjects => {
		// 	// EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(arObjects) , "Ok");
		// 	// Debug.Log("o tipo do cara");
		// 	// Debug.Log(arObjects.GetType());
		// 	// Debug.Log(((Dictionary<string,ARObject>)arObjects)["aaa"]);
		// 	// Debug.Log(((Dictionary<string,ARObject>)arObjects)["aaa"].id);

		// 	Type myType = arObjects.GetType();
		// 	// Debug.Log("myType");
		// 	// Debug.Log(myType);
		// 	IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

		// 	// Debug.Log("those are properties:");
		// 	// Debug.Log(props);

		// 	Debug.Log("aaaaaqui");
		// 	Debug.Log("i");
		// 	Debug.Log(JsonUtility.ToJson(arObjects));
		// 	Debug.Log("acola");


		// 	// var i = 0;

		// 	// foreach (PropertyInfo prop in props)
		// 	// {
		// 	// 		i++;
		// 	// 		Debug.Log("prop name: ");
		// 	// 		Debug.Log(prop.Name);
		// 	// 		Debug.Log(prop);
		// 	// 		object propValue = prop.GetValue(arObjects, null);
		// 	// 		Debug.Log("oi");
		// 	// 		Debug.Log(propValue);
		// 	// 		Debug.Log("tchau");

		// 	// 		// convertedObjects.Add(propValue);

		// 	// 		// Do something with propValue
		// 	// }
		// 	// Debug.Log(JsonUtility.FromJson(arObjects));
		// 	});
				});
	}
}
