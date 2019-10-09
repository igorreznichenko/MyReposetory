using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_part_2
{
    class DiskPhone
    {
        public int price;
        public int model;
        public int weight;
        public int mumber;
        public void DoCall() { }
        public void inputNumber() { }

    }
    class PhoneWithKeywords : DiskPhone {

        public int AmountOfMemory;
        public int NumberOfKeys;
        
    }
    class PhoneWithBlackWhiteScreen : PhoneWithKeywords {
        public int WidthOfScreen;
        public int HeightOfScreen;
        public int SignalStrength;
        public string NameOfSimCard;
        public void PlayInGame() { }
        public void TurnOnCalculator() { }
        public void UseCalendar() { }
        public void UseAlarm() { }
        public void UseTorch() { }
        public void SentMessage() { }
    }

    class PhoneColorScreen : PhoneWithBlackWhiteScreen
    {
        public int AmountCameraPixels;

        public void DoPhoto() { }
        public void UseInternet() { }
        public void PlayMusic() { }
        public void UseVideocamera() { }
        public void SeeVideos() { }
        public void UseAditionalMemoryCard() { }
        public void InstallApp() { }
        public void SeeWeathwer() { }

    }

    class IPhone : PhoneColorScreen {

        public void UseVideoCalls() { }
        public void UseAppstore() { }
       private void UseTouchId() { }
    }
    class GoogleGlass : IPhone {
        

        void ConnectToPhone() { }

    }



    class Program
    {
        static void Main(string[] args)
        {
            GoogleGlass Glass = new GoogleGlass();
        }
    }
}