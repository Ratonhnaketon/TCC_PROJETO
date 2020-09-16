using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Firebase;
using Firebase.Unity.Editor;
using System.Linq;
using RSG;
using System.Threading.Tasks;

public class FirebaseHandler : MonoBehaviour
{
	private const string projectId = "hellopoly-1590535973818";
	private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

	public delegate void ARObjectsCallback(ARObject[] arObjects);

	public void getElements(ARObjectsCallback callback, string hashtag = "")
	{
		RestClient.GetArray<ARObject>($"{databaseURL}ARObjects.json").Then(arObjects => callback(arObjects));
	}
}
