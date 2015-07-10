using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;
using System.Diagnostics;
using System.IO;

namespace SnmpTrapMonitoringApp
{
	/// <summary>
	/// SNMP通信とか色々
	/// </summary>
	public partial class FormMain : Form
	{
		private Process batProcess = new Process();
		private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		private IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 162);
		private EndPoint ep = null;
		private int inlen = -1;
		private bool startFlag = false;
		private bool proFlag = false;
		private string checkMsg = "Smooth streaming push connection lost (primary server)";
		private string statusOid = "1.3.6.1.4.1.10613.1.6.1.3.0";
		private int countTime = 295;	//約300秒（5分）

		/// <summary>
		/// インストラクタ
		/// </summary>
		public FormMain()
		{
			InitializeComponent();

			ep = (EndPoint)ipep;
			socket.Bind(ep);
			socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);

			textBoxPath1.Text = Properties.Settings.Default["PathCapture"].ToString();
			textBoxPath2.Text = Properties.Settings.Default["PathCopy"].ToString();
		}

		/// <summary>
		/// スタートボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			if (startFlag)
			{
				//LabelChange("OFF");
				
			}
			else
			{
				LabelChange("ON");
			}
		}

		/// <summary>
		/// 状態変化メソッド
		/// </summary>
		/// <param name="mode"></param>
		private void LabelChange(string mode)
		{
			if (mode == "ON")
			{
				startFlag = true;
				buttonKanshi.Visible = true;
				buttonStop.Visible = false;
				textBoxPath1.ReadOnly = true;
				textBoxPath2.ReadOnly = true;
				ReceiveSnmpTrap();
			}
			else if (mode == "OFF")
			{
				startFlag = false;
			}
		}

		/// <summary>
		/// トラップログ出力
		/// </summary>
		/// <param name="msg"></param>
		private void WriteTrapLog(string msg)
		{
			string path = System.Windows.Forms.Application.StartupPath + @"\log\traplog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
			System.IO.File.AppendAllText(path, msg + "\r\n", System.Text.Encoding.GetEncoding("shift_jis"));
		}

		/// <summary>
		/// SNMP受信タスク
		/// </summary>
		private void ReceiveSnmpTrap()
		{
			Task.Run( () =>
			{
				for (;;)
				{
					System.Threading.Thread.Sleep(1000);

					byte[] indata = new byte[16 * 1024];
					IPEndPoint peer = new IPEndPoint(IPAddress.Any, 0);
					EndPoint inep = (EndPoint)peer;

					try
					{
						inlen = socket.ReceiveFrom(indata, ref inep);
					}
					catch (Exception ex)
					{
						WriteTrapLog(string.Format("Exception {0}", ex.Message));
						inlen = -1;
					}

					if (inlen > 0)
					{
						int ver = SnmpPacket.GetProtocolVersion(indata, inlen);
						string lastvalue = "";
						string status = "";
						if (ver == (int)SnmpVersion.Ver1)
						{
							//SNMP Ver1
							SnmpV1TrapPacket pkt = new SnmpV1TrapPacket();
							pkt.decode(indata, inlen);
							WriteTrapLog(string.Format("【{0}】********************************************", DateTime.Now.ToString()));
							WriteTrapLog(string.Format("** SNMP Version 1 TRAP received from {0}:", inep.ToString()));
							WriteTrapLog(string.Format("*** Trap generic: {0}", pkt.Pdu.Generic));
							WriteTrapLog(string.Format("*** Trap specific: {0}", pkt.Pdu.Specific));
							WriteTrapLog(string.Format("*** Agent address: {0}", pkt.Pdu.AgentAddress.ToString()));
							WriteTrapLog(string.Format("*** Timestamp: {0}", pkt.Pdu.TimeStamp.ToString()));
							WriteTrapLog(string.Format("*** VarBind count: {0}", pkt.Pdu.VbList.Count));
							WriteTrapLog(string.Format("*** VarBind content:"));
							foreach (Vb v in pkt.Pdu.VbList)
							{
								WriteTrapLog(string.Format("**** {0} {1}: {2}", v.Oid.ToString(), SnmpConstants.GetTypeName(v.Value.Type), v.Value.ToString()));
								lastvalue = v.Value.ToString();

								if (v.Oid.ToString() == statusOid)
								{
									status = v.Value.ToString();
								}
							}
							WriteTrapLog(string.Format("** End of SNMP Version 1 TRAP data."));

							textBox1.Invoke(new Action(() =>
							{
								textBox1.AppendText(DateTime.Now.ToString() + "　Trap受信（" + lastvalue + "）\r\n");
							}));
						}
						else
						{
							//SNMP Ver2
							SnmpV2Packet pkt = new SnmpV2Packet();
							pkt.decode(indata, inlen);
							WriteTrapLog(string.Format("【{0}】********************************************", DateTime.Now.ToString()));
							WriteTrapLog(string.Format("** SNMP Version 2 TRAP received from {0}:", inep.ToString()));
							if ((SnmpSharpNet.PduType)pkt.Pdu.Type != PduType.V2Trap)
							{
								WriteTrapLog(string.Format("*** NOT an SNMPv2 trap ****"));
							}
							else
							{
								WriteTrapLog(string.Format("*** Community: {0}", pkt.Community.ToString()));
								WriteTrapLog(string.Format("*** VarBind count: {0}", pkt.Pdu.VbList.Count));
								WriteTrapLog("*** VarBind content:");
								foreach (Vb v in pkt.Pdu.VbList)
								{
									WriteTrapLog(string.Format("**** {0} {1}: {2}", v.Oid.ToString(), SnmpConstants.GetTypeName(v.Value.Type), v.Value.ToString()));
									lastvalue = v.Value.ToString();

									if (v.Oid.ToString() == statusOid)
									{
										status = v.Value.ToString();
									}
								}
								WriteTrapLog("** End of SNMP Version 2 TRAP data.");
								WriteTrapLog("\r\n");

								textBox1.Invoke(new Action(() =>
								{
									textBox1.AppendText(DateTime.Now.ToString() + "　Trap受信（" + lastvalue + "）\r\n");
								}));
							}
						}

						if (lastvalue == checkMsg)
						{
							if (status == "0")
							{
								PlayBatFile();
							}
						}
					}
					else
					{
						if (inlen == 0)
						{
							WriteTrapLog("Zero length packet received.");
						}
					}
				}
			});
		}

		/// <summary>
		/// フォームクローズイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			socket.Dispose();

			//プロパティを保存
			Properties.Settings.Default["PathCapture"] = textBoxPath1.Text;
			Properties.Settings.Default["PathCopy"] = textBoxPath2.Text;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// バッチファイル実行
		/// </summary>
		private void PlayBatFile()
		{
			batProcess = new Process();
			batProcess.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
			string path = System.Windows.Forms.Application.StartupPath + @"\bat\test.bat";
			batProcess.StartInfo.UseShellExecute = false;
			batProcess.StartInfo.CreateNoWindow = false;
			batProcess.StartInfo.Arguments = string.Format(@"/c {0}", path);
			batProcess.Start();

			if (!proFlag)
			{			
				proFlag = true;
			}
		}

		/// <summary>
		/// プロセスクローズメソッド
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (proFlag)
			{
				if (countTime <= 0)
				{
					batProcess.CloseMainWindow();
					batProcess.Close();
					proFlag = false;
					countTime = 295;
					textBox2.Text = "";

					//キャプチャ終了後ファイルを移動
					string[] files = System.IO.Directory.GetFiles(textBoxPath1.Text, "*", System.IO.SearchOption.TopDirectoryOnly);
					string copyToFolder = textBoxPath2.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
					Directory.CreateDirectory(copyToFolder);
					foreach (string file in files)
					{
						string name = Path.GetFileName(file);
						System.IO.File.Move(file, Path.Combine(copyToFolder, name));
					}
				}
				else
				{
					countTime--;
				}

				if (countTime != 295)
				{
					textBox2.Text = countTime.ToString() + "秒";
				}
			}
		}
	}
}
