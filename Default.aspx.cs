using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows;

public partial class _Default : System.Web.UI.Page
{
    public string url = "http://apis.baidu.com/apistore/mobilenumber/mobilenumber";
    public string address = @"D:/phone.txt";
    public  List<phonenumber> result2 = new List<phonenumber>();
         
    public struct retData
    {
        public string phone { get; set; }
        public string prefix { get; set; }
        public string supplier { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string suit { get; set; }
    }//号码信息结构体

    public struct phonenumber
    {
     
        public string errNum { get; set; }
        public string retMsg { get; set; }
        public retData retData;

    }//请求回传表头结构体
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] arg = readText(address);//读取文本中所有号码存入数组中
       // string result = request(url, param);//将号码传给接口获得回传数据
        List<string> result = new List<string>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        foreach (string a in arg)
        {
            string result3 ;
            result3= request(url, "phone=" + a);
            phonenumber list = js.Deserialize<phonenumber>(result3);//Json数据序列化
            if (list.errNum == "0")
            {
                result2.Add(list);
            }
            else
            {
                Response.Write("号码"+a+"不合法");
            }
        }
        
       

       string phone = result2[0].retData.phone;
       string prefix = result2[0].retData.prefix;
       string supplier = result2[0].retData.supplier;
       string province = result2[0].retData.province;
       string city = result2[0].retData.city;
       string suit = result2[0].retData.suit;//构造结构体

      //this.TextBox1.Text = phone;
      //this.TextBox2.Text = prefix;
      //this.TextBox3.Text = supplier;
      //this.TextBox4.Text = province;
      //this.TextBox5.Text = city;
      //this.TextBox6.Text = suit;//传给前端
   

    }
    /// <summary>
    /// 发送HTTP请求（百度给的请求数据的方法）
    /// </summary>
    /// <param name="url">请求的URL</param>
    /// <param name="param">请求的参数</param>
    /// <returns>请求结果</returns>
    public static string request(string url, string param)
    {
        string strURL = url + '?'+param;
        System.Net.HttpWebRequest request;
        request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
        request.Method = "GET";
        // 添加header
        request.Headers.Add("apikey", "6c92d43d046bdd888b7588821cd5ccdd");
        System.Net.HttpWebResponse response;
        response = (System.Net.HttpWebResponse)request.GetResponse();
        System.IO.Stream s;
        s = response.GetResponseStream();
        string StrDate = "";
        string strValue = "";
        StreamReader Reader = new StreamReader(s,System.Text.Encoding.UTF8);
        while ((StrDate = Reader.ReadLine()) != null)
        {
            strValue += StrDate + "\r\n";
        }
        return strValue;
    }

    /// <summary>
    /// 读取文本中的每一行数据并存入数组中
    /// </summary>
    /// <param name="path">号码txt路径</param>
    /// <returns>号码集合的数据</returns>
    static string[] readText(string path)
    {
         
        List<string> list = new List<string>();
        using (TextReader reader = File.OpenText(path))
        {
            
            string s = reader.ReadToEnd().Trim();
            string[] a = s.Split(',');
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Replace("\r\n",null);
                list.Add(a[i]);
            }
            //if (s!=null)
            //{
            //    list.Add(s.ToString());
            //    s = reader.ReadLine();
            //}
        }
        //转换结果
        //string[]result = list.ToArray();
        //return result;
        return list.ToArray();

       
    }

  


    
}