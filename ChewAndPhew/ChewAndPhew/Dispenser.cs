using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewAndPhew
{
    public class Dispenser
    {
        private static Dispenser instance;
        public int MaxCapacity { get; set; }

        private static List<BubbleGum> _bubbleGums = new List<BubbleGum>();
        

        public Dispenser(int maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }

        public static Dispenser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dispenser(55);
                    BubblegumController bubblegumController = new BubblegumController();
                    instance.AddBubbleGumList(bubblegumController.MakeBubbles());
                }
                return instance;
            }
        }

        public void Dispense()
        {
            Console.WriteLine("Dispensing...");
        }

        public void AddBubbleGumList(List<BubbleGum> bubbleGum)
        {
            _bubbleGums.AddRange(bubbleGum);
        }

        public BubbleGum GetBubbleGum()
        {
            if (_bubbleGums.Count > 0)
            {
                throw new Exception("No bubblegum left");
            }
        }

        public BubbleGum RemoveBubbleGum()
        {
            BubbleGum bubbleGum = _bubbleGums[0];
            _bubbleGums.RemoveAt(0);
            return bubbleGum;
        }
    }
}
