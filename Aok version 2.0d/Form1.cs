using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aok_version_2._0d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GamePath;
        private Byte[] exe;
        private string gameData;
        private string gamePath;
        public void Injection(UInt32 Addresse, string value)
        {
            string Value = string.Empty;
            string[] MybyteValue;
            UInt32 cpt = 0;
            Byte[] aocExe = exe;

            if (Addresse > 0x2FFFFF)
            {
                if (Addresse < 0x7A5000)
                {
                    Addresse -= 0x400000;
                }
                else
                {
                    Addresse -= 0x512000;
                }
            }

            Value = Regex.Replace(value, ".{2}", "$0 ");

            MybyteValue = Value.Split(' ');
            foreach (var item in MybyteValue)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int val = int.Parse(item, System.Globalization.NumberStyles.HexNumber);
                    var b = aocExe[Addresse + cpt];
                    aocExe[Addresse + cpt] = (byte)val;
                    var bb = aocExe[Addresse + cpt];
                }
                cpt++;
            }
            cpt = 0;
            exe = aocExe;
        }
        public void InjectionAge(UInt32 Addresse, string value)
        {
            string Value = string.Empty;
            string[] MybyteValue;
            UInt32 cpt = 0;
            Byte[] aocExe = exe;

            //if (Addresse > 0x2FFFFF)
            //{
            //    if (Addresse < 0x7A5000)
            //    {
            //        Addresse -= 0x400000;
            //    }
            //    else
            //    {
            //        Addresse -= 0x512000;
            //    }
            //}

            Value = Regex.Replace(value, ".{2}", "$0 ");

            MybyteValue = Value.Split(' ');
            foreach (var item in MybyteValue)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int val = int.Parse(item, System.Globalization.NumberStyles.HexNumber);
                    var b = aocExe[Addresse + cpt];
                    aocExe[Addresse + cpt] = (byte)val;
                    var bb = aocExe[Addresse + cpt];
                }
                cpt++;
            }
            cpt = 0;
            exe = aocExe;
        }
        private void btn_BrowserGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
            "empires2 exe (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.GamePath = openFileDialog.FileName;
                this.gamePath = new FileInfo(this.GamePath).Directory.FullName;
                this.gameData = new FileInfo(this.GamePath).Directory.FullName + "\\data";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.GamePath))
            {
                MessageBox.Show(@"Browser Game: Age of empire II\empires2.exe !!");
                return;
            }
            string empires2datFile = Path.Combine(this.gameData, "empires2.dat");
            if (File.Exists(empires2datFile))
            {
                File.Copy(empires2datFile,Path.Combine(this.gameData, "empires2Back"  + ".dat"),true);
                File.Delete(empires2datFile);
            }
            File.WriteAllBytes(empires2datFile,Properties.Resources.empires2) ;
            string Age = Path.Combine(this.gamePath, "age.dll");
            if (File.Exists(Age))
            {
                File.Delete(Age);
            }
            File.Copy(@"Age\age.dll", Age, true);
            string on = Path.Combine(this.gamePath, "on.ini");
            if (File.Exists(on))
            {
                File.Delete(on);
            }
            File.Copy(@"Age\on.ini", on,true);
            string mcp = Path.Combine(this.gamePath, "mcp.dll");
            if (File.Exists(mcp))
            {
                File.Delete(mcp);
            }
            File.Copy(@"Age\mcp.dll", mcp, true);
            string Aok = Path.Combine(this.gamePath, "Empires2.exe");
            if (File.Exists(Aok))
            {
                File.Copy(Aok,Path.Combine(this.gamePath, "empires2Back" + ".exe"),true);
                File.Delete(Aok);
            }
            File.WriteAllBytes(Aok, Properties.Resources.Empires21);

            exe = File.ReadAllBytes(GamePath);
            File.WriteAllBytes(GamePath, exe);
            //mini map
            //0058DF80 |. 8B4C24 10 | MOV ECX,DWORD PTR SS:[ESP + 10]
            //0058DF84 |. 8B51 04 | MOV EDX,DWORD PTR DS:[ECX + 4]
            Injection(0x058DF80, "E98B0F08009090");
            //0060EF10 
            Injection(0x60EF10, "8A4D1C884F308B4C24108B5104E965F0F7FF");

            //005C5224   . 74 09          JE SHORT Empires2.005C522F
            //0060EF24     
            //005C5222     84C0           TEST AL,AL
            Injection(0x5C5222, "84C00F84FA9C0400C1E80884C07405A07ECD6500D9473C6A06");
            //0060EF24     0FBE4F 30      MOVSX ECX,BYTE PTR DS:[EDI+30]
            Injection(0x60EF24, "0FBE4F308B86F80000008B404C8B0C888B91580100008B4210E9F462FBFF");
            //005C522D.EB 07          JMP SHORT Empires2.005C5236
            //005C522F > 33C0 XOR EAX,EAX


            //007D0143   0FBE4F 30        MOVSX ECX, BYTE PTR DS:[EDI+30]
            //007D0147   8B86 F8000000    MOV EAX, DWORD PTR DS:[ESI+F8]
            //007D014D   8B40 4C MOV EAX,DWORD PTR DS:[EAX+4C]
            //007D0150   8B0C88 MOV ECX,DWORD PTR DS:[EAX+ECX*4]
            //007D0153   8B91 58010000    MOV EDX, DWORD PTR DS:[ECX+158]
            //007D0159   8B42 10          MOV EAX, DWORD PTR DS:[EDX+10]
            //007D015C  -E9 C53DDFFF      JMP empires2.005C3F26


            //00461332     E9 0DDC1A00    JMP Empires2.0060EF44
            Injection(0x461332, "E90DDC1A00");
            //0060EF44     4D             DEC EBP
            Injection(0x60EF44, "4D4F8B410885C0E9E723E5FF");
            //0046134C  |> 8B51 30        MOV EDX,DWORD PTR DS:[ECX+30]
            //0046134C     E9 01DC1A00    JMP Empires2.0060EF52
            Injection(0x46134C, "E901DC1A00");
            //0060EF52     8B51 30        MOV EDX,DWORD PTR DS:[ECX+30]
            Injection(0x60EF52, "8B513083EA023BFAE9F223E5FF");
            //00461359     E9 03DC1A00    JMP Empires2.0060EF61
            Injection(0x461359, "E903DC1A00");
            //0060EF61     8B41 30        MOV EAX,DWORD PTR DS:[ECX+30]
            Injection(0x60EF61, "8B413083E8023BE8E9F023E5FF");

            //005C4B4F. 33D2           XOR EDX, EDX
            //005C4B51. 3BCF CMP ECX,EDI
            //005C4B53. 8986 78010000  MOV DWORD PTR DS:[ESI+178],EAX
            //005C4B59. 0F94C2 SETE DL
            //005C4B5C. 8996 7C010000 MOV DWORD PTR DS:[ESI+17C],EDX
            //005C4B62   > 8B4E 20        MOV ECX, DWORD PTR DS:[ESI+20]
            Injection(0x5C4B41, "81F9A600000072198D8E7C0100008941FC33C038010F940174073841010F944101");
            //0046140F     8B0D B0517A00  MOV ECX,DWORD PTR DS:[7A51B0]
            Injection(0x46140F, "B9000000009083C104894C241C666690");

            //tc coast no stone
            //
            Injection(0x5A0883, "E949E7060090");
            //1000C7AF   . 68 E4C70010    PUSH age.1000C7E4                        ;  ASCII "8DB06E01000066813E1301750666C74606000066813E8A00750666C746060000E99218F9FF90"
            Injection(0x60EFD1, "8DB06E01000066813E1301750666C74606000066813E8A00750666C746060000E99218F9FF90");

            File.WriteAllBytes(GamePath, exe);
            exe = null;

            exe = File.ReadAllBytes(Age);
            //100011E3     6A 05          PUSH 5
            Injection(0x00011E3, "6A05");
            File.WriteAllBytes(Age, exe);

            MessageBox.Show("Done.");
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.GamePath))
            {
                MessageBox.Show(@"Browser Game: Age of empire II\empires2.exe !!");
                return;
            }
            string empires2datFile = Path.Combine(this.gameData, "empires2.dat");
            string empires2datFileBack = Path.Combine(this.gameData, "empires2Back.dat");
            if (File.Exists(empires2datFileBack))
            {
                restoreFile(empires2datFileBack, empires2datFile);
            }
            else
            {
                //if back file don't exist then message error
                MessageBox.Show("can't back as last version, this is first time you patch or did you delete back file?");
                return;
            }
            string Aok = Path.Combine(this.gamePath, "Empires2.exe");
            string AokBack = Path.Combine(this.gamePath, "Empires2Back.exe");
            if (File.Exists(AokBack))
            {
                restoreFile(AokBack, Aok);
            }
            else
            {
                //if back file don't exist then message error
                MessageBox.Show("can't back as last version, this is first time you patch or did you delete back file?");
                return;
            }
            MessageBox.Show("Done.");
        }
        private void restoreFile(string fileTorestore,string fileTodelete)
        {
            //delete file
            if (File.Exists(fileTodelete))
                File.Delete(fileTodelete);
            //restore file 
            File.Copy(fileTorestore, fileTodelete);
            //delete file to restore 
            File.Delete(fileTorestore);
        }
    }
}
