using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    static class Hospital {
       static public void MRT(ref Patient p) {
            p.mrt_pass = true;
        }
       static  public void KT(ref Patient p) {
            p.kt_pass = true;
        }
       static public void Rentgen(ref Patient p) {
            p.rentgen_pass = true;
        }
       static public void LOR(ref Patient p) {
            p.lor_pass = true;
        }
       static public void USI(ref Patient p) {
            p.usi_pass = true;
        }
       static public void Remwo(ref Patient p) {
            p.remwo_pass = true;
        }
        
    
    }
    class Patient
    {
        public bool mrt_pass;
        public bool kt_pass;
        public bool rentgen_pass;
        public bool lor_pass;
        public bool usi_pass;
        public bool remwo_pass;
        public bool MRT_Pass {
            get { return mrt_pass; }
        }
        public bool KT_Pass {
            get { return kt_pass; }
        }
        public bool Rentgen_Pass
        {
            get { return rentgen_pass; }
        }
        public bool LOR_Pass
        {
            get { return lor_pass; }
        }
        public bool USI_Pass
        {
            get { return usi_pass; }
        }
        public bool Remwo_Pass
        {
            get { return remwo_pass; }
        }
        public void Get_Info()
        {

            Console.WriteLine("Mrt passed : {0}", MRT_Pass);
            Console.WriteLine("KT passed : {0}", KT_Pass);
            Console.WriteLine("Rentgen passed :{0}", Rentgen_Pass);
            Console.WriteLine("LOR passed : {0}", LOR_Pass);
            Console.WriteLine("USI passed : {0}", USI_Pass);
            Console.WriteLine("Remwo passed : {0}", Remwo_Pass);
        }
    }
    class Program
    {
        public delegate void Hospital_Work(ref Patient p);
        static void Main(string[] args)
        {       
            Patient patient = new Patient();
            Hospital_Work hospital = Hospital.MRT;
            hospital += Hospital.KT;
            hospital += Hospital.Rentgen;
            hospital += Hospital.LOR;
            hospital += Hospital.USI;
            hospital += Hospital.Remwo;

            Console.WriteLine("1: to pass MRT");
            Console.WriteLine("2: to pass KT");
            Console.WriteLine("3: to pass Rentgen");
            Console.WriteLine("4: to pass LOR");
            Console.WriteLine("5: to pass USI");
            Console.WriteLine("6: to pass Remwo");
            Console.WriteLine("7: to pass all");
            Console.WriteLine("8: se status");
            Console.WriteLine("0: Exit");

            string s;
            do
            {
              
                s = Console.ReadLine();
                switch(s){
                    case "1":
                        {
                            Hospital.MRT(ref patient);
                            Console.WriteLine("Operation complete");
                            break;

                        }
                    case "2":
                        {
                            Hospital.KT(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "3":
                        {
                            Hospital.Rentgen(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "4":
                        {
                            Hospital.LOR(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "5":
                        {
                            Hospital.USI(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "6":
                        {
                            Hospital.Remwo(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "7":
                        {
                            hospital(ref patient);
                            Console.WriteLine("Operation complete");

                            break;
                        }
                    case "8":
                        {
                            patient.Get_Info();
                            break;
                        }

                }

            } while (s != "0");
        }
    }
}
