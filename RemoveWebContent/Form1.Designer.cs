using CefSharp;
using CefSharp.WinForms;
using System;

namespace RemoveWebContent
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            ChromiumWebBrowser cwb = new ChromiumWebBrowser("https://act.hoyoverse.com/ys/event/e20221008nilou/index.html?game_biz=hk4e_global&mhy_presentation_style=fullscreen&mhy_landscape=true&mhy_auth_required=true&mhy_hide_status_bar=true&utm_source=share&utm_medium=hoyolab&utm_campaign=app&lang=fr-fr");
            Controls.Add(cwb);
            cwb.RequestHandler = new CustomRequestHandler();
            bool b = false;
            cwb.LoadingStateChanged += (s, e) =>
            {
                if (!e.IsLoading && !b)
                {
                    BeginInvoke(new Action(() =>
                    {
                        cwb.ShowDevTools();
                        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    }));
                    b = true;
                }
            };
        }

        #endregion
    }
}

