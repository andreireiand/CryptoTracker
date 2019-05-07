using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace CryptoTracker
{
    public partial class Form1 : Form
    {
        
        PoloniexWS wsPol; 
        public Form1()
        {
            InitializeComponent();

            wsPol = new PoloniexWS(textBox1Channel.Text);
            wsPol.ws.OnMessage += (sender, e) => UpdatePolTextBoxes();
        }
        

        private void Button1CPol_Click(object sender, EventArgs e)
        {
            wsPol.Connect();
            button2DPol.Enabled = true;
            button1CPol.Enabled = false;
        }

        private void Button2DPol_Click(object sender, EventArgs e)
        {
            wsPol.Disconn();
            button2DPol.Enabled = false;
            button1CPol.Enabled = true;
        }

        private void Button3Update_Click(object sender, EventArgs e)
        {
            UpdatePolTextBoxes();
        }

        private void UpdatePolTextBoxes()
        {
            double price, vol;
            (price, vol) = wsPol.GetHighestBid();
            if(this.InvokeRequired) this.Invoke(new Action(() => textBox1BidPolPrice.Text = price.ToString()));
            if (this.InvokeRequired) this.Invoke(new Action(() => textBox1BidPolVol.Text = vol.ToString()));

            (price, vol) = wsPol.GetLowestAsk();
            if (this.InvokeRequired) this.Invoke(new Action(() => textBox1AskPolPrice.Text = price.ToString()));
            if (this.InvokeRequired) this.Invoke(new Action(() => textBox1AskPolVol.Text = vol.ToString()));

            if (this.InvokeRequired) this.Invoke(new Action(() => richTextBox1.AppendText(wsPol.GetSpreadInText())));
        }
    }

    public class PoloniexWS : BaseWS
    {
        string path = @"c:\temp\_Poloniex_Tokens.txt";
        static SortedDictionary<double, double> bidLadder;
        static SortedDictionary<double, double> askLadder;
        string channel;
        public PoloniexWS(string chn) : base("wss://api2.poloniex.com")
        {
            channel = "{\"command\": \"subscribe\", \"channel\": \"" + chn + "\"}";
            bidLadder = new SortedDictionary<double, double>();
            askLadder = new SortedDictionary<double, double>();
            ws.OnMessage += (sender, e) =>
            {
                //using (StreamWriter sw = File.AppendText(path)) {sw.WriteLine(e.Data);}
                UpdateLadders(e.Data);
            };
        }

        private static double highestBid = 0, lowestAsk = 0;
        public (double,double) GetHighestBid()
        {
            lock (bidLadder)
            {
                if (bidLadder.Count != 0) while (bidLadder[bidLadder.Keys.Max()] == 0) bidLadder.Remove(bidLadder.Keys.Max());
                if (bidLadder.Count != 0)
                {
                    highestBid = bidLadder.Keys.Max();
                    return (highestBid, bidLadder[highestBid]);
                }
                else
                {
                    highestBid = 0;
                    return (0, 0);
                }
            }
        }
        public (double, double) GetLowestAsk()
        {
            lock (askLadder)
            {
                if (askLadder.Count != 0) while (askLadder[askLadder.Keys.Min()] == 0) askLadder.Remove(askLadder.Keys.Min());
                if (askLadder.Count != 0)
                {
                    lowestAsk = askLadder.Keys.Min();
                    return (lowestAsk, askLadder[lowestAsk]);
                }
                else
                {
                    lowestAsk = 0;
                    return (0, 0);
                }
            }
        }
        public double GetSpread()
        {
            return lowestAsk - highestBid;
        }
        public string GetSpreadInText()
        {
            string str = "Spread: " + (lowestAsk - highestBid).ToString() + "  =  " + lowestAsk + " - " + highestBid + "\n";
            return str; 
        }
        private void UpdateLadders(string data)
        {
            (List<string> bidTokensList, List<string> askTokensList) = GetUpdateTokens(data);
            if (askTokensList.Count != 0) UpdateLadder(askTokensList, 0);
            if (bidTokensList.Count != 0) UpdateLadder(bidTokensList, 1);
        }

        private void UpdateLadder(List<string> tokensList, int v)
        {
            foreach (string token in tokensList)
            {
                //using (StreamWriter sw = File.AppendText(path)) {sw.WriteLine("v: " + v + "; "  +token);}
                UpdateLadder2(token, v == 0 ? askLadder : v == 1 ? bidLadder : throw new System.ArgumentException("UpdateLadder2: Parameter sortedDict cannot be null", "sortedDict"));
            }
        }

        private void UpdateLadder2(string token, SortedDictionary<double, double> sortedDict)
        {
            string[] tokens = token.Split(','); // indexes: 0 = "o", 1 = "0 or 1", 2 = Price, 3 = Vol/Qty
            double price = Double.Parse(tokens[2].Trim('"'));
            double volum = Double.Parse(tokens[3].Trim('"'));
            if (volum == 0 && sortedDict.ContainsKey(price))
                sortedDict.Remove(price);   // price level has no more bid/ask participant; we can delete the entry from the dict
            else
                sortedDict[price] = volum;  // update of price level
        }

        private (List<string>, List<string>) GetUpdateTokens(string data)
        {
            List<string> bidTokensList = new List<string>();
            List<string> askTokensList = new List<string>();

            string worker = data;
            while(worker != "")
            {
                string token;
                (worker, token) = GetNextToken(worker);
                token = token.Trim(new char[] { '[', ']' }).Replace(" ", string.Empty);
                if (token.Contains("\"o\",0")) // we have an ask update
                {
                    askTokensList.Add(token);
                }
                else if (token.Contains("\"o\",1")) // we have a bid update 
                {
                    bidTokensList.Add(token);
                }
            }
            return (bidTokensList, askTokensList);
        }

        private (string, string) GetNextToken(string worker)
        {
            int lastIndexOf = worker.Substring(0, worker.IndexOf(']')).LastIndexOf('[');
            string token = worker.Substring(lastIndexOf, worker.IndexOf(']') - lastIndexOf + 1);
            string leftOver = RemainingString(worker, lastIndexOf, worker.IndexOf(']') - lastIndexOf + 1);
            return (leftOver, token);
        }
        public string RemainingString(string str, int start, int length)
        {
            return Regex.Replace(str, "^(.{" + start + "})(?:.{" + length + "})(.*)$", "$1$2");
        }
        public void Connect()
        {
            ws.Connect();
            if (ws.IsAlive) ws.Send(channel);
            else throw new System.ArgumentException("PoloniexWS:Connect - conn failure!");
        }
        public void Disconn()
        {
            ws.Close();
        }
    }

    public class BaseWS
    {
        String urlStr;
        private enum SslProtocolsHack { Tls = 192, Tls11 = 768, Tls12 = 3072 }
        public WebSocket ws; 
        public BaseWS(string urlStr)
        {
            this.urlStr = urlStr;
            ws = new WebSocket(urlStr);
            ws.SslConfiguration.EnabledSslProtocols = (System.Security.Authentication.SslProtocols)(SslProtocolsHack.Tls12 | SslProtocolsHack.Tls11 | SslProtocolsHack.Tls);
        }
    }
}
