using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading;

namespace getStickers
{
    public delegate void updateInfo(string text);
    public delegate void updateMaxPrg(int max);
    public delegate void incProgress();

    public partial class frmMain : Form
    {
        public const string BASE_URL = "http://dl.stickershop.line.naver.jp";
        WebClient wc;
        string metaStr;
        public frmMain()
        {
            InitializeComponent();
            wc = new WebClient();
            if (Properties.Settings.Default.selDir != "")
            {
                fbd.SelectedPath = Properties.Settings.Default.selDir;
                statLabel.Text = "Selected dir: " + fbd.SelectedPath;
            }

            this.Text = "Get(PNG)Stickers " + Properties.Settings.Default.programVer + " by Kurobyte";
        }

        public void downloadSticker(int sticker_id, int png_id, string dirName ) {
            try
            {
                wc.DownloadFile(BASE_URL + "/products/0/0/1/" + sticker_id + "/android/stickers/" + png_id + ".png", fbd.SelectedPath + "\\" + dirName + "\\" + png_id + ".png");
            }
            catch (WebException we)
            {
                HttpWebResponse wr = (HttpWebResponse)we.Response;
                switch (wr.StatusCode)
                {
                }
            }
        }

        private Sticker getMeta(int sticker_id) {
            Sticker stic = null;

            try
            {
                metaStr = wc.DownloadString(BASE_URL + "/products/0/0/1/" + sticker_id + "/android/productInfo.meta");
            }
            catch (WebException we)
            {
                HttpWebResponse wr = (HttpWebResponse)we.Response;
            }

            string data = Encoding.UTF8.GetString(Encoding.Default.GetBytes(metaStr));
            return stic = JsonConvert.DeserializeObject<Sticker>(data);
        }

        private void writeMeta(string dirname) {
            StreamWriter sw = new StreamWriter(fbd.SelectedPath + "\\" + dirname + "\\productInfo.meta", false, System.Text.Encoding.UTF8);
            sw.Write(metaStr);
            sw.Close();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK) { 
                statLabel.Text = "Selected dir: "+fbd.SelectedPath;
                Properties.Settings.Default.selDir = fbd.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(download);
            t.Start();
        }

        private void download() {
            Sticker meta = null;
            int sticker_id;
            prgDownload.Value = 0;

            if (int.TryParse(txtId.Text, out sticker_id))
                meta = getMeta(sticker_id);

            if (fbd.SelectedPath != null && fbd.SelectedPath != "")
            {
                if (meta != null)
                {
                    statLabel.Text = "Downloading... ";
                    string title = sticker_id + " - " + replace_all(meta.Title[meta.Title.Keys.ElementAt(0)]);
                    int nStickers = meta.Stickers.Count;
                    if (!Directory.Exists(fbd.SelectedPath + "\\" + title))
                        Directory.CreateDirectory(fbd.SelectedPath + "\\" + title);

                    //prgDownload.Maximum = nStickers;
                    this.Invoke(new updateMaxPrg(updateUImaxPrg), new object[] { nStickers });
                    //txtInfo.Invoke()
                    //txtInfo.Text = string.Format("Title: {0}\r\nStickers: {1}", title, nStickers);
                    this.Invoke(new updateInfo(updateStickerInfo), new object[] { string.Format("Title: {0}\r\nStickers: {1}", title, nStickers) });

                    foreach (Dictionary<string, string> stick in meta.Stickers)
                    {
                        downloadSticker(sticker_id, int.Parse(stick["id"]), title);
                        //prgDownload.Value += 1;
                        this.Invoke(new incProgress(updateUIincProgress));
                    }

                    writeMeta(title);
                    MessageBox.Show("Download Complete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statLabel.Text = "Downloading... Complete";
                }
                else
                    MessageBox.Show("Error trying to download. Check the ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("You need to select a folder first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string replace_all(string text) { 
            char[] nonValid =  {'<', '>', ':', '"', '\\', '/', '|', '?', '*'};

            foreach (char c in nonValid) {
                if (text.Contains(c))
                    text = text.Replace(c, ' ');
            }

            return text;
        }

        private void updateStickerInfo(string text)
        {
            txtInfo.Text = text;
        }

        private void updateUImaxPrg(int max) { prgDownload.Maximum = max; }
        private void updateUIincProgress() { prgDownload.Value += 1; }
    }
}
