using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System.Text;

public class TagGenerator : EditorWindow
{
    /// <summary>
    /// ���� ���� ���
    /// </summary>
    public static readonly string filePath = "Assets/Project/Scripts/Generated/Tag.cs";



    [MenuItem("Tools/Generate Tag Class")]
    public static void Generate()
    {
        // �±� ��� ��������
        string[] tags = InternalEditorUtility.tags;

        // C# ���� ���� ����
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("// Auto-generated Tag class");
        sb.AppendLine("public static class Tag");
        sb.AppendLine("{");
        foreach (string tag in tags)
        {
            // ��ȿ�� C# �ĺ��ڷ� ��ȯ (�����̳� Ư������ ó��)
            string validFieldName = tag.Replace(" ", "_").Replace("-", "_");
            sb.AppendLine($"    public static string {validFieldName} = \"{tag}\";");
        }
        sb.AppendLine("}");

        // ���丮 Ȯ�� �� ����
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // ���� ����
        File.WriteAllText(filePath, sb.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"{nameof(TagGenerator)}.cs has been generated at {filePath}");
    }
}