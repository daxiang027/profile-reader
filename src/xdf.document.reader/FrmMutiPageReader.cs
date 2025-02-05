using Sdcb.PaddleOCR.Models.Local;
using Sdcb.PaddleOCR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR;
using System.Diagnostics;

namespace xdf.document.reader
{
    public partial class FrmMutiPageReader : Form
    {
        private Dictionary<string, Image> normalImage = new Dictionary<string, Image>();
        private Dictionary<string, Image> thumbImage = new Dictionary<string, Image>();
        private Dictionary<string, string> pageText = new Dictionary<string, string>();
        private StringBuilder documents = new StringBuilder();

        static FullOcrModel model;

        private PaddleOcrAll ocr;

        private int maxHead = 64;
        private int maxFoot = 32;

        static FrmMutiPageReader()
        {
            Debug.WriteLine("加载模型...");
            model = LocalFullModels.ChineseV3;
        }

        public FrmMutiPageReader()
        {
            InitializeComponent();
            this.lsvPages.SelectedIndexChanged += LsvPages_SelectedIndexChanged;

            var ocrConfig = PaddleDevice.Mkldnn(cacheCapacity: 32);
            ocr = new PaddleOcrAll(model, ocrConfig)
            {
                AllowRotateDetection = true,
                Enable180Classification = true,
            };
        }

        private void LsvPages_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Image img = null;
            if (this.lsvPages.SelectedItems.Count > 0)
            {
                var key = this.lsvPages.SelectedItems[0].Tag as string;
                if (this.normalImage.ContainsKey(key))
                {
                    img = this.normalImage[key];
                }
            }
            this.picMain.Image = img;
        }

        private void tlsBtnAdd_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图像文件|*.bmp;*.jpg;*.jpeg;*.png";
            ofd.Multiselect = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this.AppendImages(ofd.FileNames);
            }
        }

        private void AppendImages(string[] files)
        {
            if (files.Length + this.lsvPages.Items.Count > 12)
            {
                this.AppendLog("文档页数超出限制.");
                return;
            }
            this.lsvPages.BeginUpdate();
            foreach (string file in files)
            {
                if (!this.normalImage.ContainsKey(file.ToLower()))
                {
                    var img = Image.FromFile(file);
                    var thumb = img.GetThumbnailImage(128, 90, null, 0);
                    this.normalImage.Add(file.ToLower(), img);
                    this.thumbImage.Add(file.ToLower(), thumb);
                }
                this.imgsMain.Images.Add(this.thumbImage[file.ToLower()]);
                var index = this.imgsMain.Images.Count - 1;
                var name = Path.GetFileNameWithoutExtension(file);
                var item = new ListViewItem(name, index);
                item.Tag = file.ToLower();
                this.lsvPages.Items.Add(item);
            }
            this.lsvPages.EndUpdate();
        }

        private void tlsBtnReset_Click(object sender, EventArgs e)
        {
            this.picMain.Image = null;
            this.lsvPages.Items.Clear();
            this.DisposeImages();
            this.pageText.Clear();
            this.documents.Clear();
            this.txtResult.Clear();
        }

        private void DisposeImages()
        {
            this.imgsMain.Images.Clear();
            var images = this.normalImage.Values.ToArray();
            foreach (var image in images)
            {
                image.Dispose();
            }
            this.normalImage.Clear();
            images = this.thumbImage.Values.ToArray();
            this.thumbImage.Clear();
            foreach (var image in images)
            {
                image.Dispose();
            }
        }

        private void AppendLog(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(() =>
                    {
                        if (this.txtLogs.TextLength + msg.Length > this.txtLogs.MaxLength - 500)
                        {
                            this.txtLogs.Clear();
                        }
                        this.txtLogs.AppendText($"{DateTime.Now.ToLongTimeString()}, {msg}\r\n");
                    });
                }
                else
                {
                    if (this.txtLogs.TextLength + msg.Length > this.txtLogs.MaxLength - 500)
                    {
                        this.txtLogs.Clear();
                    }
                    this.txtLogs.AppendText($"{DateTime.Now.ToLongTimeString()}, {msg}\r\n");
                }
            }
            finally
            {
            }
        }
        private void AppendResult(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(() =>
                    {
                        if (this.txtResult.TextLength + msg.Length > this.txtResult.MaxLength - 500)
                        {
                            this.txtResult.Clear();
                        }
                        this.txtResult.AppendText($"{DateTime.Now.ToLongTimeString()}, {msg}\r\n");
                    });
                }
                else
                {
                    if (this.txtResult.TextLength + msg.Length > this.txtResult.MaxLength - 500)
                    {
                        this.txtResult.Clear();
                    }
                    this.txtResult.AppendText($"{DateTime.Now.ToLongTimeString()}, {msg}\r\n");
                }
            }
            finally
            {
            }
        }

        private void tlsBtnRead_Click(object sender, EventArgs e)
        {
            if (this.lsvPages.Items.Count == 0)
            {
                this.AppendLog("没有文档可供读取.");
                return;
            }
            this.tlsBtnRead.Enabled = false;
            List<OcrTask> ocrTasks = new List<OcrTask>();
            List<Task> tasks = new List<Task>();
            foreach (ListViewItem item in this.lsvPages.Items)
            {
                var file = item.Tag as string;
                OcrTask task = new OcrTask(this.ocr, file);
                ocrTasks.Add(task);
                tasks.Add(Task.Run(task.Start));
            }
            this.AppendLog("OCR识别任务运行中...");
            Task.Run(() =>
            {
                Task.WaitAll(tasks.ToArray());
                this.AppendLog("OCR识别完成");
                foreach (var t in ocrTasks)
                {
                    var file = t.ImageFile.ToLower();
                    this.AppendResult($"{Path.GetFileNameWithoutExtension(file)}\r\n");
                    this.AppendResult($"{t.ResultText}\r\n");
                    this.pageText[file] = t.ResultText;
                    this.documents.AppendLine(t.ResultText);
                }
                this.InvokeLLM();
            });

        }

        private async void InvokeLLM()
        {
            this.AppendLog("调用大模型提取信息...");
            try
            {
                var txt = this.documents.ToString();
                if (string.IsNullOrEmpty(txt))
                {
                    this.AppendLog("未识别到任何文本.");
                    return;
                }
                var summaryTxt = string.Empty;
                if (txt.Length < (this.maxFoot + this.maxHead) ||
                    txt.Length <= 1024)
                {
                    //this.AppendLog("内容不足或者参数错误.");
                    //return;
                    summaryTxt = txt;
                }
                else
                {
                    var headTxt = txt.Substring(0, this.maxHead);
                    var footTxt = txt.Substring(txt.Length - this.maxFoot);
                    summaryTxt = headTxt + " ... " + footTxt;
                }
                this.AppendLog("提取文书信息...");
                var resp = await InternalTools.Extract(summaryTxt);

                //var resp = InternalTools.Summarize(summaryTxt, txt, 100);
                if (string.IsNullOrEmpty(resp))
                {
                    this.AppendResult("LLM访问失败");
                }
                else
                {
                    this.AppendResult("文书信息:");
                    this.AppendResult(resp);
                }
                this.AppendLog("创建内容摘要...");
                var summary = await InternalTools.Summarize(txt);
                if (string.IsNullOrEmpty(summary))
                {
                    this.AppendResult("LLM访问失败");
                }
                else
                {
                    this.AppendResult("内容摘要:");
                    this.AppendResult(summary);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("application", $"xdf.document.reader : {ex}", EventLogEntryType.Error);
                this.AppendLog($"ERROR:{ex.Message}");
            }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    this.tlsBtnRead.Enabled = true;
                }));
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.DisposeImages();
        }

        private void tlsBtnClear_Click(object sender, EventArgs e)
        {
            this.txtLogs.Clear();
        }

        private void ctmPage_Opening(object sender, CancelEventArgs e)
        {
            bool bRecognized = this.lsvPages.SelectedItems.Count > 0;
            if (bRecognized)
            {
                var key = this.lsvPages.SelectedItems[0].Tag as string;
                bRecognized = this.pageText.ContainsKey(key);
            }
            this.tlsMnuCopyPageText.Enabled = bRecognized;
        }

        private void tlsMnuCopyPageText_Click(object sender, EventArgs e)
        {
            bool bRecognized = this.lsvPages.SelectedItems.Count > 0;
            if (bRecognized)
            {
                var key = this.lsvPages.SelectedItems[0].Tag as string;
                var txt = this.pageText[key];
                if (!string.IsNullOrEmpty(txt))
                {
                    Clipboard.SetText(txt);
                    this.AppendLog("页面文字已复制到剪切板.");
                }
            }
        }

        private void btnAboutme_Click(object sender, EventArgs e)
        {
            using var about = new AboutBox();
            about.ShowDialog();
            about.Close();
        }
    }
}
