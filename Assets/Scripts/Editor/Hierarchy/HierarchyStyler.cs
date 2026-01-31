using System.Collections.Generic;
using System.Text.RegularExpressions;
using StudyProject.Constants;
using StudyProject.Enums;
using UnityEditor;
using UnityEngine;

namespace StudyProject.Editor.Hierarchy
{
	[InitializeOnLoad]
	public class HierarchyStyler
	{
		private static readonly Regex _pattern = new(@"^(-{3,})\s*(.+)$", RegexOptions.Compiled);

        private static readonly Dictionary<Color, GUIStyle> _styleCache = new();

        static HierarchyStyler()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceID, Rect rect)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is not GameObject go)
            {
                return;
            }

            Match match = _pattern.Match(go.name);
            if (!match.Success)
            {
                return;
            }

            int dashCount = match.Groups[1].Value.Length;
            string title = match.Groups[2].Value;

            EditorGUI.DrawRect(rect, DictionariesContainer.Colors[ColorType.DarkGray]);

            EditorGUI.LabelField(rect, GUIContent.none);

            Color textColor = GetColorByDashCount(dashCount);

            if (!_styleCache.TryGetValue(textColor, out var style))
            {
                style = new GUIStyle(EditorStyles.boldLabel)
                {
                    alignment = TextAnchor.MiddleCenter,
                    normal = { textColor = textColor },
                    hover = { textColor = textColor },
                    active = { textColor = textColor },
                    focused = { textColor = textColor }
                };
                _styleCache[textColor] = style;
            }

            GUI.Label(rect, title, style);
        }

        private static Color GetColorByDashCount(int count)
        {
            return count switch
            {
                3 => DictionariesContainer.Colors[ColorType.PaleBlue],
                4 => DictionariesContainer.Colors[ColorType.PaleGreen],
                5 => DictionariesContainer.Colors[ColorType.Orange],
                6 => DictionariesContainer.Colors[ColorType.LightGreen],
                >= 7 => DictionariesContainer.Colors[ColorType.Purple],
                _ => DictionariesContainer.Colors[ColorType.White]
            };
        }
	}
}