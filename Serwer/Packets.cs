﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    public class Packets
    {
        public string Line { get; set; }
        public int Nr { get; set; }
        public string SourIP { get; set; }
        public string DestIP { get; set; }
        public string SourMAC { get; set; }
        public string DestMAC { get; set; }
        public string Protocol { get; set; }
        public string CheckSum { get; set; }
        public string Identification { get; set; }

        public Packets(string line, int Id)
        {
            Line = line;
            Nr = Id;
            string temp = "";
            int fieldnumber = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    if (fieldnumber == 1)
                    {
                        SourIP = temp;  
                    }
                    else if (fieldnumber == 2)
                    {
                        DestIP = temp;
                    }
                    else if (fieldnumber == 3)
                    {
                        SourMAC = temp.Replace(":", "").ToUpper();
                    }
                    else if (fieldnumber == 4)
                    {
                        DestMAC = temp.Replace(":", "").ToUpper();
                    }


                    //ostatnie pole jest zakończone dolarem i jest w ifie poniżej
                    else
                    { }
                    fieldnumber++;
                    temp = "";
                }
                else if (line[i] == ',')
                {
                    CheckSum = temp;
                    break;
                }
                else
                {
                    temp = temp + line[i];
                }


                //TODO Parsowanie linii

            }
            //Console.WriteLine(display_information());
        }

        public string display_information()
        {
            return (Nr + " " + SourMAC + " " + DestMAC + " "  + SourIP + " " + DestIP+" " +CheckSum+"\n");
        }
    }
}
