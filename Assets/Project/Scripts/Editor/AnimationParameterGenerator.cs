using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor.Animations;

public class AnimatorParameterGenerator : EditorWindow
{
    /// <summary>
    /// 파일 저장 경로
    /// </summary>
    public static readonly string filePath = "Assets/Project/Scripts/Generated/AnimatorParameter.cs";



    [MenuItem("Tools/Generate Animator Parameter Class")]
    public static void Generate()
    {
        // 모든 .controller 파일 찾기
        string[] guids = AssetDatabase.FindAssets("t:AnimatorController");
        var parameters = guids
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<AnimatorController>(path))
            .SelectMany(controller => controller.parameters)
            .Select(param => param.name)
            .Distinct()
            .ToList();

        // C# 코드 생성
        StringBuilder code = new StringBuilder();
        code.AppendLine("// Automatically generated Animator Parameter");
        code.AppendLine("public static class AnimatorParameter");
        code.AppendLine("{");
        foreach (string param in parameters)
        {
            // 유효한 C# 변수명으로 변환 (공백, 특수문자 제거)
            string validParamName = param.Replace(" ", "_").Replace("-", "_");
            code.AppendLine($"    public static readonly string {validParamName} = \"{param}\";");
        }
        code.AppendLine("}");

        // 파일 저장
        File.WriteAllText(filePath, code.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"{nameof(AnimatorParameterGenerator)}.cs has been generated at {filePath} with {parameters.Count} parameters.");
    }
}