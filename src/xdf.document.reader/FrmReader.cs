using OpenCvSharp;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR;
using Sdcb.PaddleOCR.Models.Local;
using Sdcb.PaddleOCR.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace xdf.document.reader
{
    public partial class FrmReader : Form
    {
        private string aiUrl = "http://localhost:11434/api/generate";

        static FullOcrModel model = LocalFullModels.ChineseV3;
        private string imagePath;
        private PaddleOcrResult ocrResult;
        private PaddleOcrAll ocr;
        Font font = new Font("宋体", 24);
        public FrmReader()
        {
            InitializeComponent();
            //var ocrConfig = PaddleDevice.Gpu(initialMemoryMB:1024);
            var ocrConfig = PaddleDevice.Mkldnn(cacheCapacity: 32);
            ocr = new PaddleOcrAll(model, ocrConfig)
            {
                AllowRotateDetection = true,
                Enable180Classification = true,
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var oau = ConfigurationManager.AppSettings["openAIUrl"].TrimEnd('/');
            aiUrl = $"{oau}/api/generate";
        }

        private void tlsBtnOpen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files | *.jpg;*.png;*.bmp;*.tiff";
            ofd.Multiselect = false;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this.txtResult.Text = string.Empty;
                this.tlsBtnCopy.Enabled = false;
                imagePath = ofd.FileName;
                this.ocrResult = null;
                this.picInput.Image = Image.FromFile(imagePath);
                //this.picInput.Size = this.picInput.Image.Size;
                FrmWait.ShowMe(this);
                Thread.Sleep(500);
                Task.Run(new Action(Recognize));
            }
        }
        private void AppendLog(string msg)
        {
            this.Invoke(() => 
            {
                this.txtResult.AppendText($"{msg}\r\n");
            });
        }
        private void Recognize()
        {
            FrmWait.ShowMessage("文书识别进行中, 请稍等 ......");
            var sTime = DateTime.Now;
            
            AppendLog($"#{DateTime.Now.ToLongTimeString()}, 开始识别图像: {Path.GetFileName(imagePath)} ... ");
            var fData = File.ReadAllBytes(imagePath);
            Mat src = Cv2.ImDecode(fData, ImreadModes.Grayscale);
            ocrResult = ocr.Run(src);
            var tsDuration = (DateTime.Now - sTime).ToString(@"mm\:ss\.fff");
            AppendLog($"#识别图像: {Path.GetFileName(imagePath)} 完成, Duration: {tsDuration}");

            if (ocrResult == null)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(this, "OCR组件返回null引用");
                }));
                return;
            }
            this.Summarize();
        }

        private string PrettyJson(string json)
        {
            var obj = JObject.Parse(json);
            var result = obj.ToString();
            var jsonFile = Path.Combine(
                Path.GetDirectoryName(imagePath),
                $"{Path.GetFileNameWithoutExtension(imagePath)}.json");
            File.WriteAllText(jsonFile, result,Encoding.UTF8 );
            return result;
        }

        private void Summarize()
        {
            FrmWait.ShowMessage("文书解读进行中, 请稍等 ......");
            var jPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "prompt.json");
            var json = File.ReadAllText(jPath,System.Text.Encoding.UTF8);
            json = json.Replace("&text", ocrResult.Text.Replace("\n",""));
            var data = Encoding.UTF8.GetBytes(json);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(aiUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                using var input = request.GetRequestStream();
                input.Write(data, 0, data.Length);
                var resp = request.GetResponse() as HttpWebResponse;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    using var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    var respJson = sr.ReadToEnd();
                    var respObj = JObject.Parse(respJson);
                    var respText = respObj["response"].ToString();
                    respText = respText.Substring(8).Replace("```", "");

                    this.Invoke(new Action(() =>
                    {
                        this.AppendLog(PrettyJson(respText));
                        this.tlsBtnCopy.Enabled = true;
                        FrmWait.CloseMe();
                    }));
                }
                else
                {
                    throw new Exception(resp.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    this.txtResult.Text = ex.ToString();
                    this.tlsBtnCopy.Enabled = true;
                }));
                //Console.WriteLine(ex.ToString());
            }

        }
    }
}
