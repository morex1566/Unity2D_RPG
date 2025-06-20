using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System.Text;

public class LayerGenerator : EditorWindow
{
    /// <summary>
    /// 파일 저장 경로
    /// </summary>
    public static readonly string filePath = "Assets/Project/Scripts/Generated/Layer.cs";



    [MenuItem("Tools/Generate Layer Class")]
    public static void Generate()
    {
        // 태그 목록 가져오기
        string[] layers = InternalEditorUtility.layers;

        // C# 파일 내용 생성
        StringBuilder context = new StringBuilder();
        context.AppendLine("// Auto-generated Layer class");
        context.AppendLine("public static class Layer");
        context.AppendLine("{");
        foreach (string layer in layers)
        {
            // 유효한 C# 식별자로 변환 (공백이나 특수문자 처리)
            string validFieldName = layer.Replace(" ", "_").Replace("-", "_");
            context.AppendLine($"    public static string {validFieldName} = \"{layer}\";");
        }
        context.AppendLine("}");

        // 디렉토리 확인 및 생성
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // 파일 쓰기
        File.WriteAllText(filePath, context.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"{nameof(TagGenerator)}.cs has been generated at {filePath}");
    }
}