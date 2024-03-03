using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewAndPhew
{
    public class BubblegumController
    {
        public Dispenser CreateDispenser()
        {
            Dispenser dispenser = new Dispenser(55);

            dispenser.AddBubbleGumList(MakeBubbles());
            return dispenser;


        }
        public List<BubbleGum> MakeBubbles()
        {
            List<BubbleGum> bubbleGums = new List<BubbleGum>();

            bubbleGums.AddRange(GenerateBubbleGums("Strawberry", 0.14, 55));
            bubbleGums.AddRange(GenerateBubbleGums("Blueberry", 0.25, 55));
            bubbleGums.AddRange(GenerateBubbleGums("Tutti Frutti", 0.20, 55));
            bubbleGums.AddRange(GenerateBubbleGums("Blacberry", 0.12, 55));
            bubbleGums.AddRange(GenerateBubbleGums("Apple", 0.10, 55));
            bubbleGums.AddRange(GenerateBubbleGums("Orange", 0.19, 55));

            return bubbleGums;
        }

        private List<BubbleGum> GenerateBubbleGums(string flavor, double percentage, int totalBubbles)
        {
            List<BubbleGum> bubbleGums = new List<BubbleGum>();
            int amount = (int)(totalBubbles * percentage);
            for (int i = 0; i < amount; i++)
            {
                bubbleGums.Add(new BubbleGum(flavor));
            }
            return bubbleGums;
        }
    }
}
