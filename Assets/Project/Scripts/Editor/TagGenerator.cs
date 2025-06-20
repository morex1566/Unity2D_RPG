using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System.Text;

public class TagGenerator : EditorWindow
{
    /// <summary>
    /// 파일 저장 경로
    /// </summary>
    public static readonly string filePath = "Assets/Project/Scripts/Generated/Tag.cs";



    [MenuItem("Tools/Generate Tag Class")]
    public static void Generate()
    {
        // 태그 목록 가져오기
        string[] tags = InternalEditorUtility.tags;

        // C# 파일 내용 생성
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("// Auto-generated Tag class");
        sb.AppendLine("public static class Tag");
        sb.AppendLine("{");
        foreach (string tag in tags)
        {
            // 유효한 C# 식별자로 변환 (공백이나 특수문자 처리)
            string validFieldName = tag.Replace(" ", "_").Replace("-", "_");
            sb.AppendLine($"    public static string {validFieldName} = \"{tag}\";");
        }
        sb.AppendLine("}");

        // 디렉토리 확인 및 생성
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // 파일 쓰기
        File.WriteAllText(filePath, sb.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"{nameof(TagGenerator)}.cs has been generated at {filePath}");
    }
}