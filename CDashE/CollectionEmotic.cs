using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Windows.Controls;

namespace CDashE
{
    public static class CollectionEmotic
    {
        static string Text;
        static string FinallyText;
        static Dictionary<string, string> Emotic;
        static void InitializeEmotic()//сделать конфиг для смайликов
        {
            var E = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Emotic.txt");
            string T = sr.ReadToEnd();
            sr.Close();
            string[] buff = T.Split(';');
            for (int i = 0; i < buff.Length; i++)
            {
                string tex = buff[i];
                for (int l = 0; l < tex.Length; l++)
                {
                    if (tex[l] == '|')
                        E.Add(tex.Remove(l), tex.Remove(0, l+1));
                }
            }
            Emotic = E;
        }
        public static string ReturnEmotic(TextBox text)//ну нас будет один метод статичный в который и послыаеться тексбокс в статичный класс
        {
            Text = text.Text;
            InitializeEmotic();
            ReturnFormatText();
            return SearchEmotic();
        }
        //<---этот метод будет переводить мои смайлики
        static string SearchEmotic()
        {
            int i = 0;
            FinallyText = null;
            while (i != Text.Length)
            {
                string One = Text[i].ToString();
                string Double;
                if (Text.Length > i + 1)
                    Double = Text[i].ToString() + Text[i + 1].ToString();
                else
                    Double = One;

                foreach (var e in Emotic)
                {
                    string Key = e.Key.ToString();
                    string Value = e.Value.ToString();
                    if (One == Key || Double == Key)
                    {
                        FinallyText += Value;
                        break;
                    }
                    else if (One == Value || Double == Value)
                    { 
                        FinallyText += Key;
                        break;
                    }
                }
                i++;
            }
            return FinallyText;
        }
        static void ReturnFormatText()//<--этот метод очищает метод от какашки и оставляет только смайлики
        {
            int length = Emotic.Count;
            for (int i = 0;i < Text.Length; i++)
            {
                int error = 0;
                foreach (var e in Emotic)
                {
                    string str = Text[i].ToString();
                    string Key = e.Key.ToString();
                    string Value = e.Value.ToString();
                    if (str != Key)
                    {
                        if (str != Value)
                        {
                            if (i + 1 < Text.Length)
                                str = Text[i].ToString() + Text[i + 1].ToString();
                            if (str != Key)
                            {
                                if (str != Value)
                                    error++;
                                else { i++; break; }
                            }
                            else{ i++; break; }
                        }
                        else break;
                    }
                    else break;
                }
                if (error >= length)
                {
                    Text = Text.Remove(i,1);
                    i--;
                }
            }
        }
    }
}
