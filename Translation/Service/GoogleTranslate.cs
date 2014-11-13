
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Translation.Service
{
    public class GoogleTranslate
    {
        private string UrlTemplate = "http://translate.google.com.hk/";                            //google翻译URL模板:POST方式请求
        private string[] Languages = { "en", "zh-CN", "fr", "ja", "ko", "ru" };
        #region 常用语言编码
        private string AutoDetectLanguage = "auto"; //google自动判断来源语系
        #endregion
        private static GoogleTranslate translate;
        private GoogleTranslate()
        { }

        public static GoogleTranslate Instance()
        {
            if (translate == null)
                translate = new GoogleTranslate();
            return translate;
        }

        /// <summary>
        /// 翻译文本[自动检测源语言类型]
        /// </summary>
        /// <param name="sourceText">源文本</param>
        /// <param name="targetLanguageCode">目标语言类型代码，0英语1汉语2法语3日语4韩语5俄语</param>
        /// <returns>翻译结果</returns>
        public string Translate(string sourceText, int targetLanguageCode)
        {
            return Translate(sourceText, AutoDetectLanguage, Languages[targetLanguageCode]);
        }

        /// <summary>
        /// 翻译文本
        /// </summary>
        /// <param name="sourceText">源文本</param>
        /// <param name="sourceLanguageCode">源语言类型代码，如：en、zh-CN、zh-TW、ru等</param>
        /// <param name="targetLanguageCode">目标语言类型代码，如：en、zh-CN、zh-TW、ru等</param>
        /// <returns>翻译结果</returns>
        private string Translate(string sourceText, string sourceLanguageCode, string targetLanguageCode)
        {
            if (string.IsNullOrEmpty(sourceText) || Regex.IsMatch(sourceText, @"^\s*$"))
            {
                return sourceText;
            }

            string strReturn = string.Empty;

            #region POST方式实现，无长度限制
            string url = UrlTemplate;

            //组织请求的数据
            string postData = string.Format("langpair={0}&text={1}", HttpUtility.UrlEncode(sourceLanguageCode + "|" + targetLanguageCode), HttpUtility.UrlEncode(sourceText));
            byte[] bytes = Encoding.UTF8.GetBytes(postData);

            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.Headers.Add("ContentLength", postData.Length.ToString());
            byte[] responseData = client.UploadData(url, "POST", bytes);
            string strResult = Encoding.UTF8.GetString(responseData);    //响应结果 
            #endregion
            #region 获取result_box中的结果
            int index = strResult.IndexOf("result_box");
            if (index > 0)
            {
                strResult = strResult.Substring(index);
                index = strResult.IndexOf("<span");
                strResult = strResult.Substring(index);
                index = strResult.IndexOf(">");
                strResult = strResult.Substring(index);
                index = strResult.IndexOf("</span>");
                strResult = strResult.Substring(1, index - 1);
            }
            #endregion
            else strResult = "";
            return strResult;
        }
    }
}
