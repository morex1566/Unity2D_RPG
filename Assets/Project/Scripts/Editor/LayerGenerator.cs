using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System.Text;

public class LayerGenerator : EditorWindow
{
    /// <summary>
    /// ���� ���� ���
    /// </summary>
    public static readonly string filePath = "Assets/Project/Scripts/Generated/Layer.cs";



    [MenuItem("Tools/Generate Layer Class")]
    public static void Generate()
    {
        // �±� ��� ��������
        string[] layers = InternalEditorUtility.layers;

        // C# ���� ���� ����
        StringBuilder context = new StringBuilder();
        context.AppendLine("// Auto-generated Layer class");
        context.AppendLine("public static class Layer");
        context.AppendLine("{");
        foreach (string layer in layers)
        {
            // ��ȿ�� C# �ĺ��ڷ� ��ȯ (�����̳� Ư������ ó��)
            string validFieldName = layer.Replace(" ", "_").Replace("-", "_");
            context.AppendLine($"    public static string {validFieldName} = \"{layer}\";");
        }
        context.AppendLine("}");

        // ���丮 Ȯ�� �� ����
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // ���� ����
        File.WriteAllText(filePath, context.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"{nameof(TagGenerator)}.cs has been generated at {filePath}");
    }
}