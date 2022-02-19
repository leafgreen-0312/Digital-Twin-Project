using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using SymbolFactoryDotNet;



namespace Project_202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Resources\\industrial.jpg");
        }
        Plc _Plc = new Plc(CpuType.S71500, "192.168.1.199", 0, 1);
        PLCRead _PLCRead = new PLCRead();
        PLCReadValve1 _PLCReadValve1 = new PLCReadValve1();
        PLCReadValve2 _PLCReadVavle2 = new PLCReadValve2();
        PLCReadPump1 _PLCReadPump1 = new PLCReadPump1();
        PLCReadPump2 _PLCReadPump2 = new PLCReadPump2();
        PLCWrite _PLCWrite = new PLCWrite();
        SetDateTimePLC setDateTimePLC = new SetDateTimePLC();

        private void Form1_Load_1(object sender, EventArgs e)
        {
            bool flag;
            if (_Plc.Open() == ErrorCode.NoError)
            {
                flag = true;
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }  
           
            /*DateTime.Year = 2000;
            setDateTimePLC.Year = DateTime.Year;
            DateTime.Month = 12;
            setDateTimePLC.Month = DateTime.Month;
            DateTime.Day = 3;
            setDateTimePLC.Day = DateTime.Day;
            DateTime.Hour = 20;
            setDateTimePLC.Hour = DateTime.Hour;
            DateTime.Minute = 20;
            setDateTimePLC.Minute = DateTime.Minute;
            DateTime.Seccond = 20;
            setDateTimePLC.Seccond = DateTime.Seccond;
            DateTime.Nanosecond = 0;
            setDateTimePLC.Nanosecond = DateTime.Nanosecond;*/
        }
        private void ON_OFF(StandardControl symbol, bool Value)
         {
             if (Value == true)
             {
                 symbol.FillColorMode = SymbolFactoryNetEngine.FillColorModeOptions.Shaded;
             }
            else 
             {
                 symbol.FillColorMode = SymbolFactoryNetEngine.FillColorModeOptions.Original;
             }
         }
         private void Valve1_Click(object sender, EventArgs e)
         {
             tagValve1 valve1 = new tagValve1();
             valve1.ShowDialog();
         }
         private void Pump1_Click(object sender, EventArgs e)
         {
             tagPump1 pump1 = new tagPump1();
             pump1.ShowDialog();
         }

         private void Valve2_Click(object sender, EventArgs e)
         {
             tagValve2 valve2 = new tagValve2();
             valve2.ShowDialog();
         }

         private void Pump2_Click(object sender, EventArgs e)
         {
             tagPump2 pump2 = new tagPump2();
             pump2.ShowDialog();
         }

         private void buttonMan_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.0", false);
         }

         private void buttonAuto_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.0", true);
         }
         private void openValve1_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.2", false);
             _Plc.Write("DB5.DBX0.1", true);
         }
         private void closeValve1_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.1", false);
             _Plc.Write("DB5.DBX0.2", true);
         }
         private void openValve2_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.4", false);
             _Plc.Write("DB5.DBX0.3", true);

         }

         private void closeValve2_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.3", false);
             _Plc.Write("DB5.DBX0.4", true);
         }
         private void openPump1_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.5", true);
         }

         private void openPump2_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB5.DBX0.6", true);
         }
         private void pump1mode0_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB3.DBX0.3", false);
         }

         private void pump1mode1_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB3.DBX0.3", true);
         }

         private void pump2mode0_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB4.DBX0.3", false);
         }

         private void pump2mode1_Click(object sender, EventArgs e)
         {
             _Plc.Write("DB4.DBX0.3", true);
         }

         private void pump1setspeed_TextChanged(object sender, EventArgs e)
         {
             PLCWriteStatic.Pump_1_SetSpeed_Real = double.Parse(pump1setspeed.Text);
             _PLCWrite.Pump_1_SetSpeed_Real = PLCWriteStatic.Pump_1_SetSpeed_Real;
             _Plc.WriteClass(_PLCWrite, 7);
         }

         private void pump2setspeed_TextChanged(object sender, EventArgs e)
         {
             PLCWriteStatic.Pump_2_SetSpeed_Real = double.Parse(pump2setspeed.Text);
             _PLCWrite.Pump_2_SetSpeed_Real = PLCWriteStatic.Pump_2_SetSpeed_Real;
             _Plc.WriteClass(_PLCWrite, 7);
         }

        /*public bool isChanging = false;
        async private void setdatetime_TextChanged(object sender, EventArgs e)
        {
            // entry flag
            if (isChanging)
            {
                return;
            }
            isChanging = true;
            await Task.Delay(30000);
            // do your stuff here or call a function
            SetTime(setdatetime.Text);
            // exit flag
            isChanging = false;

        }
       */

        /*  public void SetTime(string Datetime)
        {
            string[] value = Datetime.Split('.');

            UInt16 year = UInt16.Parse(value[0]);
            DateTimeValue.Year = year;
            setDateTimePLC.Year = DateTimeValue.Year;

            byte month = byte.Parse(value[1]);
            DateTimeValue.Month = month;
            setDateTimePLC.Month = DateTimeValue.Month;

            byte day = byte.Parse(value[2]);
            DateTimeValue.Day = day;
            setDateTimePLC.Day = DateTimeValue.Day;

            byte Weekday = byte.Parse(value[3]);
            DateTimeValue.Weekday = Weekday;
            setDateTimePLC.Day = DateTimeValue.Weekday;

            byte hour = byte.Parse(value[4]);
            DateTimeValue.Hour = hour;
            setDateTimePLC.Hour = DateTimeValue.Hour;

            byte minute = byte.Parse(value[5]);
            DateTimeValue.Minute = minute;
            setDateTimePLC.Minute = DateTimeValue.Minute;

            byte second = byte.Parse(value[6]);
            DateTimeValue.Second = second;
            setDateTimePLC.Seccond = DateTimeValue.Second;

            UInt32 nanoseccon = UInt32.Parse(value[7]);
            DateTimeValue.Nanosecond = nanoseccon;
            setDateTimePLC.Nanosecond = DateTimeValue.Nanosecond;

            if (year < 1970 && year > 2100) 
             {
                MessageBox.Show("Invalid Year", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
            if (month < 0 && month > 12)
             {
                MessageBox.Show("Invalid Month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
            if (day < 0 && day > 31)
            {
                MessageBox.Show("Invalid Day", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (hour < 0 && hour > 24)
             {
                MessageBox.Show("Invalid Hour", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
            if (minute < 0 && minute > 60)
            {
                MessageBox.Show("Invalid Minute", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (second < 0 && second > 60)
            {
                MessageBox.Show("Invalid Second", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      */

        readonly double levelvalue;
        private void timer1_Tick(object sender, EventArgs e)
        {
              _Plc.ReadClass(_PLCRead, 6);
              ON_OFF(Led_Man, _PLCRead.man_mode);
              ON_OFF(Led_Auto, _PLCRead.auto_mode);
              Level.Level = _PLCRead.Level;
              leveltank.Text = _PLCRead.Level.ToString("0.00" + " m");

              _Plc.ReadClass(_PLCReadValve1, 1);
              ON_OFF(Valve1, _PLCReadValve1.Valve_1_Opened);

              _Plc.ReadClass(_PLCReadVavle2, 2);
              ON_OFF(Valve2, _PLCReadVavle2.Valve_2_Opened);

              _Plc.ReadClass(_PLCReadPump1, 3);
              ON_OFF(Pump1, _PLCReadPump1.Pump_1_Opened);
              ON_OFF(pump1mode, _PLCReadPump1.Pump_1_Speed_Mode);

              _Plc.ReadClass(_PLCReadPump2, 4);
              ON_OFF(Pump2, _PLCReadPump2.Pump_2_Opened);
              ON_OFF(pump2mode, _PLCReadPump2.Pump_2_Speed_Mode); 
            //  int startbyte = 12;
            // _Plc.WriteClass(setDateTimePLC, 2, startbyte);
           
        }

       
    }
}
