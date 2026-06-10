using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using Unity.Hierarchy;
using UnityEditor;
using UnityEngine;

public class EnumDatabaseEditor : Editor
{
    private static readonly (IList list, FieldInfo fieldEnum, Array valueEnum) Empty = (null, null, null);

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space(10);
        if (GUILayout.Button("Update from Enum"))
        {
            AutoGenerateFromEnum();
        }

    }
    private void AutoGenerateFromEnum()
    {
        var valuesOfFields = GetValuesOfFields(target);
       
        if (valuesOfFields.list == null || valuesOfFields.valueEnum == null)
        {
            return;
        }

        CheckAndGenerateEnums(valuesOfFields.list, valuesOfFields.fieldEnum, valuesOfFields.valueEnum);
    }

    private (IList list, FieldInfo fieldEnum, Array valueEnum) GetValuesOfFields(object targetDatabase)
    {
        //Take all the public Fields on the DataBase Script and search for the first one that fulfill the condition
        //In this case the first variable that is generic (list, dictionary, etc) and is a List
        var listField = targetDatabase.GetType().GetFields()
            .FirstOrDefault(f => f.FieldType.IsGenericType && f.FieldType.GetGenericTypeDefinition() == typeof(List<>));
        if (listField == null)
        {
            Debug.LogError("No list was found in the database.");
            return Empty;
        }
        //Obtein the true List and the Type of the List, listField is only a class with info about the List (Name, type, if is public, etc) not the values of the list
        var list = (IList)listField.GetValue(targetDatabase);

        if (list == null)
        {
            list = (IList)Activator.CreateInstance(listField.FieldType);
            listField.SetValue(targetDatabase, list);
        }

        var typeEntry = listField.FieldType.GetGenericArguments()[0];

        //Take all the public Fields on the Entry Script and search for the first one that fulfill the condition
        //In this case the first variable that is and Enum
        var fieldEnum = typeEntry.GetFields()
            .FirstOrDefault(f => f.FieldType.IsEnum);
        if (fieldEnum == null)
        {
            Debug.LogError("No enum was found in the database");
            return Empty;
        }
        var typeEnum = fieldEnum.FieldType;
        var valueEnum = Enum.GetValues(typeEnum);

        return (list, fieldEnum, valueEnum);
    }

    private void CheckAndGenerateEnums(IList list, FieldInfo fieldEnum, Array valueEnum)
    {
        int newEntryCount = 0;

        foreach (var value in valueEnum)
        {
            bool exist = false;
            foreach (var entry in list)
            {
                var valueEntry = fieldEnum.GetValue(entry);
                if (valueEntry.Equals(value))
                {
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                var newEntry = Activator.CreateInstance(fieldEnum.DeclaringType);
                fieldEnum.SetValue(newEntry, value);
                list.Add(newEntry);
                newEntryCount++;
            }
        }

        EditorUtility.SetDirty(target);
        Debug.Log($"Data Base Updated. Added: {newEntryCount} entries");
    }
}
