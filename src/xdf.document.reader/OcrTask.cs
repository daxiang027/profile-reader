using OpenCvSharp;
using Sdcb.PaddleOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xdf.document.reader
{
    internal class OcrTask
    {
        public event EventHandler BeginRecognize;
        public event EventHandler EndRecognize;
        public string ImageFile { get; private set; }
        public PaddleOcrResult Result { get; private set; }
        public PaddleOcrAll PaddleOcr {  get; private set; }

        public DateTime BeginTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public double TotalSeconds { get; private set; }

        public string ResultText
        {
            get
            {
                return Result == null ? string.Empty : Result.Text;
            }
        }

        public OcrTask(PaddleOcrAll ocr, string imageFile)
        {
            PaddleOcr = ocr;
            ImageFile = imageFile;
        }

        public void Start()
        {
            this.BeginTime = DateTime.Now;
            if (this.BeginRecognize != null)
            {
                this.BeginRecognize(this, new EventArgs());
            }
            var fData = File.ReadAllBytes(ImageFile);
            Mat src = Cv2.ImDecode(fData, ImreadModes.Grayscale);
            this.Result = this.PaddleOcr.Run(src);
            this.EndTime = DateTime.Now;
            this.TotalSeconds = (this.EndTime-this.BeginTime).TotalSeconds;
            if (this.EndRecognize != null)
            {
                this.EndRecognize(this, new EventArgs());
            }
        }
    }
}
