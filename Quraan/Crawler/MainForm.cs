using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Crawler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownloadQuraan_Click(object sender, EventArgs e)
        {
            string targetDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Data\\Quran_WO_Tashkeel";
            if (!Directory.Exists(targetDir))
                Utilities.CreateDirectory(targetDir);
            XmlDocument doc;
            WebClient client = new WebClient();
            Random ran = new Random();
            for (int i = 1; i <= 114; i++)
            {
                doc = new XmlDocument();
                doc.AppendChild(doc.CreateElement("Sura"));
                doc.DocumentElement.Attributes.Append(doc.CreateAttribute("suranumber"));
                doc.DocumentElement.Attributes["suranumber"].Value = i.ToString();
                for (int x = 1; x <= 1000; x++)
                {
                    //string data = client.DownloadString(string.Format("http://quran.ksu.edu.sa/interface.php?ui=pc&do=tarjama&tafsir=ar_ayat&b_sura={0}&b_aya={1}&e_sura={0}&e_aya={2}", i, x, x + 1));
                    string data = client.DownloadString(string.Format("http://quran.ksu.edu.sa/interface.php?ui=pc&do=tarjama&tafsir=ar_ayat_safy&b_sura={0}&b_aya={1}&e_sura={0}&e_aya={2}", i, x, x + 1));
                    data = Encoding.UTF8.GetString(Encoding.Default.GetBytes(data));
                    if (string.IsNullOrEmpty(data) || data == "{\"tafsir\":{}}")
                        break;
                    data = data.Substring(data.IndexOf("\"text\":\"") + 8);
                    data = data.Replace("\"}}}", "");
                    XmlElement el = doc.CreateElement("Aya");
                    el.InnerText = data;
                    el.Attributes.Append(doc.CreateAttribute("sura"));
                    el.Attributes["sura"].Value = i.ToString();
                    el.Attributes.Append(doc.CreateAttribute("aya"));
                    el.Attributes["aya"].Value = x.ToString();
                    doc.DocumentElement.AppendChild(el);
                    Thread.Sleep(ran.Next(10, 200));
                    lblStatus.Text = "Sura: " + i + "   , Aya: " + x;
                    progress.Value = (int)(((double)i / (double)114) * 100);
                    Application.DoEvents();
                }
                doc.Save(targetDir + "\\" + i + ".xml");
            }
        }

        private void btnTafseer_Click(object sender, EventArgs e)
        {
            string targetDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Data\\Tafseer";
            if (!Directory.Exists(targetDir))
                Utilities.CreateDirectory(targetDir);
            XmlDocument doc;
            WebClient client = new WebClient();
            Random ran = new Random();
            for (int i = 110; i <= 114; i++)
            {
                doc = new XmlDocument();
                doc.AppendChild(doc.CreateElement("Sura"));
                doc.DocumentElement.Attributes.Append(doc.CreateAttribute("suranumber"));
                doc.DocumentElement.Attributes["suranumber"].Value = i.ToString();

                string data = client.DownloadString(string.Format("http://quran.ksu.edu.sa/interface.php?ui=pc&do=tarjama&tafsir=ar_mu&b_sura={0}&b_aya=1&e_sura={1}&e_aya=1", i, i + 1));
                data = Encoding.UTF8.GetString(Encoding.Default.GetBytes(data));
                if (string.IsNullOrEmpty(data) || data == "{\"tafsir\":{}}")
                    break;
                JObject o = JObject.Parse(data);
                for (int x = 1; x <= 1000; x++)
                {
                    data = data.Substring(data.IndexOf("\"text\":\"") + 8);
                    data = data.Replace("\"}}}", "");
                    XmlElement el = doc.CreateElement("Aya");
                    el.InnerText = data;
                    el.Attributes.Append(doc.CreateAttribute("sura"));
                    el.Attributes["sura"].Value = i.ToString();
                    el.Attributes.Append(doc.CreateAttribute("aya"));
                    el.Attributes["aya"].Value = x.ToString();
                    doc.DocumentElement.AppendChild(el);
                    Thread.Sleep(ran.Next(10, 200));
                    lblStatus.Text = "Sura: " + i + "   , Aya: " + x;
                    progress.Value = (int)(((double)i / (double)114) * 100);
                    Application.DoEvents();
                }
                doc.Save(targetDir + "\\" + i + ".xml");
            }
        }

        private void btnMp3_Click(object sender, EventArgs e)
        {
            string targetDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Data\\mp3";
            if (!Directory.Exists(targetDir))
                Utilities.CreateDirectory(targetDir);
            string[] mp3Urls = new string[]
            {
                "http://212.57.192.148/ayat/mp3/Ali_Jaber_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Husary_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Husary_Mujawwad_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Abdurrahmaan_As-Sudais_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Minshawy_Murattal_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Minshawy_Teacher_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Yaser_Salamah_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Ghamadi_40kbps/"
                ,"http://212.57.192.148/ayat/mp3/Yasser_Ad-Dussary_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Abu_Bakr_Ash-Shaatree_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Alafasy_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Mostafa_Ismail_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/AbdulSamad_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Muhammad_Ayyoub_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Abdullaah_3awwaad_Al-Juhaynee_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Mohammad_al_Tablaway_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/khaleefa_96kbps/"
                ,"http://212.57.192.148/ayat/mp3/warsh_dossary_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/husary_qasr_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Hussary.teacher_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Hudhaify_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Saood_ash-Shuraym_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Minshawy_Mujawwad_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Ayman_Sowaid_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Maher_AlMuaiqly_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Nasser_Alqatami_128kbps/"
                ,"http://212.57.192.148/ayat/mp3/Muhammad_Jibreel_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Ahmed_ibn_Ali_al-Ajamy_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Abdullah_Basfar_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Abdul_Basit_Murattal_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Fares_Abbad_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/Hani_Rifai_192kbps/"
                ,"http://212.57.192.148/ayat/mp3/Muhsin_Al_Qasim_192kbps/"
                ,"http://212.57.192.148/ayat/mp3/tunaiji_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/warsh_husary_64kbps/"
                ,"http://212.57.192.148/ayat/mp3/warsh_yassin_64kbps/"
            };
            XmlDocument doc;
            WebClient client = new WebClient();
            Random ran = new Random();
            for (int u = 0; u < mp3Urls.Length; u++)
            {
                for (int i = 1; i <= 114; i++)
                {
                    doc = new XmlDocument();
                    doc.AppendChild(doc.CreateElement("Sura"));
                    doc.DocumentElement.Attributes.Append(doc.CreateAttribute("suranumber"));
                    doc.DocumentElement.Attributes["suranumber"].Value = i.ToString();
                    for (int x = 1; x <= 1000; x++)
                    {
                        string filePath = targetDir + "\\" + mp3Urls[u].Replace("http://212.57.192.148/ayat/mp3/", "").Replace("/", "") + "\\" + i + "\\" + x + ".mp3";
                        if (File.Exists(filePath))
                            continue;
                        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                            Utilities.CreateDirectory(Path.GetDirectoryName(filePath));
                        try
                        {
                            client.DownloadFile(string.Format(mp3Urls[u] + "/{0}{1}.mp3", i.ToString("D3"), x.ToString("D3")), filePath);
                        }
                        catch (Exception) { break; }
                        Thread.Sleep(ran.Next(10, 200));
                        lblStatus.Text = mp3Urls[u].Replace("http://212.57.192.148/ayat/mp3/", "").Replace("/", "") + "     , Sura: " + i + "   , Aya: " + x;
                        progress.Value = (int)(((double)i / (double)114) * 100);
                        Application.DoEvents();
                    }
                }
            }
        }

        private void btnDownloadBooks_Click(object sender, EventArgs e)

        {
            string targetDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Data\\HolyQuran";
            if (!Directory.Exists(targetDir))
                Utilities.CreateDirectory(targetDir);
            string[] bookUrls = new string[]
            {
                "http://www.quranflash.com/books/12line/data/L/048.png"
                ,"http://www.quranflash.com/books/Douri/data/L/0261.png"
                ,"http://www.quranflash.com/books/Medina1/data/L/0001.gif"
                ,"http://www.quranflash.com/books/Medina2/data/L/0002.png"
                ,"http://www.quranflash.com/books/Medina3/data/L/0005.png"
                ,"http://www.quranflash.com/books/MedinaOld/data/L/0005.png"
                ,"http://www.quranflash.com/books/NaskhTaleek/data/L/0007.png"
                ,"http://www.quranflash.com/books/Qaloon/data/L/0009.png"
                ,"http://www.quranflash.com/books/Shamarly/data/L/0007.png"
                ,"http://www.quranflash.com/books/Shubah/data/L/0006.png"
                ,"http://www.quranflash.com/books/Tahajod/data/L/004.png"
                ,"http://www.quranflash.com/books/Tajweed/data/L/004.png"
                ,"http://www.quranflash.com/books/Urdu12/data/L/007.png"
                ,"http://www.quranflash.com/books/Urdu13/data/L/005.png"
                ,"http://www.quranflash.com/books/Urdu15/data/L/004.png"
                ,"http://www.quranflash.com/books/Warsh1/data/L/0009.png"
                ,"http://www.quranflash.com/books/Warsh2/data/L/006.png"
                ,"http://www.quranflash.com/books/Warsh2/data/L/006.png"
            };
            WebClient client = new WebClient();
            Random ran = new Random();
            for (int u = 0; u < bookUrls.Length; u++)
            {
                for (int i = 1; i <= 2000; i++)
                {
                    string bookName = bookUrls[u].Replace("http://www.quranflash.com/books/", "");
                    bookName = bookName.Substring(0, bookName.IndexOf("/"));
                    int pageNameLength = Path.GetFileNameWithoutExtension(bookUrls[u]).Length;
                    string url = bookUrls[u].Substring(0, bookUrls[u].LastIndexOf('/'));
                    url += "/" + i.ToString("D" + pageNameLength) + Path.GetExtension(bookUrls[u]);
                    string filePath = targetDir + "\\" + bookName + "\\" + i + Path.GetExtension(bookUrls[u]);
                    if (File.Exists(filePath))
                        continue;
                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        Utilities.CreateDirectory(Path.GetDirectoryName(filePath));
                    try
                    {
                        client.DownloadFile(url, filePath);
                    }
                    catch (Exception) { break; }
                    Thread.Sleep(ran.Next(10, 200));
                    lblStatus.Text = bookName + "     , Page : " + i;
                    //progress.Value = (int)(((double)i / (double)114) * 100);
                    Application.DoEvents();
                }
            }
        }
    }
}
