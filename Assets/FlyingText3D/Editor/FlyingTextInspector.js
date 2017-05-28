// FlyingText3D 2.2
// ©2015 Starscene Software. All rights reserved. Redistribution without permission not allowed.

import UnityEditor.EditorGUILayout;
import UnityEngine.GUILayout;
import System.Collections.Generic;
import FlyingText3D;

@CustomEditor (FlyingText)
class FlyingTextInspector extends Editor {

	static var showFonts = true;
	static var showCharacterSettings = true;
	static var showTextSettings = true;
	static var showGOsettings = true;
	static var text = "";
	static var position = Vector3.zero;
	static var ttfFile : Font;
	static var initialized = false;
	var t : FlyingText;
	
	function OnEnable () {
		t = target;
	}
	
	function OnInspectorGUI () {
#if UNITY_3_5
		EditorGUIUtility.LookLikeControls (90);
#else
		EditorGUIUtility.labelWidth = 90;
#endif
		showFonts = Foldout (showFonts, "Font settings");
		if (showFonts) {
			var hasChanged = false;
			BeginVertical ("Box");
			if (Button ("+ Add Font")) {
				if (t.m_fontData == null) {
					t.m_fontData = new List.<FontData>();
				}
				t.m_fontData.Add (new FontData());
				EditorUtility.SetDirty (t);
			}
			if (t.m_fontData != null) {
				if (t.m_fontData.Count == 0) {
					HelpBox ('You need to add at least one font in order for FlyingText3D to work. Note that TTF fonts must be renamed to end with "bytes". You can use the convert .ttf to .bytes utility below to do this.', MessageType.Warning);
				}
				for (var i = 0; i < t.m_fontData.Count; i++) {
					BeginVertical ("Box");
					LabelField ("Name in font:", t.m_fontData[i].fontName);
					BeginHorizontal();
					BeginVertical();
					t.m_fontData[i].ttfFile = ObjectField ("Font #" + i, t.m_fontData[i].ttfFile, TextAsset, false);
					if (!hasChanged && GUI.changed) {
						if (t.m_fontData[i].ttfFile != null) {
							t.m_fontData[i].fontName = TTFFontInfo.GetFontName (t.m_fontData[i].ttfFile.bytes);
						}
						hasChanged = true;
					}
					EndVertical();
					if (Button ("X", Width(22), Height(16))) {
						t.m_fontData.RemoveAt (i);
						EditorUtility.SetDirty (target);
					}
					EndHorizontal();
					EndVertical();
				}
			}
			EndVertical();
		}
#if UNITY_3_5
		EditorGUIUtility.LookLikeControls (125);
#else
		EditorGUIUtility.labelWidth = 125;
#endif
		showCharacterSettings = Foldout (showCharacterSettings, "Character settings");
		if (showCharacterSettings) {
			BeginVertical ("Box");
			BeginHorizontal();
			t.m_defaultFont = IntField ("Default Font", t.m_defaultFont, Width(148));
			if (t.m_fontData != null && t.m_fontData.Count != 0) {
				t.m_defaultFont = Mathf.Clamp (t.m_defaultFont, 0, t.m_fontData.Count-1);
				Label ("(" + t.m_fontData[t.m_defaultFont].fontName + ")");
			}
			else {
				t.m_defaultFont = 0;
			}
			EndHorizontal();
			t.m_defaultMaterial = ObjectField ("Default Material", t.m_defaultMaterial, Material, false);
			t.m_defaultEdgeMaterial = ObjectField ("Default Edge Material", t.m_defaultEdgeMaterial, Material, false);
			t.m_useEdgeMaterial = Toggle ("Use Edge Material", t.m_useEdgeMaterial);
			t.m_defaultColor = ColorField ("Default Color", t.m_defaultColor);
			t.m_computeTangents = Toggle ("Compute Tangents", t.m_computeTangents);
			t.m_texturePerLetter = Toggle ("Texture Per Letter", t.m_texturePerLetter);
			t.m_includeBackface = Toggle ("Include Backface", t.m_includeBackface);
			t.m_defaultResolution = IntField ("Default Resolution", t.m_defaultResolution);
			if (t.m_defaultResolution < 1) {
				t.m_defaultResolution = 1;
			}
			t.m_defaultSize = FloatField ("Default Size", t.m_defaultSize);
			if (t.m_defaultSize < .001) {
				t.m_defaultSize = .001;
			}
			t.m_defaultDepth = FloatField ("Default Depth", t.m_defaultDepth);
			if (t.m_defaultDepth < 0.0) {
				t.m_defaultDepth = 0.0;
			}
			t.m_smoothingAngle = Slider ("Smoothing Angle", t.m_smoothingAngle, 0.0, 180.0);
			EndVertical();
		}
		showTextSettings = Foldout (showTextSettings, "Text settings");
		if (showTextSettings) {
			BeginVertical ("Box");
			t.m_defaultLetterSpacing = FloatField ("Default Letter Spacing", t.m_defaultLetterSpacing);
			t.m_defaultLineSpacing = FloatField ("Default Line Spacing", t.m_defaultLineSpacing);
			t.m_defaultLineWidth = FloatField ("Default Line Width", t.m_defaultLineWidth);
			t.m_wordWrap = Toggle ("Word Wrap", t.m_wordWrap);
			t.m_tabStop = FloatField ("Tab Stop", t.m_tabStop);
			if (t.m_tabStop < 0.0) {
				t.m_tabStop = 0.0;
			}
			t.m_defaultJustification = EnumPopup ("Default Justification", t.m_defaultJustification);
			t.m_verticalLayout = Toggle ("Vertical Layout", t.m_verticalLayout);
			EndVertical();
		}
		
		showGOsettings = Foldout (showGOsettings, "GameObject settings");
		if (showGOsettings) {
			BeginVertical ("Box");
			t.m_anchor = EnumPopup ("Text Anchor", t.m_anchor);
			t.m_zAnchor = EnumPopup ("Z Anchor", t.m_zAnchor);
			t.m_colliderType = EnumPopup ("Collider Type", t.m_colliderType);
			t.m_addRigidbodies = Toggle ("Add rigidbodies", t.m_addRigidbodies);
			t.m_physicsMaterial = ObjectField ("Physics Material", t.m_physicsMaterial, PhysicMaterial, false);
			EndVertical();
		}
		
		if (GUI.changed) {
			EditorUtility.SetDirty (target);
			initialized = false;
		}
		
		Space (8);
		Box ("", GUILayout.ExpandWidth (true), GUILayout.Height (2));
		Space (3);
		
#if UNITY_3_5
		EditorGUIUtility.LookLikeControls (50);
#else
		EditorGUIUtility.labelWidth = 50;
#endif
		Label ("Create FlyingText3D object utility", EditorStyles.boldLabel);
		text = EditorGUILayout.TextField ("Text: ", text);
		position = Vector3Field ("Location: ", position);
		if (text == "" || !(t.m_fontData != null && t.m_fontData.Count != 0)) {
			GUI.enabled = false;
		}
		if (Button ("Create")) {
			if (!initialized) {
				FlyingText.instance.Initialize();
				initialized = true;
			}
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
			Undo.RegisterSceneUndo ("Create 3D Text Object");
			var textObject = FlyingText.GetObject (text);
#else
			var textObject = FlyingText.GetObject (text);
			Undo.RegisterCreatedObjectUndo (textObject, "Create 3D Text Object");
#endif
			textObject.transform.position = position;
			var mesh = textObject.GetComponent(MeshFilter).sharedMesh;
			if (!System.IO.Directory.Exists (Application.dataPath + "/3DTextMeshes")) {
				AssetDatabase.CreateFolder ("Assets", "3DTextMeshes");
			}
			AssetDatabase.CreateAsset (mesh, AssetDatabase.GenerateUniqueAssetPath ("Assets/3DTextMeshes/" + mesh.name + ".asset"));
		}
		
		GUI.enabled = true;		
		Space (8);
		Box ("", GUILayout.ExpandWidth (true), GUILayout.Height (2));
		Space (3);
		
#if UNITY_3_5
		EditorGUIUtility.LookLikeControls (50);
#else
		EditorGUIUtility.labelWidth = 50;
#endif
		
		Label ("Convert .ttf to .bytes utility", EditorStyles.boldLabel);
		ttfFile = ObjectField ("TTF File:", ttfFile, Font, false);
		if (ttfFile == null) {
			GUI.enabled = false;
		}
		if (Button ("Convert")) {
			if (!System.IO.Directory.Exists (Application.dataPath + "/ConvertedFonts")) {
				AssetDatabase.CreateFolder ("Assets", "ConvertedFonts");
			}
			var file = AssetDatabase.GetAssetPath (ttfFile);
			if (file.ToLower().EndsWith (".ttf")) {
				var bytes = System.IO.File.ReadAllBytes (file);
				var idx = file.LastIndexOf ("/");
				file = file.Substring (idx+1, file.Length-idx-1);
				var name = Application.dataPath + "/ConvertedFonts/" + file.Substring (0, file.Length-4) + ".bytes";
				System.IO.File.WriteAllBytes (name, bytes);
				AssetDatabase.Refresh();
			}
		}
	}
}