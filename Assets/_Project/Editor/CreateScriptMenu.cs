using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
	public static class CreateScriptMenu
	{
		[MenuItem("Assets/G2D/Create MonoBehaviour Template")]
		static void CreateMonoBehaviour()
		{
			string newFilePath = EditorUtility.SaveFilePanel("Create MonoBehaviour", GetCurrentPath(), "NewMonoBehaviour", "cs");
			string templatePath = Application.dataPath + "/_Project/Editor/MonoBehaviourTemplate.txt";
			MakeScriptFromTemplate(newFilePath, templatePath);
		}
	
		[MenuItem("Assets/G2D/Create Scriptable Object Template")]
		static void CreateScriptableObject()
		{
			string newFilePath = EditorUtility.SaveFilePanel("Create Scriptable Object", GetCurrentPath(), "NewScriptableObject", "cs");
			string templatePath = Application.dataPath + "/_Project/Editor/ScriptableObjectTemplate.txt";
			MakeScriptFromTemplate(newFilePath, templatePath);
		}
	
		[MenuItem("Assets/G2D/Create Editor Template")]
		static void CreateEditor()
		{
			string newFilePath = EditorUtility.SaveFilePanel("Create Editor", GetCurrentPath(), "NewEditor", "cs");
			string templatePath = Application.dataPath + "/_Project/Editor/EditorTemplate.txt";
			MakeScriptFromTemplate(newFilePath, templatePath);
		}

		static string GetCurrentPath()
		{
			string path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
			if (path.Contains("."))
			{
				int index = path.LastIndexOf("/");
				path = path.Substring(0, index);
			}
			return path;
		}
		static void MakeScriptFromTemplate(string newFilePath, string templatePath)
		{
			if (!string.IsNullOrEmpty(newFilePath))
			{
				FileInfo file = new FileInfo(newFilePath);
				string scriptName = Path.GetFileNameWithoutExtension(file.Name);
				string text = File.ReadAllText(templatePath);
			
				text = text.Replace("#SCRIPTNAME#", scriptName);
				text = text.Replace("#YEAR#", DateTime.Now.Year.ToString());
				text = text.Replace("#SCRIPTNAMEWITHOUTEDITOR#", scriptName.Replace("Editor", ""));
			
				File.WriteAllText(newFilePath, text);
				AssetDatabase.Refresh();
			}
		}
	}
}
