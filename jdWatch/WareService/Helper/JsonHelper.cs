using System;
using System.Collections.Generic;
using System.Text;
using AjaxPro;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace WareDealer.Helper
{
    /// <summary>
    /// JSON����
    /// </summary>
    [DisplayName("JSON����")]
    public static  class JsonHelper
    {
        #region ��ȡJson�ļ�����������

        /// <summary>
        /// ��ȡJson�ļ�����������
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="filePath">Json�ļ�·��</param>
        /// <returns>����</returns>
        public static T LoadJson<T>(string filePath)
        {
            return (T)LoadJson(filePath, typeof(T));
        }
               
        /// <summary>
        /// ��ȡJson�ļ�����������
        /// </summary>
        /// <param name="filePath">Json�ļ�·��</param>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        public static object LoadJson(string filePath, Type type)
        {
            if (System.IO.File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath, Encoding.Default);
                return FromJson(json, type);
            }
            else
            {
                return null;
            }
        }

        #endregion ��ȡJson�ļ�����������

        #region ��Json�ļ���ʽ�������

        /// <summary>
        /// ��Json�ļ���ʽ�������
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="filePath">Json�ļ�</param>
        /// <param name="obj">����</param>
        public static void SaveJson<T>(string filePath, T obj)
        {
            SaveJson(filePath, obj, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <param name="isFormat"></param>
        public static void SaveJson<T>(string filePath, T obj, bool isFormat)
        {
            string json = ToJson<T>(obj, isFormat);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

       
        /// <summary>
        /// ��Json�ļ���ʽ�������
        /// </summary>
        /// <param name="filePath">Json�ļ�·��</param>
        /// <param name="obj">����</param>
        /// <param name="type">��������</param>
        public static void SaveJson(string filePath, object obj, Type type)
        {
            string json = ToJson(obj, type);
            File.WriteAllText(filePath, json,Encoding.UTF8);
        }

        #endregion ��Json�ļ���ʽ�������

        /// <summary>
        /// �� JSON �ı�ת��Ϊ JavaScript ����
        /// </summary>
        /// <param name="json">JSON �ı�</param>
        /// <returns>JavaScript ����</returns>
        public static JavaScriptObject ToJavaScriptObj(string json)
        {
            return FromJson<JavaScriptObject>(json);
        }

        /// <summary>
        /// ������ת��Ϊ JavaScript ����
        /// </summary>
        /// <typeparam name="T">ԭʼ��������</typeparam>
        /// <param name="obj">ԭʼ����</param>
        /// <returns>Ŀ�����</returns>
        public static IJavaScriptObject ToJavaScriptObj<T>(T obj)
        {
            return ToJavaScriptObj(obj, typeof(T));
        }

        /// <summary>
        /// ������ת��Ϊ JavaScript ����
        /// </summary>
        /// <param name="obj">ԭʼ����</param>
        /// <param name="type">ԭʼ��������</param>
        /// <returns>Ŀ�����</returns>
        public static IJavaScriptObject ToJavaScriptObj(object obj, Type type)
        {
            try
            {
                return FromJson<IJavaScriptObject>(ToJson(obj, type));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ������ת��Ϊ JSON �ı�
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns>JSON �ı�</returns>
        public static string ToJson<T>(T obj)
        {
            return ToJson(obj, typeof(T));
        }

        /// <summary>
        /// ������ת��Ϊ JSON �ı�
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="type">����</param>
        /// <returns>JSON �ı�</returns>
        public static string ToJson(object obj, Type type)
        {
            return JavaScriptSerializer.Serialize(obj);
        }

        /// <summary>
        /// ������ת��Ϊ JSON �ı�
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="obj">����</param>
        /// <param name="isFormat">�Ƿ��ʽ��</param>
        /// <returns>JSON �ı�</returns>
        public static string ToJson<T>(T obj, bool isFormat)
        {
            return ToJson(obj, isFormat, typeof(T));
        }
        //xc ��� 2013-7-1 11:37:20 �÷���Ϊ�Ϸ�������ʱ����
        private static string oldFormatJson(string s)
        {
            int dip = 0;
            string s2 = "";
            string t = "";
            bool isInString = false;//sha
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '"')
                {
                    if (i == 0 || s[i - 1] != '\\')
                    {
                        if (isInString == true)
                        {
                            isInString = false;
                        }
                        else
                        {
                            isInString = true;
                        }
                    }
                }
                if (isInString)
                {
                    s2 = s2 + c;
                    continue;
                }
                if (c == '{')
                {
                    s2 = s2 + "\r\n" + t + "{\r\n";

                    dip++;
                    t = "";
                    for (int j = 0; j < dip; j++)
                    {
                        t = t + "\t";
                    }

                    s2 = s2 + t;
                }
                else if (c == '}')
                {
                    dip--;
                    t = "";
                    for (int j = 0; j < dip; j++)
                    {
                        t = t + "\t";
                    }


                    s2 = s2 + "\r\n" + t + "}\r\n";



                    s2 = s2 + t;
                }
                else if (c == '[')
                {
                    s2 = s2 + "\r\n" + t + "[\r\n";

                    dip++;
                    t = "";
                    for (int j = 0; j < dip; j++)
                    {
                        t = t + "\t";
                    }

                    s2 = s2 + t;
                }
                else if (c == ']')
                {

                    dip--;
                    t = "";
                    for (int j = 0; j < dip; j++)
                    {
                        t = t + "\t";
                    }

                    s2 = s2 + "\r\n" + t + "]\r\n";

                    s2 = s2 + t;
                }
                else if (c == ',')
                {
                    s2 = s2 + ",\r\n" + t;
                }
                else
                {
                    s2 = s2 + c;
                }


            }
            return s2;
        }
        //xc ��� 2013-7-1 11:37:32
        private static string FormatJson(string json)
        {
            StringBuilder sb = new StringBuilder();
            int sj = 0;//�����Ʊ������
            bool outOfQuotes = true; //�Ƿ���json�ַ�
            char prevChar = ' ';//��һ���ַ�
            foreach (char item in json)
            {
                if (item == '\"' && prevChar != '\\')
                {
                    outOfQuotes = !outOfQuotes;
                }
                else if ((item == ']' || item == '}') && outOfQuotes)
                {
                    sb.Append("\r\n");
                    sj--;
                    for (int i = 0; i < sj; i++)
                    {
                        sb.Append("\t");
                    }
                }
                sb.Append(item);
                if ((item == ',' || item == '[' || item == '{') && outOfQuotes)
                {
                    sb.Append("\r\n");
                    if (item != ',')
                    {
                        sj++;
                    }
                    for (int i = 0; i < sj; i++)
                    {
                        sb.Append("\t");
                    }
                }
                prevChar = item;
            }
            return sb.ToString();
        }
        /// <summary>
        /// ������ת��Ϊ JSON �ı�
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="isFormat">�Ƿ��ʽ��</param>
        /// <param name="type">����</param>
        /// <returns></returns>
        public static string ToJson(object obj, bool isFormat, Type type)
        {
            string s = ToJson(obj, type);
            if (isFormat)
            {
                //xc �޸� 2013-7-1 9:55:57
                return FormatJson(s);
            }
            return s;
        }

        /// <summary>
        /// �� JSON �ı�ת��Ϊ ָ�����͵Ķ���
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <param name="json">JSON �ı�</param>
        /// <returns>����</returns>
        public static T FromJson<T>(string json)
        {
            return JavaScriptDeserializer.DeserializeFromJson<T>(json);
        }

        /// <summary>
        /// �� JSON �ı�ת��Ϊ ָ�����͵Ķ���
        /// </summary>
        /// <param name="json">JSON �ı�</param>
        /// <param name="type">ָ������</param>
        /// <returns>����</returns>
        public static object FromJson(string json, Type type)
        {
            return JavaScriptDeserializer.DeserializeFromJson(json, type);
        }

        //public T Deserialize<T>(string json)
        //{
        //    T obj = Activator.CreateInstance<T>();
        //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        //    {
        //        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        //        return (T)serializer.ReadObject(ms);
        //    }
        //}
        /// <summary>
        /// �������ݿ����ѯ���ı��Json�ַ�ת����datatable
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static System.Data.DataTable Json2DataTable(string json)
        {
            try
            {
                AjaxPro.JavaScriptArray arrayS =
                AjaxPro.JavaScriptDeserializer.DeserializeFromJson<AjaxPro.JavaScriptArray>(json);
                System.Data.DataTable dt = new System.Data.DataTable();
                bool isInitDt = false;
                foreach (JavaScriptObject item in arrayS)
                {
                    if (!isInitDt)
                    {
                        foreach (string key in item.Keys)
                        {
                            System.Data.DataColumn fNameColumn = new System.Data.DataColumn();
                            fNameColumn.DataType = System.Type.GetType("System.String");
                            fNameColumn.ColumnName = key;
                            fNameColumn.DefaultValue = "";
                            dt.Columns.Add(fNameColumn);
                        }
                        isInitDt = true;
                    }
                    System.Data.DataRow dr = dt.NewRow();
                    foreach (string key in item.Keys)
                    {
                        //dr[key] = item[key].Value;
                        dr[key] = item[key].Value.Trim('\"');
                    }
                    dt.Rows.Add(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static string DataTable2Json(System.Data.DataTable dt)
        {
            JavaScriptArray jsa = new JavaScriptArray();
            foreach (System.Data.DataRow item in dt.Rows)
            {
                JavaScriptObject jso = new JavaScriptObject();
                foreach (System.Data.DataColumn dc in dt.Columns)
                {
                    JavaScriptString jss = new JavaScriptString(item[dc.ColumnName].ToString().Trim('\"'));
                    jso.Add(dc.ColumnName, jss);
                }
                jsa.Add(jso);
            }
            return JavaScriptSerializer.Serialize(jsa);
        }

        #region JSON����: OrJson

        /// <summary>
        /// ��sub�е����ݸ���main�е�����
        /// </summary>
        /// <param name="strMain"></param>
        /// <param name="strSub"></param>
        /// <returns></returns>
        public static string OrJson(string strMain, string strSub)
        {
            return OrJson(strMain, strSub, false);
        }

        /// <summary>
        /// ��sub�е����ݸ���main�е�����
        /// </summary>
        /// <param name="strMain"></param>
        /// <param name="strSub"></param>
        /// <param name="isFormat"></param>
        /// <returns></returns>
        public static string OrJson(string strMain, string strSub, bool isFormat)
        {
            try
            {
                IJavaScriptObject jsMain = FromJson<IJavaScriptObject>(strMain);
                IJavaScriptObject jsSub = FromJson<IJavaScriptObject>(strSub);

                if (jsSub == null || !(jsSub is JavaScriptObject || jsSub is JavaScriptArray))
                {
                    throw new Exception("�����ַ�����JSON���ǲ�����Sub������JSON����");
                }


                IJavaScriptObject jsNew = OrJson(jsMain, jsSub);

                return ToJson<IJavaScriptObject>(jsNew, isFormat);
            }
            catch (Exception ex)
            {
                //return strMain;
                throw new Exception("�������ݴ���", ex);
            }
        }

        /// <summary>
        /// ��sub�е����ݸ���main�е�����
        /// </summary>
        /// <param name="jsMain"></param>
        /// <param name="jsSub"></param>
        /// <returns></returns>
        public static IJavaScriptObject OrJson(IJavaScriptObject jsMain, IJavaScriptObject jsSub)
        {
            if (jsSub == null)  //jsSubΪNULL
            {
                //ֱ�Ӹ������
                return null;
            }
            else if (
                jsSub is JavaScriptNumber   //jsSubΪ��������
                || jsSub is JavaScriptBoolean   //jsSubΪ��������
                || jsSub is JavaScriptString    //jsSubΪ�ı�����
                )
            {
                //������������ֱ�Ӹ������
                return jsSub;
            }
            else if (jsSub is JavaScriptArray)  //jsSubΪ��������
            {

                JavaScriptArray jsNew = new JavaScriptArray();

                if (jsMain is JavaScriptArray)
                {
                    JavaScriptArray jaSub = jsSub as JavaScriptArray;
                    JavaScriptArray jaMain = jsMain as JavaScriptArray;

                    for (int i = 0; i < jaSub.Count; i++)
                    {
                        IJavaScriptObject q;
                        if (i < jaMain.Count && jaMain[i] != null && jaSub[i] != null && jaMain[i].GetType() == jaSub[i].GetType())
                        {
                            q = OrJson(jaMain[i], jaSub[i]);
                        }
                        else
                        {
                            q = jaSub[i];
                        }

                        jsNew.Add(q);
                    }

                    if (jaMain.Count > jaSub.Count)
                    {
                        for (int j = jaSub.Count; j < jaMain.Count; j++)
                        {
                            jsNew.Add(jaMain[j]);
                        }
                    }
                }
                else
                {
                    JavaScriptArray jaSub = jsSub as JavaScriptArray;
                    for (int i = 0; i < jaSub.Count; i++)
                    {
                        jsNew.Add(jaSub[i]);
                    }
                }
                return jsNew;
            }
            else if (jsSub is JavaScriptObject) //jsSubΪ��������
            {
                JavaScriptObject jsNew = new JavaScriptObject();

                if (jsMain is JavaScriptObject)
                {
                    JavaScriptObject joSub = jsSub as JavaScriptObject;
                    JavaScriptObject joMain = jsMain as JavaScriptObject;

                    foreach (string k in joSub.Keys)
                    {
                        if (joMain.Contains(k) && joSub[k] != null && joMain[k] != null && joSub[k].GetType() == joMain[k].GetType())
                        {
                            IJavaScriptObject q = OrJson(joMain[k], joSub[k]);
                            jsNew.Add(k, q);
                        }
                        else
                        {
                            jsNew.Add(k, joSub[k]);
                        }
                    }

                    foreach (string k in joMain.Keys)
                    {
                        if (!jsNew.Contains(k))
                        {
                            jsNew.Add(k, joMain[k]);
                        }
                    }
                }
                else
                {
                    JavaScriptObject joSub = jsSub as JavaScriptObject;
                    foreach (string k in joSub.Keys)
                    {
                        jsNew.Add(k, joSub[k]);
                    }

                }
                return jsNew;
            }
            else
            {
                //δ֪��jsSub����,���޸�jsMain
                return jsMain;
            }
        }

        #endregion JSON����

    }
}
