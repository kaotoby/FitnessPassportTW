using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutoSign_fitness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.tryico.Visible = true;
            }
        }

        const string LOGIN_URL = "http://passport.fitness.org.tw/nlogin.aspx";
        const string LOGOUT_URL = "http://passport.fitness.org.tw/loginout.aspx";
        const string AJAX_URL = "http://passport.fitness.org.tw/master.passport.ashx";
        CookieContainer Coa;
        public delegate void EventHandler();
        public event EventHandler PostErrorEvent;

        public string Curnum { get; set; }
        public string Curid { get; set; }
        public string Curpass { get; set; }
        public Thread MainThread { get; set; }
        public string LastUrl { get; set; }
        public string Lasthtml { get; set; }
        private int LoginTimesCounter { get; set; }

        public bool Inprocess { get; set; }
        public void OnPostErrorEvent()
        {
            if (PostErrorEvent != null)
                PostErrorEvent();
        }

        public void PostError_Event()
        {
            AddLog("POST error, retry in 2sec");
            Thread.Sleep(2000);
            if (LastUrl == LOGIN_URL)
            {
                Login(Curnum, Curid, Curpass);
            }
            else if (LastUrl == LOGOUT_URL)
            {
                Logout();
            }
            else
            {
                GetUserInfo(Lasthtml);
            }
        }


        public delegate void StrDel(string str);
        public void AddLog(string str)
        {
            if (logtbx.InvokeRequired)
                logtbx.BeginInvoke(new StrDel(AddLog), new object[1] { str });
            else
            {
                logtbx.AppendText(System.DateTime.Now.ToString() + ": " + str + "\r\n");
                System.IO.File.AppendAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + "log.log", System.DateTime.Now.ToString() + ": " + str + "\r\n", Encoding.UTF8);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + "data.csv"))
            {
                MessageBox.Show("can not find the data.csv!");
                Environment.Exit(0);
            }
            Inprocess = false;
            Coa = new CookieContainer();
            PostErrorEvent += new EventHandler(PostError_Event);
            tryico.Text = this.Text;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //AddLog("ontimer");
            if (!Inprocess)
            {
                if (DateTime.Now.Hour == htbx.Value && DateTime.Now.Minute == mtbx.Value)
                {
                    AddLog("Time Trigered");
                    MainThread = new Thread(MainFunc);
                    MainThread.Start();
                }
            }
        }



        private void MainFunc()
        {
            Inprocess = true;
            StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\data.csv", Encoding.Default);
            string s;
            LoginTimesCounter = 0;

            while ((s = sr.ReadLine()) != null)
            {
                if (s == "")
                    continue;
                string num = s.Split(',')[0];
                string id = s.Split(',')[1];
                string pass = s.Split(',')[2];
                Login(num, id, pass);
                //AddLog("after login sleep 5 times");
                Thread.Sleep(2000);
                Logout();
                AddLog("logout");
                //AddLog("after logout sleep 5 times");
                Thread.Sleep(2000);
            }
            sr.Close();
            Inprocess = false;
            AddLog("<" + LoginTimesCounter + " users> login sucessfully!");
        }


        private string GetUserInfo(string str)
        {
            Regex reg1 = new Regex(@"id=""checksn"" value=""\d*\""");
            Regex reg2 = new Regex(@"id=""checkmd5"" value=""[\W\w]*\""");
            Regex reg3 = new Regex(@"id=""checktime"" value=""\d*\""");
            Regex reg4 = new Regex(@"""LoginTimes"":""\d*""");

            string sn = "", md5 = "", time = "", logintimes = "";

            if (reg1.IsMatch(str))
            {
                sn = reg1.Match(str).Value.Split('"')[3];
            }

            if (reg2.IsMatch(str))
            {
                md5 = reg2.Match(str).Value.Split('"')[3];
            }

            if (reg3.IsMatch(str))
            {
                time = reg3.Match(str).Value.Split('"')[3];
            }

            if (sn != "" && md5 != "" && time != "")
            {
                Dictionary<string, string> postDict = new Dictionary<string, string>();
                postDict.Add("checksn", sn);
                postDict.Add("checkmd5", md5);
                postDict.Add("checktime", time);
                postDict.Add("checktarget", "");
                string html = "";
                CTRHttp(AJAX_URL, postDict, true, ref html);
                if (reg4.IsMatch(html))
                {
                    logintimes = reg4.Match(html).Value.Split('"')[3];
                    return logintimes;
                }
                else
                    return null;
            }
            else
                return null;

        }

        private void Login(string num, string id, string pass)
        {
            Curnum = num;
            Curid = id;
            Curpass = pass;

            Random rx = new Random();
            int xi = rx.Next(10, 30);
            Random ry = new Random();
            int yi = ry.Next(10, 30);

            Dictionary<string, string> postDict = new Dictionary<string, string>();
            postDict.Add("__EVENTVALIDATION", "/wEWBALvg+ixDAKspt6oDgLCu4iJCgKct7iSDGVTuTw5byt59/eKwKpXwmtFCzoa");
            postDict.Add("__VIEWSTATE", "/wEPDwUKLTY4NzcyMTIyMg9kFgICAQ9kFgICBQ8PFgIeDU9uQ2xpZW50Q2xpY2sFDmxvYWRpbmdMb2NrKCk7ZGQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgEFB2J0blNhdmXXaIrDX3r8dIuhicIpnDBZkr2I9g==");
            //postDict.Add("btnSave.x", "29");
            //postDict.Add("btnSave.y", "18");
            postDict.Add("btnSave.x", xi.ToString());
            postDict.Add("btnSave.y", yi.ToString());
            postDict.Add("txtST_PID", id);
            postDict.Add("txtST_SITNO", pass);
            string html = "";

            CTRHttp(LOGIN_URL, postDict, true, ref html);

            //html = System.Web.HttpUtility.HtmlDecode(html);

            if (html.IndexOf("上次登入時間") != -1)
            {
                //AddLog("[no." + num + "] login ok!");
                LoginTimesCounter++;
                string logintimes = GetUserInfo(html);
                if (logintimes != null)
                {
                    AddLog("[no." + num + "] login ok <" + logintimes + " times>");
                }
                else
                    AddLog("[no." + num + "](" + id.Remove(7).Insert(7,"***") + ") login ok <get logintimes faild!>");
            }
            else
            {
                Regex r1 = new Regex(@"alert\([\w\W]*\)");
                if (r1.IsMatch(html))
                {
                    AddLog("[no." + num + "](" + id + ") login faild!=>" + r1.Match(html).Value.Replace("alert", null));
                }
                else
                    AddLog("id:[" + id + "]login faild!=>unknown error");
            }

        }

        private void Logout()
        {
            string ts = "";
            CTRHttp(LOGOUT_URL, null, false, ref ts);
        }

        public string quoteParas(Dictionary<string, string> paras)
        {
            string quotedParas = "";
            bool isFirst = true;
            string val = "";
            foreach (string para in paras.Keys)
            {
                if (paras.TryGetValue(para, out val))
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        //quotedParas += para + "=" + HttpUtility.UrlPathEncode(val);
                        quotedParas += para + "=" + System.Web.HttpUtility.UrlEncode(val);

                    }
                    else
                        quotedParas += "&" + para + "=" + HttpUtility.UrlPathEncode(val);
                }
                else
                    break;
            }

            return quotedParas;
        }

        public void CTRHttp(string url, Dictionary<string, string> postDict, bool GetResult, ref string result)
        {
            GC.Collect();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.AllowAutoRedirect = true;
            req.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
            req.KeepAlive = true;
            req.AllowWriteStreamBuffering = true;
            req.Credentials = System.Net.CredentialCache.DefaultCredentials;
            req.MaximumResponseHeadersLength = -1;
            req.ProtocolVersion = HttpVersion.Version10;
            req.Headers.Add("Accept-Language", "zh-tw");
            req.Headers.Add("Accept-Encoding", "gzip,deflate");
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            req.Proxy = null;
            req.Timeout = 30000;
            req.ReadWriteTimeout = 30000;
            req.CookieContainer = Coa;


            try
            {
                if (postDict != null)
                {
                    string postDataStr = "";
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    postDataStr = quoteParas(postDict);
                    byte[] postBytes = Encoding.UTF8.GetBytes(postDataStr);
                    req.ContentLength = postBytes.Length;
                    Stream postDataStream = req.GetRequestStream();
                    postDataStream.Write(postBytes, 0, postBytes.Length);
                    postDataStream.Close();
                }
                else
                {
                    req.Method = "GET";
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


                if (GetResult)
                {
                    Stream stream = resp.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                    result = System.Web.HttpUtility.HtmlDecode(sr.ReadToEnd());
                    Lasthtml = result;
                }
            }

            catch (WebException e)
            {
                LastUrl = url;
                OnPostErrorEvent();
            }

        }

        private void tryico_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.tryico.Visible = false;
        }

        private void run_btn_Click(object sender, EventArgs e)
        {
            if (!Inprocess)
            {
                AddLog("Manual started");
                MainThread = new Thread(MainFunc);
                MainThread.Start();
            }
            /*else
            {
                timer1.Enabled = false;
                timep.Enabled = true;
                MainThread.Abort();
                MainThread.Join(0);
 
            }*/
        }
    }
}
