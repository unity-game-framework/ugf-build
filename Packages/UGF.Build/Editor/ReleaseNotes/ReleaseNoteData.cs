using System;
using System.Reflection;
using System.Text;
using UnityEditor;

namespace UGF.Build.Editor.ReleaseNotes
{
    public class ReleaseNoteData
    {
        private readonly StringBuilder m_builder = new StringBuilder();

        public void AddLine(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Value cannot be null or empty.", nameof(value));

            m_builder.AppendLine(value);
        }

        public void AddField(string name, object value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            m_builder.AppendFormat("- {0}: '{1}'.", name, value);
            m_builder.AppendLine();
        }

        public void AddSpace()
        {
            m_builder.AppendLine();
        }

        public void AddData(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties();

            AddLine(ObjectNames.NicifyVariableName(type.Name));

            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead)
                {
                    string name = property.Name;
                    object value = property.GetValue(data);

                    AddField(name, value);
                }
            }
        }

        public void Clear()
        {
            m_builder.Clear();
        }

        public string GetString()
        {
            return m_builder.ToString();
        }
    }
}
