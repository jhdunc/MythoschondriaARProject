using System.IO;
using ADG;
using insitu;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(App))]
public class AppEditor : insitu.AppEditor
{
	public override void OnEnable()
	{
		base.OnEnable();
		SceneView.duringSceneGui += OnScene;
	}

	public void OnDisable()
	{
		SceneView.duringSceneGui -= OnScene;
	}

	public void OnScene(SceneView view)
	{
		// This method can be used to draw a visual repesentation of settings in the Scene view				
	}


	public override void OnInspectorGUISettings()
	{
		var app = (App)target;
		var settings = app.FetchSettings();

		EditorGUI.BeginChangeCheck();
		EditorGUILayout.LabelField("Vicon Settings");
        settings["host"] = EditorGUILayout.TextField("Host", settings.StringOf("host", "127.0.0.1"));
        settings["port"] = EditorGUILayout.IntField("Port", settings.NumberOf("port", 801));
		settings["streaming_mode"] = EditorGUILayout.Popup("Vicon Mode", settings.NumberOf("streaming_mode", 1), StreamingModes);
		settings["vicon_mode"] = EditorGUILayout.Popup("Vicon Mode", settings.NumberOf("vicon_mode", 1), ViconModes);
		settings["scale"] = EditorGUILayout.FloatField("Scale", settings.NumberOf("scale", 1));
		//settings["rotation_offset"] = EditorGUILayout.FloatField("Room Orientation", settings.NumberOf("rotation_offset"));

		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Game Settings");
		
        settings["seed"] = EditorGUILayout.IntField("Game Seed", settings.NumberOf("seed"));
		
		if (EditorGUI.EndChangeCheck())
		{
			var content = settings.Stringify(Json.Pretty);
			SettingsString = content;
			File.WriteAllText(App.SettingsPath, content);
			SceneView.RepaintAll();
		}

	}
}
